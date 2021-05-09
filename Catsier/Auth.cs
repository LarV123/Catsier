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
				if(instance == null) {
					instance = new Auth();
				}
				return instance;
			}
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
			//mockup login
			loggedUser = new User(1, "Natih", email, Hasher.Hash(password));
		}
	}
}
