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
			string _text = "Cozy lummox gives smart squid who asks for job pen";
			//7-1-1
			Console.WriteLine("\n-----7.1.1(英字のカウント)-----");
			var dict = new Dictionary<char, int>();
			foreach (var t in _text.ToUpper()) {
				if ('A' <= t && t <= 'Z') {
					if (dict.ContainsKey(t)) {
						dict[t]++;
					} else {
						dict[t] = 1;
					}
				}
			}
			foreach (var d in dict.OrderBy(x => x.Key)) {
				Console.WriteLine($"'{d.Key}' : {d.Value}");
			}

			//7-1-2
			Console.WriteLine("\n-----7.1.2(英字のカウント2)-----");
			var sortdict = new SortedDictionary<char, int>();
			foreach (var t in _text.ToUpper()) {
				if ('A' <= t && t <= 'Z') {
					if (sortdict.ContainsKey(t)) {
						sortdict[t]++;
					} else {
						sortdict[t] = 1;
					}
				}
			}
			foreach (var d in sortdict) {
				Console.WriteLine($"'{d.Key}':{d.Value}");
			}

			//7-2-3
			Console.WriteLine("\n-----7.2.3(CountとRemoveの確認)-----");
			var abb = new Abbreviations();
			Console.WriteLine($"行数:{abb.Count}");
			Console.Write("削除する省略語:");
			var abbre = Console.ReadLine();
			Console.WriteLine(abb.Remove(abbre) ? "削除しました" : "削除できませんでした");
			Console.WriteLine($"行数:{abb.Count}");

			//7-2-4
			Console.WriteLine("\n-----7.2.4(3文字の省略語一覧)-----");
			foreach (var a in abb.ThreeAbb()) {
				Console.WriteLine($"{a.Key}={a.Value}");
			}
			Console.WriteLine();
			
			
		}
	}
}
