using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SendMailApp {
	/// <summary>
	/// ConfigWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class ConfigWindow : Window {
		public bool flag = false;
		public ConfigWindow() {
			InitializeComponent();
		}

		private void TextChanged(object sender, RoutedEventArgs e) {
			flag = true;
		}

		private void btDefault_Click(object sender, RoutedEventArgs e) {
			Config cf = (Config.GetInstance()).getDefaultStatus();
			tbName.Text = tbSender.Text = cf.MailAddress;
			tbSmtp.Text = cf.Smtp;
			tbPassWord.Password = cf.PassWord;
			tbPort.Text = cf.Port.ToString();
			cbSsl.IsChecked = cf.Ssl;
		}

		private void btApply_Click(object sender, RoutedEventArgs e) {
			if (Icheck()) {
				MessageBox.Show("未入力の項目があります");
			} else {
				Apply();
			}
		}

		private void Apply() {
			Config.GetInstance().UpdateStatus(
			tbSmtp.Text,
			tbName.Text,//tbSender
			tbPassWord.Password,
			int.Parse(tbPort.Text),
			cbSsl.IsChecked ?? false
			);
			FlagChange();
		}

		//キャンセルボタン
		private void brCancel_Click(object sender, RoutedEventArgs e) {
			if (Icheck()) {
				MessageBox.Show("未入力の項目があります");
			} else {
				if (Ucheck()) {
					MessageBoxResult result = MessageBox.Show
						("変更を保存しますか？", "保存", MessageBoxButton.YesNo, MessageBoxImage.Question);
					if (result == MessageBoxResult.Yes) {
						Apply();
						this.Close();
					} else {
						this.Close();
					}
				} else {
					this.Close();
				}
			}
		}
		//OKボタン
		private void btOk_Click(object sender, RoutedEventArgs e) {
			if (Icheck()) {
				MessageBox.Show("未入力の項目があります");
			} else {
				Apply();
				this.Close();
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e) {
			Config cf = Config.GetInstance();
			tbSmtp.Text = cf.Smtp;
			tbPassWord.Password = cf.PassWord;
			tbSender.Text = tbName.Text = cf.MailAddress;
			tbPort.Text = cf.Port.ToString();
			cbSsl.IsChecked = cf.Ssl;
			flag = false;
		}
		//データ入力確認(空白があればtrue)
		public bool Icheck() {
			return (tbSmtp.Text == "" || tbPort.Text == "" ||
				tbName.Text == "" || tbPassWord.Password == "" || tbSender.Text == "");
		}
		//データ変更確認(変更があればtrue)
		public bool Ucheck() {
			return flag;
		}

		public void FlagChange() {
			MainWindow mw = new MainWindow();
			flag = !flag;
		}
	}
}
