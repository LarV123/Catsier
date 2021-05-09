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
	}
}
