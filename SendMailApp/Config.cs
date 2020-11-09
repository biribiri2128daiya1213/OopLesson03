using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SendMailApp {
	public class Config {
		private static Config Instance;

		public string Smtp { get; set; }			//SMTPサーバー
		public string MailAddress { get; set; }		//自メールアドレス(送信元)
		public string PassWord { get; set; }		//パスワード
		public int Port { get; set; }				//ポート番号
		public bool Ssl { get; set; }               //SSL設定

		public static Config GetInstance() {
			if (Instance == null) {
				Instance = new Config();
			}
			return Instance;
		}
		private Config() {}
		//初期設定用
		public void DefaultSet() {
			Smtp = "smtp.gmail.com";
			MailAddress = "ojsinfosys01@gmail.com";
			PassWord = "ojsInfosys2020";
			Port = 587;
			Ssl = true;
		}
		//初期値取得
		public Config getDefaultStatus() {
			Config obj = new Config {
				Smtp = "smtp.gmail.com",
				MailAddress = "ojsinfosys01@gmail.com",
				PassWord = "ojsInfosys2020",
				Port = 587,
				Ssl = true,
			};
			return obj;

		}
		//設定データ更新
		public bool UpdateStatus(string smtp,string mailAddress,string passWord,int port,bool ssl) {
			this.Smtp = smtp;
			this.MailAddress = mailAddress;
			this.PassWord = passWord;
			this.Port = port;
			this.Ssl = ssl;
			return true;
		}

		public void Serialise() {
			Config cf = Instance;
			using (var xmlWriter = XmlWriter.Create("config.xml")) {
				XmlSerializer xml = new XmlSerializer(typeof(Config));
				xml.Serialize(xmlWriter, cf);
			}
		}
		public void DeSerialise() {
			using (var xmlReader = XmlReader.Create("config.xml")) {
				XmlSerializer xml = new XmlSerializer(typeof(Config));
				Instance = xml.Deserialize(xmlReader) as Config;
			}
		}
		
	}
}
