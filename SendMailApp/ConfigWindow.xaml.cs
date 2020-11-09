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
		public ConfigWindow() {
			InitializeComponent();
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
			Config.GetInstance().UpdateStatus(
			tbSmtp.Text,
			tbName.Text,//tbSender
			tbPassWord.Password,
			int.Parse(tbPort.Text),
			cbSsl.IsChecked ?? false
			);
			
		}
		//キャンセルボタン
		private void brCancel_Click(object sender, RoutedEventArgs e) {
			this.Close();
		}
		//OKボタン
		private void btOk_Click(object sender, RoutedEventArgs e) {
			btApply_Click(sender, e);
			this.Close();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e) {
			Config cf = Config.GetInstance();
			tbSmtp.Text = cf.Smtp;
			tbPassWord.Password = cf.PassWord;
			tbSender.Text = tbName.Text = cf.MailAddress;
			tbPort.Text = cf.Port.ToString();
			cbSsl.IsChecked = cf.Ssl;
		}
	}
}
