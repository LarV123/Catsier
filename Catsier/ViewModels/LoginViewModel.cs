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

		private string email = "";
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
					if(Email == "" || IsPasswordEmpty) {
						MessageBox.Show("Empty login credentials", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
						return;
					}
					Auth.Instance.Login(Email, password);
					if(Auth.Instance.LoggedUser == null) {
						MessageBox.Show("Wrong email or password", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
						return;
					}
					Email = "";
					isPasswordEmpty = true;
					Mediator.Invoke("Change View To Dashboard");
				}));
			}
		}
	}
}
