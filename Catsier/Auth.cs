using System;
using System.Collections.Generic;
using System.Text;
using Catsier.Models;

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

		public bool IsLoggedIn {
			get {
				return false;
			}
		}

		public User LoggedUser {
			get {
				return new User();
			}
		}
	}
}
