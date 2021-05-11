using Catsier.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Catsier.ViewModels {
	class CreateProductViewModel : ViewModelBase{

		public string Kode { get; set; }
		public string Nama { get; set; }
		public string Satuan { get; set; }
		public string Kategori { get; set; }
		public uint Modal { get; set; }
		public uint Jual { get; set; }

		private ICommand backCommand;

		public ICommand BackCommand {
			get {
				return backCommand ?? (backCommand = new RelayCommand(x => GoToListProduct()));
			}
		}

		private ICommand createCommand;

		public ICommand CreateCommand {
			get {
				return createCommand ?? (createCommand = new RelayCommand(x => Create()));
			}
		}

		private ProductRepository productRepository;

		public CreateProductViewModel(ProductRepository productRepo) {
			productRepository = productRepo;
			Kode = "";
			Nama = "";
			Satuan = "";
			Kategori = "";
			Modal = 0;
			Jual = 0;
		}

		private void Create() {
			if(Kode == "") {
				MessageBox.Show("Kode Produk tidak dapat kosong", "Required Field", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			if (Nama == "") {
				MessageBox.Show("Nama Produk tidak dapat kosong", "Required Field", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			if (Satuan == "") {
				MessageBox.Show("Satuan Produk tidak dapat kosong", "Required Field", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			if (Kategori == "") {
				MessageBox.Show("Kategori Produk tidak dapat kosong", "Required Field", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			bool isSuccesful = productRepository.AddProduct(new Product(Kode, Nama, Kategori, Satuan, Modal, Jual));
			if (!isSuccesful) {
				MessageBox.Show("Terdapat duplikat kode produk", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			Kode = "";
			Nama = "";
			Satuan = "";
			Kategori = "";
			Modal = 0;
			Jual = 0;
			OnPropertyChanged("Kode");
			OnPropertyChanged("Nama");
			OnPropertyChanged("Satuan");
			OnPropertyChanged("Kategori");
			OnPropertyChanged("Modal");
			OnPropertyChanged("Jual");
			MessageBox.Show("Produk sudah disimpan", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		private void GoToListProduct() {
			Mediator.Invoke("Change View To Product List");
		}
	}
}
