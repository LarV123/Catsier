using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Database {
	class GetNextInvoiceNumberCommand {

		private string commandString = @"SELECT COUNT(*) FROM invoice_pembelian;";
		private MySqlCommand command;
		private DBConnection dbConnection;

		public GetNextInvoiceNumberCommand(DBConnection dbConnection) {
			this.dbConnection = dbConnection;
			command = new MySqlCommand(commandString, dbConnection.Connection);
		}

		public int Execute() {
			dbConnection.Connection.Open();
			int count = (int)(long)command.ExecuteScalar() + 1;
			dbConnection.Connection.Close();
			return count;
		}

	}
}
