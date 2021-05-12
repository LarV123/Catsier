using Catsier.Database;
using Catsier.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Catsier.ViewModels {
	class MainWindowViewModel : ViewModelBase {
        private ICommand gotoLoginView;
        private ICommand gotoRegisterView;
        private object currentView;
        private object startingView;
        private object loginView;
        private object dashboardView;
        private object profileView;
        private object listProdukView;
        private object createProductView;
        private object createTransactionView;
        private object editProductView;
        private object transactionHistoryView;
        private object registerView;
        private object salesRecapView;
        private ProductRepository productRepo;
        private TransactionRepository transactionRepo;
        private UserRepository userRepo;

        //Database
        private DBConnection dbConnection;
        private UserDBContext userDBContext;

        public MainWindowViewModel() {
            dbConnection = new DBConnection();
            productRepo = new ProductRepository();
            transactionRepo = new TransactionRepository();
            userRepo = new UserRepository();

            userDBContext = new UserDBContext(userRepo, dbConnection);

            Auth.CreateInstance(userRepo);
            startingView = new StartingViewModel();
            loginView = new LoginViewModel();
            dashboardView = new DashboardViewModel();
            profileView = new UserProfileViewModel();
            listProdukView = new ListProductViewModel(productRepo);
            createProductView = new CreateProductViewModel(productRepo);
            createTransactionView = new CreateTransactionViewModel(transactionRepo, productRepo);
            editProductView = new EditProductViewModel();
            transactionHistoryView = new TransactionHistoryViewModel();
            registerView = new RegisterViewModel(userRepo);
            salesRecapView = new SalesRecapViewModel();
            Mediator.Subscribe("Change View To Start", GoToStart);
            Mediator.Subscribe("Change View To Dashboard", GoToDasboard);
            Mediator.Subscribe("Change View To Profile", GoToProfile);
            Mediator.Subscribe("Change View To Product List", GoToProductList);
            Mediator.Subscribe("Change View To Create Product", GoToCreateProduct);
            Mediator.Subscribe("Change View To Create Transaction", GoToCreateTransaction);
            Mediator.Subscribe("Change View To Edit Product", GoToEditProduct);
            Mediator.Subscribe("Change View To Transaction History", GoToTransactionHistory);
            Mediator.Subscribe("Change View To Sales Recap", GoToSalesRecap);
            Mediator.Subscribe("Update User Data", UpdateUserData);
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

        public ICommand GoToRegisterViewCommand {
			get {
                return gotoRegisterView ?? (gotoRegisterView = new RelayCommand(x => GoToRegister())); 
			}
		}

        private void GoToStart(object o) {
            CurrentView = startingView;
		}

        private void GoToLoginView() {
            Mediator.Invoke("Update User Data");
            CurrentView = loginView;
        }

        private void GoToRegister() {
            CurrentView = registerView;
        }

        private void GoToDasboard(object o) {
            CurrentView = dashboardView;
		}

        private void GoToProfile(object o) {
            CurrentView = profileView;
		}

        private void GoToProductList(object o) {
            CurrentView = listProdukView;
		}

        private void GoToCreateProduct(object o) {
            CurrentView = createProductView;
        }

        private void GoToEditProduct(object o) {
            ((EditProductViewModel)editProductView).Produk = (Product)o;
            CurrentView = editProductView;
        }

        private void GoToCreateTransaction(object o) {
            CurrentView = createTransactionView;
		}

        private void GoToTransactionHistory(object o) {
            ((TransactionHistoryViewModel)transactionHistoryView).SetData(transactionRepo);
            CurrentView = transactionHistoryView;
		}

        private void GoToSalesRecap(object o) {
            ((SalesRecapViewModel)salesRecapView).UpdateData(transactionRepo);
            CurrentView = salesRecapView;
		}

        private void UpdateUserData(object o) {
            userDBContext.UpdateUserRepository();
		}
    }
}
