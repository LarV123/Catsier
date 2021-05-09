using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Models {
	class TransactionRepository {

		public event Action<Transaction> OnNewTransaction = (x)=> { };

		private List<Transaction> transactions;

		public TransactionRepository() {
			transactions = new List<Transaction>();
		}

		private int invoiceNumber = 0;

		public Transaction GenerateEmptyTransaction() {
			return new Transaction(GetNextInvoiceNumber());
		}

		public void AddTransaction(Transaction transaction) {
			transactions.Add(transaction);
			OnNewTransaction(transaction);

		}

		public int GetNextInvoiceNumber() {
			return invoiceNumber;
		}

		public void SetNextInvoiceNumber(int number) {
			invoiceNumber = number;
		}

		public void UpdateData(Transaction[] transactions) {
			this.transactions.Clear();
			foreach(Transaction transaction in transactions) {
				this.transactions.Add(transaction);
			}
		}

		public Transaction[] GetTransactions() {
			return transactions.ToArray();
		}
	}
}
