using Catsier.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Catsier.ViewModels {
	class TransactionItemViewModel : ViewModelBase{

		public ProductViewModel ProductViewModel { get; set; }

		private TransactionItem transactionItem;

		public TransactionItem TransactionItem {
			get {
				return transactionItem;
			}
			set {
				transactionItem = value;
				ProductViewModel.Produk = transactionItem.Product;
			}
		}

		public TransactionItemViewModel() {
			ProductViewModel = new ProductViewModel();
			ProductViewModel.PropertyChanged += OnProductViewModelChange;
			transactionItem = new TransactionItem();
		}

		public TransactionItemViewModel(TransactionItem item) {
			transactionItem = item;
			ProductViewModel = new ProductViewModel(item.Product);
			ProductViewModel.PropertyChanged += OnProductViewModelChange;
		}

		public void OnProductViewModelChange(object sender, PropertyChangedEventArgs args) {
			if(args.PropertyName == "Jual") {
				OnPropertyChanged("Total");
			}else if(args.PropertyName == "Produk") {
				transactionItem.Product = ProductViewModel.Produk;
			}
		}

		public int Jumlah {
			get {
				return transactionItem.Jumlah;
			}
			set {
				transactionItem.Jumlah = value;
				OnPropertyChanged("Jumlah");
				OnPropertyChanged("Total");
			}
		}

		public long Total {
			get {
				return Jumlah * ProductViewModel.Jual;
			}
		}
	}
}
