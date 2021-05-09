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
			set {
				invoice = value;
			}
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
			Tanggal = DateTime.Now;
			Pelanggan = "";
		}

		public void Add(Product product, int jumlah) {
			items.Add(new TransactionItem(product, jumlah));
		}

		public void Add(TransactionItem transactionItem) {
			items.Add(transactionItem);
		}

		public void Remove(TransactionItem transaksiItem) {
			items.Remove(transaksiItem);
		}

	}
}
