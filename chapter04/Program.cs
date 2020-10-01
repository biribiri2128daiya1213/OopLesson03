using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace chapter04 {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine(GetProduct());
		}

		private static string GetProduct() {
			Sale sale = new Sale {
				ShopName = "pet store",
				Amount = 100000,
				Product = "food",
			};
			sale = null;
			return sale?.Product;
		}
	}

	class Sale {
		//店舗名
		public string ShopName { get; set; }
		//売上高
		public int Amount { get; set; }
		public string Product { get; set; }

	}
}
