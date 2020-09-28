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
			//var line = Console.ReadLine();

			//var index = names.FindIndex(s => s == line);
			//Console.WriteLine($"{index}番目");
			#endregion

			#region 3-2-2
			//var count = names.Count(s => s.Contains('o'));
			//Console.WriteLine(count);
			#endregion

			#region 3-2-3			
			//var list = names.Where(s => s.Contains('o'));
			//string[] array = list.ToArray();

			//foreach (var n in array) {
			//	Console.WriteLine(n);
			//}
			#endregion

			#region 3-2-4
			var length = names.Where(s => s[0] == 'B').Select(s => s.Length);
			foreach (var len in length) {
				Console.WriteLine(len);
			}
			#endregion
		}
	}
}