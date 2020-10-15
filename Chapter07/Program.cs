using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Chapter07 {
	class Program {
		static void Main(string[] args) {
			var dict = new Dictionary<string, List<string>>();
			string menu = "";
			var flag = true;
			Console.WriteLine("**********************");
			Console.WriteLine("* 辞書登録プログラム *");
			Console.WriteLine("**********************");
			do {
				do {
					Console.WriteLine("1．登録　2．内容を表示　3．終了");
					menu = Console.ReadLine();
				} while (menu != "1" && menu != "2" && menu != "3");

				switch (menu) {
					case "1":
						Console.Write("KEYを入力:");
						var key = Console.ReadLine();
						Console.Write("VALUEを入力:");
						var value = Console.ReadLine();
						if (dict.ContainsKey(key)) {
							dict[key].Add(value);
						} else {
							dict[key] = new List<string> { value };
						}
						Console.WriteLine("登録しました！");
						break;
					case "2":
						if (dict.Count != 0) {
							foreach (var d in dict) {
								foreach (var term in d.Value) {
									Console.WriteLine("{0} : {1}", d.Key, term);
								}
							}
							Console.WriteLine();
						} else {
							Console.WriteLine("登録されていません");
						}
						break;
					case "3":
						flag = false;
						break;
					default:
						break;
				}
				Console.WriteLine();
			} while (flag);
		}
	}
}
