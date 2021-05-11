using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Models {
	class Product {
		public string Kode { get; set; }
		public string Nama { get; set; }
		public string Kategori { get; set; }
		public string Satuan { get; set; }
		public uint Modal { get; set; }
		public uint Jual { get; set; }
		public Product(string kode, string nama, string kategori, string satuan, uint modal, uint jual) {
			Kode = kode;
			Nama = nama;
			Kategori = kategori;
			Satuan = satuan;
			Modal = modal;
			Jual = jual;
		}
		public uint Profit {
			get {
				return Jual - Modal;
			}
		}
	}
}
