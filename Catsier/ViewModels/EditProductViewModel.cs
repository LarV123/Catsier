using Catsier.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Catsier.ViewModels {
	class EditProductViewModel : ViewModelBase {

		private Product produk;
		public Product Produk {
			get {
				return produk;
			}
			set {
				produk = value;
				OnPropertyChanged("Kode");
				Nama = produk.Nama;
				Kategori = produk.Kategori;
				Satuan = produk.Satuan;
				Modal = produk.Modal;
				Jual = produk.Jual;
			}
		}

		public string Kode {
			get {
				return produk.Kode;
			}
		}

		private string nama;
		private string satuan;
		private string kategori;
		private uint modal;
		private uint jual;

		public string Nama {
			get {
				return nama;
			}
			set {
				nama = value;
				OnPropertyChanged("Nama");
			}
		}

		public string Satuan {
			get {
				return satuan;
			}
			set {
				satuan = value;
				OnPropertyChanged("Satuan");
			}
		}

		public string Kategori {
			get {
				return kategori;
			}
			set {
				kategori = value;
				OnPropertyChanged("Kategori");
			}
		}

		public uint Modal {
			get {
				return modal;
			}
			set {
				modal = value;
				OnPropertyChanged("Modal");
			}
		}

		public uint Jual {
			get {
				return jual;
			}
			set {
				jual = value;
				OnPropertyChanged("Jual");
			}
		}

		private ICommand simpanCommand;

		public ICommand SimpanCommand {
			get {
				return simpanCommand ?? (simpanCommand = new RelayCommand(x => Simpan()));
			}
		}

		private ICommand backCommand;

		public ICommand BackCommand {
			get {
				return backCommand ?? (backCommand = new RelayCommand(x => GoToListProduct()));
			}
		}

		private void GoToListProduct() {
			Mediator.Invoke("Change View To Product List");
		}

		private void Simpan() {
			if (Kode == "") {
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
			produk.Nama = nama;
			produk.Satuan = satuan;
			produk.Kategori = kategori;
			produk.Modal = modal;
			produk.Jual = jual;
			Mediator.Invoke("Update Product", produk);
			MessageBox.Show("Produk sudah disimpan", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
		}

	}
}
