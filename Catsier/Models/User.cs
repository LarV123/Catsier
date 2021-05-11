using Catsier.Security;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Catsier.Models {
	class User {
		public string Name { get; set; }
		public string Email { get; set; }
		public string HashedPassword { get; set; }

		public User(string name, string email, string hashedPassword) {
			Name = name;
			Email = email;
			HashedPassword = hashedPassword;
		}

		public bool ComparePassword(SecureString password) {
			return HashedPassword == Hasher.Hash(password);
		}
	}
}
