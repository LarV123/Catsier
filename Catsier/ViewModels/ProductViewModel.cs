using Catsier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.ViewModels {
	class ProductViewModel : ViewModelBase{
		
		private Product produk;

		public Product Produk {
			get {
				return produk;
			}
			set {
				produk = value;
				OnPropertyChanged("Nama");
				OnPropertyChanged("Kode");
				OnPropertyChanged("Kategori");
				OnPropertyChanged("Satuan");
				OnPropertyChanged("Modal");
				OnPropertyChanged("Jual");
				OnPropertyChanged("Produk");
			}
		}

		public string Nama {
			get {
				return produk != null ? produk.Nama : "";
			}
			set {
				produk.Nama = value;
				OnPropertyChanged("Nama");
			}
		}

		public string Kode {
			get {
				return produk != null ? produk.Kode : "";
			}
			set {
				produk.Kode = value;
				OnPropertyChanged("Kode");
			}
		}

		public string Kategori {
			get {
				return produk != null ? produk.Kategori : "";
			}
			set {
				produk.Kategori = value;
				OnPropertyChanged("Kategori");
			}
		}

		public string Satuan {
			get {
				return produk != null ? produk.Satuan : "";
			}
			set {
				produk.Satuan = value;
				OnPropertyChanged("Satuan");
			}
		}

		public uint Modal {
			get {
				return produk != null ? produk.Modal : 0;
			}
			set {
				produk.Modal = value;
				OnPropertyChanged("Modal");
			}
		}

		public uint Jual {
			get {
				return produk != null ? produk.Jual : 0;
			}
			set {
				produk.Jual = value;
				OnPropertyChanged("Jual");
			}
		}

		public ProductViewModel() {

		}

		public ProductViewModel(Product produk) {
			Produk = produk;
		}

	}
}
