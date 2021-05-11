using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Models {
	class TransactionRepository {

		private List<Transaction> transactions;

		public TransactionRepository() {
			transactions = new List<Transaction>();
		}

		private int invoiceNumber = 100000;

		public Transaction GenerateEmptyTransaction() {
			return new Transaction(invoiceNumber);
		}

		public void AddTransaction(Transaction transaction) {
			transactions.Add(transaction);
			invoiceNumber++;
		}

		public Transaction[] GetTransactions() {
			return transactions.ToArray();
		}
	}
}
