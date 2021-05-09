using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Database {
	class DatabaseInitializer {

		private DBConnection connection;
		private string commandString = @"CREATE TABLE IF NOT EXISTS KASIR (
   KASIR_ID INT AUTO_INCREMENT PRIMARY KEY,
   NAME VARCHAR(50),
   EMAIL VARCHAR(50),
   PASSWORD CHAR(64)
);
CREATE TABLE IF NOT EXISTS PRODUK(
	PRODUK_ID INT AUTO_INCREMENT PRIMARY KEY,
	KODE_PRODUK VARCHAR(20) UNIQUE,
    NAMA_PRODUK VARCHAR(50),
    KATEGORI_PRODUK VARCHAR(50),
    SATUAN_PRODUK VARCHAR(50),
    HARGA_MODAL_PRODUK BIGINT,
	HARGA_JUAL_PRODUK BIGINT
);
CREATE TABLE IF NOT EXISTS INVOICE_PEMBELIAN(
	NO_INVOICE INT,
	TANGGAL DATE,
	NAMA_PELANGGAN VARCHAR(50),
    NAMA_KASIR VARCHAR(50),
	PRIMARY KEY (NO_INVOICE)
);
CREATE TABLE IF NOT EXISTS TRANSAKSI_PENJUALAN(
	TRANSAKSI_ID INT AUTO_INCREMENT PRIMARY KEY,
	JUMLAH INT,
	KODE_PRODUK VARCHAR(20),
	NAMA_PRODUK VARCHAR(50),
	KATEGORI_PRODUK VARCHAR(50),
	SATUAN_PRODUK VARCHAR(50),
	HARGA_MODAL_PRODUK BIGINT,
	HARGA_JUAL_PRODUK BIGINT,
	NO_INVOICE INT,
	FOREIGN KEY(NO_INVOICE) REFERENCES INVOICE_PEMBELIAN (NO_INVOICE)
);";

		private MySqlCommand command;

		public DatabaseInitializer(DBConnection connection) {
			this.connection = connection;
			command = new MySqlCommand(commandString, connection.Connection);
		}

		public void Initialize() {
			connection.Connection.Open();
			command.ExecuteNonQuery();
			connection.Connection.Close();
		}

	}
}
