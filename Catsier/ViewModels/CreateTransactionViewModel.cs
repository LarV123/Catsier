using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Catsier.Models;
using System.Windows.Input;
using System.Windows;

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
				return hapusProdukCommand ?? (hapusProdukCommand = new RelayCommand<TransactionItemViewModel>(x => HapusProduk(x)));
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
			Mediator.Invoke("Update Product Data");
			TransactionItemViewModel.ProductViewModel.Produk = productRepo.FindByCode(kode);
			if(TransactionItemViewModel.ProductViewModel.Produk == null) {
				MessageBox.Show("Produk tidak ditemukan", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			KodeProduk = "";
		}

		private void BuatTransaksi() {
			if(TransactionViewModel.Pelanggan == "") {
				MessageBox.Show("Nama pelanggan kosong", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			if(TransactionViewModel.Total == 0) {
				MessageBox.Show("Tidak ada pembelian apapun", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			Mediator.Invoke("Update Next Invoice Number");
			UpdateInvoiceNumber();
			transactionRepo.AddTransaction(TransactionViewModel.Transaction);
			TransactionViewModel.Transaction = transactionRepo.GenerateEmptyTransaction();
			TransactionViewModel.Kasir = Auth.Instance.LoggedUser.Name;
			MessageBox.Show("Transaksi disimpan", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
			Mediator.Invoke("Update Next Invoice Number");
			UpdateInvoiceNumber();
		}

		private void BatalkanTransaksi() {
			var res = MessageBox.Show("Apakah kamu yakin ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if(res == MessageBoxResult.No) {
				return;
			}
			TransactionViewModel.Transaction = transactionRepo.GenerateEmptyTransaction();
			TransactionViewModel.Kasir = Auth.Instance.LoggedUser.Name;
		}

		private void HapusProduk(TransactionItemViewModel model) {
			TransactionViewModel.RemoveTransactionItem(model);
		}

		private void TambahProduk() {
			if(TransactionItemViewModel.ProductViewModel.Produk == null) {
				MessageBox.Show("Cari produk terlebih dahulu", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}
			TransactionViewModel.AddTransactionItem(TransactionItemViewModel.TransactionItem);
			TransactionItemViewModel.TransactionItem = new TransactionItem();
			OnPropertyChanged("TransactionItemViewModel");
		}

		public void UpdateInvoiceNumber() {
			TransactionViewModel.Invoice = transactionRepo.GetNextInvoiceNumber();
		}

	}
}
