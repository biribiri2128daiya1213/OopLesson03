using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04 {
	class Program {
		static void Main(string[] args) {
			//4-2-1
			YearMonth[] yearmonths = new YearMonth[]{
				new YearMonth(2101,1),
				new YearMonth(2101,2),
				new YearMonth(2002,3),
				new YearMonth(2803,4),
				new YearMonth(2404,5),
			};

			//4-2-2
			Console.WriteLine("\n-----4-2-2-----");
			foreach (var ym in yearmonths) {
				Console.WriteLine(ym);
			}

			//4-2-4
			Console.WriteLine("\n-----4-2-4-----");
			var yearmonth = FindFirst21C(yearmonths) == null 
				? "21世紀のデータはありません" 
				: FindFirst21C(yearmonths).ToString();
			Console.WriteLine(yearmonth);

			//4-2-5
			Console.WriteLine("\n-----4-2-5-----");
			var OneAddYm = yearmonths.Select(ym => ym.AddOneMonth()).ToArray();
			OneAddYm.ToList().ForEach(Console.WriteLine);

		}
		//4-2-3
		static YearMonth FindFirst21C(YearMonth[] yms) {
			foreach (var ym in yms) {
				if (ym.IsCentury) {
					return ym;
				}
			}
			return null;
		}
	}
}
