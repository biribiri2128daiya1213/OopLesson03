﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3 {
	class Program {
		static void Main(string[] args) {
			var numbers = new List<int> {
				12,87,94,14,53,20,40,35,76,91,31,17,48,
			};

			var list = new List<int>();
			var nums = numbers.Select(n => n * 2);

			foreach (var n in nums) {
				list.Add(n);
			}

			foreach (var n in list) {
				Console.WriteLine(n);
			}
		}
	}
}