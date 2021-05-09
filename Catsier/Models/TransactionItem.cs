using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Models {
	class TransactionItem {

		private Product product;

		public Product Product {
			get {
				return product;
			}
			set {
				if(value != null) {
					product = new Product(value.Kode, value.Nama, value.Kategori, value.Satuan, value.Modal, value.Jual);
				}
			}
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
				return Jumlah * product.Jual;
			}
		}

		public long TotalProfit {
			get {
				return Jumlah * (product.Jual - product.Modal);
			}
		}

	}
}
