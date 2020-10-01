using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter04 {
	class Program {
		static void Main(string[] args) {
			string code = "12345";

			var message = GetMessage(code) ?? DefaultMessage();
			Console.WriteLine(message);
		}
		//スタブ
		private static object DefaultMessage() {
			return "DefaultMessage";
		}
		//スタブ
		private static object GetMessage(string code) {
			return code;
		}
	}
}
