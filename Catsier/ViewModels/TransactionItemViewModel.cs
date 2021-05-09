using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Catsier.ViewModels {
	class TransactionItemViewModel : ViewModelBase{

		public ProductViewModel ProductViewModel { get; set; }

		public TransactionItemViewModel() {
			ProductViewModel = new ProductViewModel();
			ProductViewModel.PropertyChanged += OnProductViewModelChange;
		}

		public void OnProductViewModelChange(object sender, PropertyChangedEventArgs args) {
			if(args.PropertyName == "Jual") {
				OnPropertyChanged("Total");
			}
		}

		private int jumlah;

		public int Jumlah {
			get {
				return jumlah;
			}
			set {
				jumlah = value;
				OnPropertyChanged("Jumlah");
				OnPropertyChanged("Total");
			}
		}

		public int Total {
			get {
				return Jumlah * ProductViewModel.Jual;
			}
		}
	}
}
