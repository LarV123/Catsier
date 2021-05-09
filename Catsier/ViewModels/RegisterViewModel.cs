using Catsier.Models;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Catsier.ViewModels {
	class RegisterViewModel : ViewModelBase{

		private string name = "";
		private string email = "";

		public string Name {
			get {
				return name;
			}
			set {
				name = value;
				OnPropertyChanged("Name");
			}
		}

		public string Email {
			get {
				return email;
			}
			set {
				email = value;
				OnPropertyChanged("Email");
			}
		}

		private SecureString password;
		public SecureString SecurePassword {
			get {
				return password;
			}
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

		private ICommand daftarCommand;

		public ICommand DaftarCommand {
			get {
				return daftarCommand ?? (daftarCommand = new RelayCommand(x => Daftar()));
			}
		}

		private UserRepository userRepo;

		public RegisterViewModel(UserRepository userRepository) {
			userRepo = userRepository;
		}

		public void Daftar() {
			if (Name == "" || Email == "" || IsPasswordEmpty) {
				MessageBox.Show("Empty register credentials", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			userRepo.Add(Name, Email, SecurePassword);
			Auth.Instance.Login(Email, SecurePassword);
			Name = "";
			Email = "";
			isPasswordEmpty = true;
			Mediator.Invoke("Change View To Dashboard");
		}



	}
}
