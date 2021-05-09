using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
				Items.Clear();
				foreach (TransactionItem transactionItem in transaction.items) {
					Items.Add(new TransactionItemViewModel(transactionItem));
				}
				OnPropertyChanged("Items");
				OnPropertyChanged("Total");
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
			set {
				transaction.Invoice = value;
			}
			get {
				return transaction.Invoice;
			}
		}

		public long Total {
			get {
				long total = 0;
				foreach (TransactionItemViewModel item in Items) {
					total += item.Total;
				}
				return total;
			}
		}

		public ObservableCollection<TransactionItemViewModel> Items {
			get;
			set;
		}

		public TransactionViewModel() {
			Items = new ObservableCollection<TransactionItemViewModel>();
		}

		public TransactionViewModel(Transaction transaction) {
			Items = new ObservableCollection<TransactionItemViewModel>();
			Transaction = transaction;
		}

		public void AddTransactionItem(TransactionItem item) {
			Items.Add(new TransactionItemViewModel(item));
			transaction.Add(item);
			OnPropertyChanged("Items");
			OnPropertyChanged("Total");
		}

		public void RemoveTransactionItem(TransactionItemViewModel item) {
			Items.Remove(item);
			transaction.Remove(item.TransactionItem);
			OnPropertyChanged("Items");
			OnPropertyChanged("Total");
		}
		
	}
}
