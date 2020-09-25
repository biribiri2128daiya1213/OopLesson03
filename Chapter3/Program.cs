using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3 {
	class Program {
		static void Main(string[] args) {
			var list = new List<string>{
				"Tokyo",
				"New Delhi",
				"Bangkok",
				"London",
				"Paris",
				"Berlin",
				"Canberra",
				"Hong Kong",
			};

			//var exists = list.Exists(s => s[0] == 'L');
			//var name = list.Find(s => s.Length == 6);
			//var index = list.FindIndex(s => s.Length == 6);
			//var names = list.FindAll(s => s.Length <= 5);
			//list.FindAll(s => s.Length <= 5).ForEach(s => Console.WriteLine(s));
			list.ConvertAll(s => s.ToUpper()).ForEach(s => Console.WriteLine(s));





			//Console.WriteLine(exists);
			//Console.WriteLine(name);
			//Console.WriteLine(index);
			//foreach (var name in names) {
			//	Console.WriteLine(name);
			//}
		}
	}
}