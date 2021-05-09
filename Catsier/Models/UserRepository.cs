using Catsier.Security;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Catsier.Models {
	class UserRepository {
		private List<User> users;

		public event Action<User> onNewUser = x => { };

		public UserRepository() {
			users = new List<User>();
		}

		public void Add(string name, string email, SecureString password) {
			User user = new User(name, email, Hasher.Hash(password));
			users.Add(user);
			onNewUser(user);
		}

		public void UpdateData(string[] name, string[] email, string[] hashedPassword) {
			users.Clear();
			for(int i = 0; i < name.Length; i++) {
				User user = new User(name[i], email[i], hashedPassword[i]);
				users.Add(user);
			}
		}

		public User[] GetUsers() {
			return users.ToArray();
		}
	}
}
