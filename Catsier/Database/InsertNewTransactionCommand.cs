using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Database {
	class InsertNewTransactionCommand {

		private string commandString = @"INSERT INTO invoice_pembelian (NO_INVOICE, TANGGAL, NAMA_PELANGGAN, NAMA_KASIR) VALUES ({0}, '{1}', '{2}', '{3}');";
		private DBConnection dbConnection;

		public InsertNewTransactionCommand(DBConnection dbConnection) {
			this.dbConnection = dbConnection;
		}

		public void Execute(int noInvoice, DateTime tanggal, string namaPelanggan, string namaKasir) {
			using (MySqlCommand command = new MySqlCommand(string.Format(commandString, noInvoice, tanggal.ToString("yyyy-MM-dd"), namaPelanggan, namaKasir), dbConnection.Connection)) {
				dbConnection.Connection.Open();
				command.ExecuteNonQuery();
				dbConnection.Connection.Close();
			}
		}

	}
}
