using Catsier.Security;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Catsier.Models {
	class UserRepository {
		private List<User> users;

		public UserRepository() {
			users = new List<User>();
		}

		public void Register(string name, string email, SecureString password) {
			users.Add(new User(name, email, Hasher.Hash(password)));
		}

		public User[] GetUsers() {
			return users.ToArray();
		}
	}
}
