using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace SendMailApp {
	public class Config {
		private static Config instance;

		public string Smtp { get; set; }			//SMTPサーバー
		public string MailAddress { get; set; }     //自メールアドレス(送信元)
		public string UserName { get; set; }		//ユーザーネーム
		public string PassWord { get; set; }		//パスワード
		public int Port { get; set; }				//ポート番号
		public bool Ssl { get; set; }               //SSL設定

		public static Config GetInstance() {
			if (instance == null) {
				instance = new Config();
			}
			return instance;
		}
		private Config() {}
		//初期設定用
		public void DefaultSet() {
			Smtp = "smtp.gmail.com";
			MailAddress = "ojsinfosys01@gmail.com";
			UserName = "ojsinfosys01@gmail.com";
			PassWord = "ojsInfosys2020";
			Port = 587;
			Ssl = true;
		}
		//初期値取得
		public Config getDefaultStatus() {
			Config obj = new Config {
				Smtp = "smtp.gmail.com",
				MailAddress = "ojsinfosys01@gmail.com",
				UserName = "ojsinfosys01@gmail.com",
				PassWord = "ojsInfosys2020",
				Port = 587,
				Ssl = true,
			};
			return obj;

		}
		//設定データ更新
		public bool UpdateStatus(string smtp,string mailAddress,string username,string passWord,int port,bool ssl) {
			this.Smtp = smtp;
			this.MailAddress = mailAddress;
			this.UserName = username;
			this.PassWord = passWord;
			this.Port = port;
			this.Ssl = ssl;
			return true;
		}

		//シリアル化
		public void Serialise() {
			using (var xmlWriter = XmlWriter.Create("config.xml")) {
				XmlSerializer xml = new XmlSerializer(typeof(Config));
				xml.Serialize(xmlWriter, instance);
			}
		}
		//逆シリアル化
		public void DeSerialise() {
			using (var xmlReader = XmlReader.Create("config.xml")) {
				XmlSerializer xml = new XmlSerializer(typeof(Config));
				instance = xml.Deserialize(xmlReader) as Config;
			}
		}
	}
}
