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
		public int Modal { get; set; }
		public int Jual { get; set; }

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
		}

		private void Create() {
			productRepository.AddProduct(new Product(Kode, Nama, Kategori, Satuan, Modal, Jual));
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
		}

		private void GoToListProduct() {
			Mediator.Invoke("Change View To Product List");
		}
	}
}
