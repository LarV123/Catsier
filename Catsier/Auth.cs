using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using Catsier.Models;
using Catsier.Security;

namespace Catsier {
	class Auth {
		private static Auth instance;
		public static Auth Instance {
			get {
				return instance;
			}
		}

		public static void CreateInstance(UserRepository userRepository) {
			instance = new Auth(userRepository);
		}

		private UserRepository userRepository;

		public Auth(UserRepository userRepository) {
			this.userRepository = userRepository;
		}

		private User loggedUser;

		public bool IsLoggedIn {
			get {
				return loggedUser != null;
			}
		}

		public User LoggedUser {
			get {
				return loggedUser;
			}
		}

		public void Login(string email, SecureString password) {
			User[] users = userRepository.GetUsers();
			foreach(User user in users) {
				if(user.Email == email) {
					if (user.ComparePassword(password)) {
						loggedUser = user;
						break;
					}
				}
			}
		}

		public void Logout() {
			loggedUser = null;
			Mediator.Invoke("Change View To Start");
		}
	}
}
