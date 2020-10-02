using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3 {
	class YearMonth {
		//プロパティ
		public int Year { get; private set; }
		public int Month { get; private set; }

		public bool IsCentury {
			get {
				return (2001 <= Year && Year <= 2100);
			}
		}

		//コンストラクタ
		public YearMonth(int Year, int Month) {
			this.Year = Year;
			this.Month = Month;
		}

		public YearMonth AddOneMonth() {
			if (Month == 12) {
				return new YearMonth(Year + 1, 1);
			} else {
				return new YearMonth(Year, Month + 1);
			}
		}

		public override string ToString() {
			return $"{Year}年{Month}月";
		}
	}
}
