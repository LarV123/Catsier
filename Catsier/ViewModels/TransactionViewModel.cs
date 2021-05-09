using System;
using System.Collections.Generic;
using System.Text;
using Catsier.Models;

namespace Catsier.ViewModels {
	class TransactionViewModel : ViewModelBase {

		private Transaction transaction;

		public Transaction Transaction {
			get {
				return transaction;
			}
			set {
				transaction = value;
				OnPropertyChanged("Kasir");
				OnPropertyChanged("Tanggal");
				OnPropertyChanged("Pelanggan");
				OnPropertyChanged("Invoice");
			}
		}

		public string Kasir {
			get {
				return transaction.Kasir;
			}
			set {
				transaction.Kasir = value;
				OnPropertyChanged("Kasir");
			}
		}

		public DateTime Tanggal {
			get {
				return transaction.Tanggal;
			}
			set {
				transaction.Tanggal = value;
				OnPropertyChanged("Tanggal");
			}
		}

		public string Pelanggan {
			get {
				return transaction.Pelanggan;
			}
			set {
				transaction.Pelanggan = value;
				OnPropertyChanged("Pelanggan");
			}
		}

		public int Invoice {
			get {
				return transaction.Invoice;
			}
		}

		
	}
}
