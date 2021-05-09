using Catsier.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Database {
	class DeleteProductCommand {

		private string commandString = @"DELETE FROM produk WHERE KODE_PRODUK = '{0}';";
		private DBConnection dbConnection;

		public DeleteProductCommand(DBConnection dbConnection) {
			this.dbConnection = dbConnection;
		}

		public void Execute(Product product) {
			MySqlCommand command = new MySqlCommand(string.Format(commandString, product.Kode), dbConnection.Connection);
			dbConnection.Connection.Open();
			command.ExecuteNonQuery();
			dbConnection.Connection.Close();
		}

	}
}
