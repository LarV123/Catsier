using Catsier.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Catsier.ViewModels {
	class MainWindowViewModel : ViewModelBase {
        private ICommand gotoLoginView;
        private object currentView;
        private object startingView;
        private object loginView;
        private object dashboardView;
        private object profileView;
        private object listProdukView;
        private object createProductView;
        private object createTransactionView;
        private ProductRepository productRepo;
        private TransactionRepository transactionRepo;

        public MainWindowViewModel() {
            productRepo = new ProductRepository();
            transactionRepo = new TransactionRepository();
            startingView = new StartingViewModel();
            loginView = new LoginViewModel();
            dashboardView = new DashboardViewModel();
            profileView = new UserProfileViewModel();
            listProdukView = new ListProductViewModel(productRepo);
            createProductView = new CreateProductViewModel(productRepo);
            createTransactionView = new CreateTransactionViewModel(transactionRepo, productRepo);
            Mediator.Subscribe("Change View To Dashboard", GoToDasboard);
            Mediator.Subscribe("Change View To Profile", GoToProfile);
            Mediator.Subscribe("Change View To Product List", GoToProductList);
            Mediator.Subscribe("Change View To Create Product", GoToCreateProduct);
            Mediator.Subscribe("Change View To Create Transaction", GoToCreateTransaction);
            CurrentView = startingView;
        }

        public object CurrentView {
            get { return currentView; }
            set {
                currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }

        public ICommand GoToLoginViewCommand {
            get {
                return gotoLoginView ?? (gotoLoginView = new RelayCommand(
                   x => {
                       GoToLoginView();
                   }));
            }
        }

        private void GoToLoginView() {
            CurrentView = loginView;
        }

        private void GoToDasboard() {
            CurrentView = dashboardView;
		}

        private void GoToProfile() {
            CurrentView = profileView;
		}

        private void GoToProductList() {
            CurrentView = listProdukView;
		}

        private void GoToCreateProduct() {
            CurrentView = createProductView;
		}

        private void GoToCreateTransaction() {
            CurrentView = createTransactionView;
		}
    }
}
