using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Catsier.ViewModels {
	class UserProfileViewModel : ViewModelBase{
	
		public string Name {
			get {
				return Auth.Instance.LoggedUser.Name;
			}
		}

		public string Email {
			get {
				return Auth.Instance.LoggedUser.Email;
			}
		}

		public ICommand BackCommand {
			get {
				return new RelayCommand(x => Mediator.Invoke("Change View To Dashboard"));
			}
		}

	}
}
