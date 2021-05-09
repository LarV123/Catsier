using Catsier.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Catsier.ViewModels {
	class ListProductViewModel : ViewModelBase {

		public ObservableCollection<ListProductItemViewModel> productList;

		public IEnumerable<ListProductItemViewModel> ProductList {
			get {
				return productList;
			}
		}

		public ICommand BackCommand {
			get {
				return new RelayCommand(x => Mediator.Invoke("Change View To Dashboard"));
			}
		}

		private ProductRepository repo;

		public ListProductViewModel(ProductRepository repo) {
			this.repo = repo;
			repo.OnProductListChange += UpdateList;
			productList = new ObservableCollection<ListProductItemViewModel>();
			UpdateList();
		}

		private void UpdateList() {
			productList.Clear();
			Product[] products = repo.GetProducts();
			foreach (Product product in products) {
				productList.Add(new ListProductItemViewModel(product));
			}
			UpdateNumbering();
		}

		private ICommand editCommand;
		private ICommand deleteCommand;
		private ICommand createCommand;

		public ICommand EditCommand {
			get {
				return editCommand ?? (editCommand = new RelayCommand<ListProductItemViewModel>(x => Edit(x)));
			}
		}

		public ICommand DeleteCommand {
			get {
				return deleteCommand ?? (deleteCommand = new RelayCommand<ListProductItemViewModel>(x => Delete(x)));
			}
		}

		public ICommand CreateCommand {
			get {
				return createCommand ?? (createCommand = new RelayCommand(x => GoToCreateProduct()));
			}
		}

		private void Edit(ListProductItemViewModel viewModel) {
			MessageBox.Show("Editing " + viewModel.Kode);
		}

		private void Delete(ListProductItemViewModel viewModel) {
			repo.RemoveProduct(viewModel.Kode);
		}

		private void UpdateNumbering() {
			for(int i = 0; i < productList.Count; i++) {
				productList[i].No = i + 1;
			}
		}

		private void GoToCreateProduct() {
			Mediator.Invoke("Change View To Create Product");
		}
	}
}
