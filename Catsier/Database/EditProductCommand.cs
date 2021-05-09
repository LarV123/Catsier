using Catsier.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Database {
	class EditProductCommand {

		private string commandString = @"UPDATE produk SET NAMA_PRODUK = '{1}', KATEGORI_PRODUK = '{2}', SATUAN_PRODUK = '{3}', HARGA_MODAL_PRODUK = {4}, HARGA_JUAL_PRODUK = {5} WHERE KODE_PRODUK = '{0}'";

		private DBConnection dbConnection;

		public EditProductCommand(DBConnection dbConnection) {
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
