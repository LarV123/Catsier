using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Models {
	class Transaction {

		public string Kasir {
			get;
			set;
		}

		public DateTime Tanggal {
			get;
			set;
		}

		private int invoice;

		public int Invoice {
			get{
				return invoice;
			}
		}

		public string Pelanggan {
			get;
			set;
		}

		public List<TransactionItem> items;

		public Transaction(int invoice) {
			items = new List<TransactionItem>();
			this.invoice = invoice;
		}

		public void Add(Product product, int jumlah) {
			items.Add(new TransactionItem(product, jumlah));
		}

		public void Remove(TransactionItem transaksiItem) {
			items.Remove(transaksiItem);
		}

	}
}
