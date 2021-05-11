using Catsier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.ViewModels {
	class TransactionHistoryItemViewModel : ViewModelBase{

		public TransactionViewModel TransactionViewModel { get; set; }

		private int no;

		public int No {
			get {
				return no;
			}
			set {
				no = value;
				OnPropertyChanged("No");
			}
		}

		public TransactionHistoryItemViewModel(Transaction transaction) {
			TransactionViewModel = new TransactionViewModel(transaction);
		}

	}
}
