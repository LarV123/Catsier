using Catsier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.ViewModels {
	class ListProductItemViewModel : ViewModelBase {
		private int no;
		private Product product;
		public int No {
			get {
				return no;
			}
			set {
				no = value;
				OnPropertyChanged("No");
			}
		}
		public string Kode {
			get {
				return product.Kode;
			}
		}
		public string Nama { 
			get {
				return product.Nama;
			} 
		}
		public string Kategori {
			get {
				return product.Kategori;
			}
		}
		public string Satuan {
			get {
				return product.Satuan;
			}
		}
		public int Modal {
			get {
				return product.Modal;
			}
		}
		public int Jual {
			get {
				return product.Jual;
			}
		}

		public ListProductItemViewModel(Product product) {
			this.product = product;
		}
	}
}
