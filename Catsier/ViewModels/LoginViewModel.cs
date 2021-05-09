using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Catsier.ViewModels {
	class LoginViewModel : ViewModelBase{
		private SecureString password;
		public SecureString SecurePassword {
			set {
				password = value;
				IsPasswordEmpty = password.Length == 0;
			}
		}
		private bool isPasswordEmpty = true;
		public bool IsPasswordEmpty { 
			get {
				return isPasswordEmpty;
			} 
			private set {
				isPasswordEmpty = value;
				OnPropertyChanged("IsPasswordEmpty");
			}
		}

		private string email;
		public string Email {
			get {
				return email;
			}
			set {
				email = value;
				OnPropertyChanged("Email");
			}
		}

		private ICommand loginCommand;

		public ICommand LoginCommand {
			get {
				return loginCommand ?? (loginCommand = new RelayCommand((o) => {
					Auth.Instance.Login(Email, password);
					Mediator.Invoke("Change View To Dashboard");
				}));
			}
		}
	}
}
