using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Models {
	class TransactionItem {

		public Product Product {
			get;
			set;
		}

		public int Jumlah {
			get;
			set;
		}

		public TransactionItem() { Jumlah = 1; }

		public TransactionItem(Product product, int jumlah) {
			Product = product;
			Jumlah = jumlah;
		}

		public long Total {
			get {
				return Jumlah * Product.Jual;
			}
		}

		public long TotalProfit {
			get {
				return Jumlah * Product.Profit;
			}
		}

	}
}
