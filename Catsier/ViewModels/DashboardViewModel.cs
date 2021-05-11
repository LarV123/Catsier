using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Catsier.ViewModels {
	class DashboardViewModel : ViewModelBase{

		public string Name {
			get {
				return Auth.Instance.LoggedUser.Name;
			}
		}

		private ICommand goToProfileCommand;

		public ICommand GoToProfileCommand {
			get {
				return goToProfileCommand ?? (goToProfileCommand = new RelayCommand(x => { Mediator.Invoke("Change View To Profile"); }));
			}
		}

		private ICommand goToProductListCommand;

		public ICommand GoToProductListCommand {
			get {
				return goToProductListCommand ?? (goToProductListCommand = new RelayCommand(x => Mediator.Invoke("Change View To Product List")));
			}
		}


		private ICommand goToCreateTransactionCommand;
		
		public ICommand GoToCreateTransactionCommand {
			get {
				return goToCreateTransactionCommand ?? (goToCreateTransactionCommand = new RelayCommand(x => Mediator.Invoke("Change View To Create Transaction")));
			}
		}

		private ICommand goToTransactionHistoryCommand;

		public ICommand GoToTransactionHistoryCommand {
			get {
				return goToTransactionHistoryCommand ?? (goToTransactionHistoryCommand = new RelayCommand(x => Mediator.Invoke("Change View To Transaction History")));
			}
		}

		private ICommand goToSalesRecapCommand;

		public ICommand GoToSalesRecapCommand {
			get {
				return goToSalesRecapCommand ?? (goToSalesRecapCommand = new RelayCommand(x => Mediator.Invoke("Change View To Sales Recap")));
			}
		}

		private ICommand logoutCommand;

		public ICommand LogoutCommand {
			get {
				return logoutCommand ?? (logoutCommand = new RelayCommand(x => Logout()));
			}
		}

		private void Logout() {
			Auth.Instance.Logout();
		}
	}
}
