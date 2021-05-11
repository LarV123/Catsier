using Catsier.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Catsier.ViewModels {
	class TransactionHistoryViewModel {

		private ObservableCollection<TransactionHistoryItemViewModel> transactionHistory;

		public ObservableCollection<TransactionHistoryItemViewModel> TransactionHistory {
			get {
				return transactionHistory;
			}
		}

		public TransactionHistoryViewModel() {
			transactionHistory = new ObservableCollection<TransactionHistoryItemViewModel>();
		}

		public void SetData(TransactionRepository transactionRepository) {
			transactionHistory.Clear();
			Transaction[] transactions = transactionRepository.GetTransactions();
			foreach (Transaction transaction in transactions) {
				transactionHistory.Add(new TransactionHistoryItemViewModel(transaction));
			}
			UpdateNumbering();
		}

		private void UpdateNumbering() {
			for(int i = 0; i < transactionHistory.Count; i++) {
				transactionHistory[i].No = i + 1;
			}
		}

		public ICommand BackCommand {
			get {
				return new RelayCommand(x => Mediator.Invoke("Change View To Dashboard", null));
			}
		}

	}
}
