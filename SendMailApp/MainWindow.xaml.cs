using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SendMailApp {
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window {

		SmtpClient sc = new SmtpClient();
		
		public MainWindow() {
			InitializeComponent();
			sc.SendCompleted += Sc_SendCompleted;
		}
		private void Sc_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
			if (e.Cancelled) {
				MessageBox.Show("送信はキャンセルされました");
			} else {
				MessageBox.Show(e.Error?.Message ?? "送信完了っ!");
			}
		}

		private void btOK_Click(object sender, RoutedEventArgs e) {
			try {
				Config cf = Config.GetInstance();
				char[] separation = " ;/，、　".ToArray();

				foreach (var s in separation) {
					tbTo.Text = tbTo.Text.Replace(s.ToString(), ",");
					tbCc.Text = tbCc.Text.Replace(s.ToString(), ",");
					tbBcc.Text = tbBcc.Text.Replace(s.ToString(), ",");
				}
				MailAddress from = new MailAddress(cf.MailAddress, cf.UserName);
				MailMessage msg = new MailMessage {
					From = from,
					Subject = tbTitle.Text,	//件名
					Body = tbBody.Text		//本文
				};
				msg.To.Add(tbTo.Text);

				if (tbCc.Text != "") {
					msg.CC.Add(tbCc.Text);
				}
				if (tbBcc.Text != "") {
					msg.Bcc.Add(tbBcc.Text);
				}

				foreach (string n in lbTemp.Items) {
					msg.Attachments.Add(new Attachment(n));
				}

				sc.Host = cf.Smtp; //smtpサーバの設定
				sc.Port = cf.Port;
				sc.EnableSsl = cf.Ssl;
				sc.Credentials = new NetworkCredential(cf.MailAddress, cf.PassWord);

				sc.SendMailAsync(msg); //送信

			} catch(Exception ex) {
				MessageBox.Show(ex.Message); 
			}
		}
		//キャンセルボタン
		private void btCancel_Click(object sender, RoutedEventArgs e) {
			sc.SendAsyncCancel();
		}
		//設定ボタン
		private void btConfig_Click(object sender, RoutedEventArgs e) {
			ConfigWindowShow();
		}

		private static void ConfigWindowShow() {
			ConfigWindow configWindow = new ConfigWindow();
			configWindow.ShowDialog();
		}
		//ロード時
		private void Window_Loaded(object sender, RoutedEventArgs e) {
			try {
				Config.GetInstance().DeSerialise();
				ConfigWindow cw = new ConfigWindow();
			} catch (FileNotFoundException){
				ConfigWindowShow();
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}
		//閉じたあと
		private void Window_Closed(object sender, EventArgs e) {
			try {
				ConfigWindow cw = new ConfigWindow();
				if (cw.IsXmlSaved()) {
					Config.GetInstance().Serialise();
				}
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}
		//追加ボタン
		private void btAdd_Click(object sender, RoutedEventArgs e) {
			var dialog = new OpenFileDialog {
				Filter = "テキストファイル (*.txt)|*.txt|全てのファイル (*.*)|*.*"
			};

			if (dialog.ShowDialog() == true) {
				lbTemp.Items.Add(dialog.FileName);
			}
		}
		//削除ボタン
		private void btDel_Click(object sender, RoutedEventArgs e) {
			lbTemp.Items.Remove(lbTemp.SelectedItem);
		}
	}
}
