using Catsier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.ViewModels {
	class AddProductViewModel : ViewModelBase{

		private Product product; 

		public Product Product {
			get {
				return product;
			}
			set {
				product = value;
				Jumlah = 1;
				OnPropertyChanged("Nama");
				OnPropertyChanged("Harga");
				OnPropertyChanged("Total");
			}
		}

		public string Nama {
			get {
				return product.Nama;
			}
		}

		public int Harga {
			get {
				return product.Jual;
			}
		}

		private int jumlah;

		public int Jumlah {
			get {
				return jumlah;
			}
			set {
				jumlah = value;
				OnPropertyChanged("Jumlah");
				OnPropertyChanged("Total");
			}
		}

		public int Total {
			get {
				return Jumlah * Harga;
			}
		}

		public AddProductViewModel(Product product) {
			this.product = product;
		}
	}
}
