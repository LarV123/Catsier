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

		public TransactionItem(Product product, int jumlah) {
			Product = product;
			Jumlah = jumlah;
		}

	}
}
