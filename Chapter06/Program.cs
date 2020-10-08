using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06 {
	class Program {
		static void Main(string[] args) {
			var numbers = new List<int> { 9, 7, -5, 4, 2, 5, 4, 2, -4, 8, -1, 6, 4, };
			Console.WriteLine($"平均値:{numbers.Average()}\n");
			Console.WriteLine($"合計値:{numbers.Sum()}\n");
			Console.WriteLine($"最小値:{numbers.Min()}\n");
			Console.WriteLine($"最大値:{numbers.Max()}\n");
			Console.WriteLine($"正の数の最小値:{numbers.Where(n => n > 0).Min()}\n");

			bool exists = numbers.Any(n => n % 7 == 0);
			Console.WriteLine($"7の倍数:{exists}\n");

			var results = numbers.Where(n => n > 0).Take(3);
			;
			foreach (var result in results) {
				Console.Write($"{result} ");
			}
			Console.WriteLine("\n");

			var books = Books.GetBooks();

			Console.WriteLine($"本の平均価格:{books.Average(b => b.Price):f2}円\n");
			Console.WriteLine($"本の合計価格:{books.Sum(b => b.Price)}円\n");
			Console.WriteLine($"本の最大ページ数:{books.Max(b => b.Pages)}P\n");
			Console.WriteLine($"高価な本:{books.Max(b => b.Price)}円\n");
			Console.WriteLine
				($"タイトルに「物語」含まれる冊数:{books.Count(b => b.Title.Contains("物語"))}冊\n");

			Console.Write($"600ページを超える本があるか:");
			Console.WriteLine(books.Any(b => b.Pages > 600) ? "ある\n" : "ない\n");

			Console.Write($"すべて200ページを超えているか:");
			Console.WriteLine(books.All(b => b.Pages >= 200) ? "超えている\n" : "超えていない\n");

			var index = books.IndexOf(books.FirstOrDefault(b => b.Pages > 400));
			Console.WriteLine($"400ページを超える本は何冊目か:{index + 1}冊目です\n");

			Console.WriteLine("本の価格が400円以上:");
			books.Where(b => b.Price >= 400).Take(3).ToList().ForEach(b => Console.WriteLine(b.Title));

		}
	}
}
