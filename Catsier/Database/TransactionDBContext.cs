using Catsier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Database {
	class TransactionDBContext {

		private TransactionRepository transactionRepo;
		private DBConnection dbConnection;
		private GetNextInvoiceNumberCommand getNextInvoiceNumberCommand;
		private InsertNewTransactionCommand newTransactionCommand;
		private InsertNewTransactionItemCommand newTransactionItemCommand;
		private UpdateTransactionRepositoryCommand updateTransactionRepositoryCommand;

		public TransactionDBContext(TransactionRepository transactionRepository, DBConnection dbConnection) {
			transactionRepo = transactionRepository;
			this.dbConnection = dbConnection;
			getNextInvoiceNumberCommand = new GetNextInvoiceNumberCommand(dbConnection);
			newTransactionCommand = new InsertNewTransactionCommand(dbConnection);
			newTransactionItemCommand = new InsertNewTransactionItemCommand(dbConnection);
			updateTransactionRepositoryCommand = new UpdateTransactionRepositoryCommand(transactionRepo, dbConnection);
			transactionRepo.OnNewTransaction += CreateTransaction;
			Mediator.Subscribe("Update Next Invoice Number", UpdateNextInvoiceNumber);
			Mediator.Subscribe("Update Transaction Repository", UpdateTransactionRepository);
		}

		public void UpdateNextInvoiceNumber(object o) {
			int invoiceNumber = getNextInvoiceNumberCommand.Execute();
			transactionRepo.SetNextInvoiceNumber(invoiceNumber);
		}

		public void CreateTransaction(Transaction transaction) {
			newTransactionCommand.Execute(transaction.Invoice, transaction.Tanggal, transaction.Pelanggan, transaction.Kasir);
			foreach(TransactionItem transactionItem in transaction.items) {
				newTransactionItemCommand.Execute(transaction.Invoice, transactionItem.Jumlah, transactionItem.Product.Kode, transactionItem.Product.Nama, transactionItem.Product.Kategori, transactionItem.Product.Satuan, transactionItem.Product.Modal, transactionItem.Product.Jual);
			}
		}

		public void UpdateTransactionRepository(object o) {
			updateTransactionRepositoryCommand.Execute();
		}

	}
}
