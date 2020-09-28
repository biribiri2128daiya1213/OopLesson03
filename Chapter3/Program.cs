using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3 {
	class Program {
		static void Main(string[] args) {
			var names = new List<string> {
				"Tokyo","New Delhi","Bangkok","London","Paris","Berlin","Canberra","Hong Kong",
			};

			#region 3-2-1
			Console.WriteLine("-----3.2.1-----");
			while (true) {
				Console.WriteLine("都市名を入力。空行で終了");
				var line = Console.ReadLine();
				if (string.IsNullOrEmpty(line))
					break;
				var index = names.FindIndex(s => s == line);
				Console.WriteLine(index);
			}
			#endregion

			#region 3-2-2
			Console.WriteLine("\n-----3.2.2-----");
			var count = names.Count(s => s.Contains('o'));
			Console.WriteLine(count);
			#endregion

			#region 3-2-3	
			Console.WriteLine("\n-----3.2.3-----");
			var array = names.Where(s => s.Contains('o')).ToArray();
			foreach (var name in array) {
				Console.WriteLine(name);
			}
			#endregion

			#region 3-2-4
			Console.WriteLine("\n-----3.2.4-----");
			var length = names.Where(s => s.StartsWith("B")).Select(s => s.Length);
			foreach (var len in length) {
				Console.WriteLine(len);
			}
			#endregion
		}
	}
}