using Catsier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.ViewModels {
	class ProductViewModel : ViewModelBase{
		
		private Product product;

		public Product Product {
			get {
				return product;
			}
			set {
				product = value;
				OnPropertyChanged("Nama");
				OnPropertyChanged("Kode");
				OnPropertyChanged("Kategori");
				OnPropertyChanged("Satuan");
				OnPropertyChanged("Modal");
				OnPropertyChanged("Jual");
			}
		}

		public string Nama {
			get {
				return product != null ? product.Nama : "";
			}
			set {
				product.Nama = value;
				OnPropertyChanged("Nama");
			}
		}

		public string Kode {
			get {
				return product != null ? product.Kode : "";
			}
			set {
				product.Kode = value;
				OnPropertyChanged("Kode");
			}
		}

		public string Kategori {
			get {
				return product != null ? product.Kategori : "";
			}
			set {
				product.Kategori = value;
				OnPropertyChanged("Kategori");
			}
		}

		public string Satuan {
			get {
				return product != null ? product.Satuan : "";
			}
			set {
				product.Satuan = value;
				OnPropertyChanged("Satuan");
			}
		}

		public int Modal {
			get {
				return product != null ? product.Modal : 0;
			}
			set {
				product.Modal = value;
				OnPropertyChanged("Modal");
			}
		}

		public int Jual {
			get {
				return product != null ? product.Jual : 0;
			}
			set {
				product.Jual = value;
				OnPropertyChanged("Jual");
			}
		}

	}
}
