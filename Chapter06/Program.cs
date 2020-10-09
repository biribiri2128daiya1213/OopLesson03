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
			var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35, };
			//6-1-1
			Console.WriteLine("\n-----6-1-1(最大値)-----");
			Console.WriteLine(numbers.Max());

			//6-1-2
			Console.WriteLine("\n-----6-1-2(最後から2つ)-----");
			foreach (var b in numbers.Skip(numbers.Length - 2)) {
				Console.WriteLine(b);
			}
		
			//6-1-3
			Console.WriteLine("\n-----6-1-3(文字列に変換)-----");
			foreach (var b in numbers.Select(n => n.ToString())) {
				Console.WriteLine(b);
			}
			
			//6-1-4
			Console.WriteLine("\n-----6-1-4(昇順にして先頭から3つ)-----");
			foreach (var b in numbers.OrderBy(n => n).Select(n => n).Take(3)) {
				Console.WriteLine(b);
			}

			//6-1-5
			Console.WriteLine("\n-----6-1-5(一意にして10より大きい値の数)-----");
			Console.WriteLine(numbers.Distinct().Count(n => n > 10));
			

			var books = new List<Book>{
				new Book { Title = "C#プログラミングの新常識",Price = 3800,Pages = 378},
				new Book { Title = "ラムダ式とLINQの極意",Price = 2500,Pages = 312},
				new Book { Title = "ワンダフル・C#ライフ",Price = 2900,Pages = 385},
				new Book { Title = "一人で学ぶ並列処理プログラミング",Price = 4800,Pages = 464},
				new Book { Title = "フレーズで覚えるC#入門",Price = 5300,Pages = 604},
				new Book { Title = "私でも分かったASP.NET MVC",Price = 3200,Pages = 453},
				new Book { Title = "楽しいC#プログラミング教室",Price = 2540,Pages = 348},
			};

			//6-2-1
			Console.WriteLine("\n-----6-2-1(タイトルがワンダフル・C#ライフの書籍)-----");
			var book = books.Find(b => b.Title.Equals("ワンダフル・C#ライフ"));
			Console.WriteLine($"価格:{book.Price}\nページ数:{book.Pages}");


			//6-2-2
			Console.WriteLine("\n-----6-2-2(タイトルにC#が含まれる書籍の数)-----");
			Console.WriteLine(books.Count(b => b.Title.Contains("C#")));
			
			//6-2-3
			Console.WriteLine("\n-----6-2-3(タイトルにC#が含まれる書籍の平均ページ数)-----");
			Console.WriteLine(books.Where(b => b.Title.Contains("C#")).Average(b => b.Pages));
			

			//6-2-4
			Console.WriteLine("\n-----6-2-4(価格が4000円以上の最初の書籍)-----");
			var FirstBook = books.FirstOrDefault(b => b.Price >= 4000).Title;
			if (FirstBook != null) {
				Console.WriteLine(FirstBook);
			}
			

			//6-2-5
			Console.WriteLine("\n-----6-2-5(価格が4000円未満で最大ページ数)-----");
			Console.WriteLine(books.Where(b => b.Price < 4000).Max(b => b.Pages));

			//6-2-6
			Console.WriteLine("\n-----6-2-6(ページ数が400ページ以上の書籍を価格の降順で表示)-----");
			foreach (var b in books.Where(b => b.Pages >= 400).OrderByDescending(b => b.Price)) {
				Console.WriteLine($"タイトル:{b.Title} 価格:{b.Price}");
			}
			
			//6-2-7
			Console.WriteLine("\n-----6-2-7(タイトルにC#を含んでおり500ページ以下の書籍)-----");
			foreach (var b in books.Where(b => b.Title.Contains("C#") && b.Pages <= 500)) {
				Console.WriteLine($"タイトル:{b.Title}");
			}

			Console.WriteLine();
		}
	}
}
