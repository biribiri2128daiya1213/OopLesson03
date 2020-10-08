using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06 {
	class Program {
		static void Main(string[] args) {
			//整数の例
			var numbers = new List<int>
			{19,17,15,24,12,25,14,20,12,28,19,30,24, };

			numbers.Select(n => n.ToString("0000")).Distinct().ToList().ForEach(Console.WriteLine);

			numbers.OrderBy(n => n).ToList().ForEach(Console.WriteLine);


			var words = new List<string> {
				"Microsoft",
				"Apple" ,
				"Google",
				"Oracle",
				"Facebook",
			};
			//文字列の例
			words.Select(s => s.ToLower()).ToList().ForEach(Console.WriteLine);
			Console.WriteLine("\n");




			//books
			var books = Books.GetBooks();

			var titles = books.Select(b => b.Title);
			foreach (var title in titles) {
				Console.WriteLine(title);
			}

			Console.WriteLine("\n-----ページの大きい順-----");
			books.OrderByDescending(b => b.Pages).ToList()
				.ForEach(b => Console.WriteLine($"{b.Title}:{b.Pages}ページ"));

			Console.WriteLine("\n-----価格の高い順-----");
			books.OrderByDescending(b => b.Price).ToList()
				.ForEach(b => Console.WriteLine($"{b.Title}:{b.Price}円"));






		}
	}
}
