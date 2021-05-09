using Catsier.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Database {
	class UpdateTransactionRepositoryCommand {

		private string commandTransactionListString = @"SELECT * FROM invoice_pembelian;";
		private MySqlCommand commandTransactionList;
		private string commandTransactionItemString = @"SELECT * FROM transaksi_penjualan WHERE NO_INVOICE = {0};";
		private DBConnection dbConnection;
		private TransactionRepository transactionRepo;
		List<Transaction> transactions;

		public UpdateTransactionRepositoryCommand(TransactionRepository transactionRepo, DBConnection dbConnection) {
			this.transactionRepo = transactionRepo;
			this.dbConnection = dbConnection;
			transactions = new List<Transaction>();
			commandTransactionList = new MySqlCommand(commandTransactionListString, dbConnection.Connection);
		}

		public void Execute() {
			transactions.Clear();
			dbConnection.Connection.Open();
			MySqlDataReader transactionReader = commandTransactionList.ExecuteReader();
			while (transactionReader.Read()) {
				Transaction transaction = new Transaction((int)transactionReader[0]);
				transaction.Tanggal = (DateTime)transactionReader[1];
				transaction.Pelanggan = (string)transactionReader[2];
				transaction.Kasir = (string)transactionReader[3];
				using(MySqlConnection connection = dbConnection.Connection.Clone()) {
					connection.Open();
					using (MySqlCommand commandTransactionItem = new MySqlCommand(string.Format(commandTransactionItemString, transaction.Invoice), connection)) {
						using (MySqlDataReader reader = commandTransactionItem.ExecuteReader()) {
							while (reader.Read()) {
								transaction.Add(new TransactionItem(new Product((string)reader[2], (string)reader[3], (string)reader[4], (string)reader[5], (uint)(long)reader[6], (uint)(long)reader[7]), (int)reader[1]));
							}
						}
					}
					connection.Close();
				}
				transactions.Add(transaction);
			}
			dbConnection.Connection.Close();
			transactionRepo.UpdateData(transactions.ToArray());
		}

	}
}
