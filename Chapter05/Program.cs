using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter05 {
	class Program {
		static void Main(string[] args) {
			//5-1
			Console.WriteLine("\n-----5.1-----");
			Console.Write("文字列1:");
			var str1 = Console.ReadLine();
			Console.Write("文字列2:");
			var str2 = Console.ReadLine();

			if (String.Compare(str1, str2, ignoreCase: true) == 0) {
				Console.WriteLine("等しい");
			} else {
				Console.WriteLine("等しくない");
			}

			//5-2
			Console.WriteLine("\n-----5.2-----");
			Console.Write("数字文字列:");
			var number = int.TryParse(Console.ReadLine(), out int num);
			Console.WriteLine(num.ToString("#,#"));

			//5-3
			string text = "Jackdaws love my big sphinx of quartz";
			//5-3-1
			Console.WriteLine("\n-----5.3.1-----");
			Console.WriteLine(text.Count(s => s.Equals(' ')));

			//5-3-2
			Console.WriteLine("\n-----5.3.2-----");
			var str5_3_2 = text.Replace("big", "small");
			Console.WriteLine(str5_3_2);

			//5-3-3
			Console.WriteLine("\n-----5.3.3-----");
			string[] words = text.Split(' ');
			Console.WriteLine(words.Length);

			//5-3-4
			Console.WriteLine("\n-----5.3.4-----");
			words.Where(s => s.Length <= 4).ToList().ForEach(Console.WriteLine);

			//5-3-5
			Console.WriteLine("\n-----5.3.5-----");
			var sb = new StringBuilder(words[0]);
			foreach (var word in words.Skip(1)) {
				sb.Append(' ');
				sb.Append(word);
			}
			var sbtext = sb.ToString();
			Console.WriteLine(sbtext);

			//5-4
			Console.WriteLine("\n-----5.4-----");
			var str5_4 = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
			var list = str5_4.Split(';');
			var values = new string[list.Length];

			for (int i = 0; i < values.Length; i++) {
				values[i] = list[i].Substring(list[i].IndexOf('=') + 1);
			}
			for (int i = 0; i < values.Length; i++) {
				Console.WriteLine($"{NovelistData(i)}:{values[i]}");
			}
			Console.WriteLine();
		}
		public static string NovelistData(int index){
			switch (index) {
				case 0:
					return "作家　";
				case 1:
					return "代表作";
				case 2:
					return "誕生年";
				default:
					return "";
			}
		}
		
	}
}
