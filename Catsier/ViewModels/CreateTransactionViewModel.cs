using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Catsier.Models;
using System.Windows.Input;

namespace Catsier.ViewModels {
	class CreateTransactionViewModel : ViewModelBase{

		public TransactionViewModel TransactionViewModel { get; set; }
		public TransactionItemViewModel TransactionItemViewModel { get; set; }

		private string kode;

		public string KodeProduk {
			get {
				return kode;
			}
			set {
				kode = value;
				OnPropertyChanged("KodeProduk");
			}
		}

		public string Kasir {
			get {
				TransactionViewModel.Kasir = Auth.Instance.LoggedUser.Name;
				return Auth.Instance.LoggedUser.Name;
			}
		}

		#region Commands

		private ICommand buatTransaksiCommand;

		public ICommand BuatTransaksiCommand {
			get {
				return buatTransaksiCommand ?? (buatTransaksiCommand = new RelayCommand(x => BuatTransaksi()));
			}
		}

		private ICommand batalkanTransaksiCommand;

		public ICommand BatalkanTransaksiCommand {
			get {
				return batalkanTransaksiCommand ?? (batalkanTransaksiCommand = new RelayCommand(x => BatalkanTransaksi()));
			}
		}

		private ICommand hapusProdukCommand;

		public ICommand HapusProdukCommand {
			get {
				return hapusProdukCommand ?? (hapusProdukCommand = new RelayCommand<ListProductItemViewModel>(x => HapusProduk(x)));
			}
		}

		private ICommand backCommand;

		public ICommand BackCommand {
			get {
				return backCommand ?? (backCommand = new RelayCommand(x => {
					Mediator.Invoke("Change View To Dashboard");
				}));
			}
		}

		private ICommand cariProdukCommand;

		public ICommand CariProdukCommand {
			get {
				return cariProdukCommand ?? (cariProdukCommand = new RelayCommand(x => CariProduk()));
			}
		}

		private ICommand tambahProdukCommand;

		public ICommand TambahProdukCommand {
			get {
				return tambahProdukCommand ?? (tambahProdukCommand = new RelayCommand(x => TambahProduk()));
			}
		}

		#endregion

		private ObservableCollection<ListProductItemViewModel> itemList = new ObservableCollection<ListProductItemViewModel>();
		private TransactionRepository transactionRepo;
		private ProductRepository productRepo;

		public CreateTransactionViewModel(TransactionRepository transactionRepo, ProductRepository productRepo) {
			this.transactionRepo = transactionRepo;
			this.productRepo = productRepo;
			TransactionItemViewModel = new TransactionItemViewModel();
			TransactionViewModel = new TransactionViewModel();
			TransactionViewModel.Transaction = transactionRepo.GenerateEmptyTransaction();
		}

		private void CariProduk() {
			TransactionItemViewModel.ProductViewModel.Product = productRepo.FindByCode(kode);
		}

		private void BuatTransaksi() {

		}

		private void BatalkanTransaksi() {

		}

		private void HapusProduk(ListProductItemViewModel model) {
			
		}

		private void TambahProduk() {

		}

	}
}
