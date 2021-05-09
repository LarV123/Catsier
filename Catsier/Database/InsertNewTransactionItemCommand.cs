using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Database {
	class InsertNewTransactionItemCommand {

		private string commandString = @"INSERT INTO transaksi_penjualan (JUMLAH, KODE_PRODUK, NAMA_PRODUK, KATEGORI_PRODUK, SATUAN_PRODUK, HARGA_MODAL_PRODUK, HARGA_JUAL_PRODUK, NO_INVOICE) VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', {6}, {7});";
		private DBConnection dbConnection;

		public InsertNewTransactionItemCommand(DBConnection dbConnection) {
			this.dbConnection = dbConnection;
		}

		public void Execute(int noInvoice, int jumlah, string kodeProduk, string namaProduk, string kategoriProduk, string satuanProduk, long hargaModalProduk, long hargaJualProduk) {
			using (MySqlCommand command = new MySqlCommand(string.Format(commandString, jumlah, kodeProduk, namaProduk, kategoriProduk, satuanProduk, hargaModalProduk, hargaJualProduk, noInvoice), dbConnection.Connection)) {
				dbConnection.Connection.Open();
				command.ExecuteNonQuery();
				dbConnection.Connection.Close();
			}
		}

	}
}
