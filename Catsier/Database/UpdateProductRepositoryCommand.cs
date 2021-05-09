using Catsier.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Database {
	class UpdateProductRepositoryCommand {
		private MySqlCommand command;
		private DBConnection dbConnection;
		private ProductRepository productRepo;
		private string commandString = @"SELECT KODE_PRODUK, NAMA_PRODUK, KATEGORI_PRODUK, SATUAN_PRODUK, HARGA_MODAL_PRODUK, HARGA_JUAL_PRODUK FROM produk;";

		private List<string> kode;
		private List<string> nama;
		private List<string> kategori;
		private List<string> satuan;
		private List<long> modal;
		private List<long> jual;

		public UpdateProductRepositoryCommand(ProductRepository productRepo, DBConnection dbConnection) {
			this.productRepo = productRepo;
			this.dbConnection = dbConnection;
			command = new MySqlCommand(commandString, dbConnection.Connection);
			kode = new List<string>();
			nama = new List<string>();
			kategori = new List<string>();
			satuan = new List<string>();
			modal = new List<long>();
			jual = new List<long>();
		}

		public void Execute() {
			kode.Clear();
			nama.Clear();
			kategori.Clear();
			satuan.Clear();
			modal.Clear();
			jual.Clear();
			dbConnection.Connection.Open();
			MySqlDataReader reader = command.ExecuteReader();
			while (reader.Read()) {
				kode.Add((string)reader["KODE_PRODUK"]);
				nama.Add((string)reader["NAMA_PRODUK"]);
				kategori.Add((string)reader["KATEGORI_PRODUK"]);
				satuan.Add((string)reader["SATUAN_PRODUK"]);
				modal.Add((long)reader["HARGA_MODAL_PRODUK"]);
				jual.Add((long)reader["HARGA_JUAL_PRODUK"]);
			}
			reader.Close();
			dbConnection.Connection.Close();
			productRepo.UpdateData(kode.ToArray(), nama.ToArray(), kategori.ToArray(), satuan.ToArray(), modal.ToArray(), jual.ToArray());
		}
	}
}