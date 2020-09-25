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

			IEnumerable<string> query = list.Where(s => s.Length <= 5);
			foreach (string s in query) {
				Console.WriteLine(s);
			}


		}
	}
}