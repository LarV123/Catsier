using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Database {
	class AddNewProductCommand {

		private string commandString = @"INSERT INTO produk (KODE_PRODUK, NAMA_PRODUK, KATEGORI_PRODUK, SATUAN_PRODUK, HARGA_MODAL_PRODUK, HARGA_JUAL_PRODUK) VALUES ('{0}', '{1}', '{2}', '{3}', {4}, {5});";

		private DBConnection dbConnection;

		public AddNewProductCommand(DBConnection dbConnection) {
			this.dbConnection = dbConnection;
		}

		public void Execute(string kode, string nama, string kategori, string satuan, long modal, long jual) {
			MySqlCommand command = new MySqlCommand(string.Format(commandString, kode, nama, kategori, satuan, modal, jual), dbConnection.Connection);
			dbConnection.Connection.Open();
			command.ExecuteNonQuery();
			dbConnection.Connection.Close();
		}

	}
}
