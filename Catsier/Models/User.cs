using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Catsier.Models {
	class User {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string HashedPassword { get; set; }

		public User(int id, string name, string email, string hashedPassword) {
			Id = id;
			Name = name;
			Email = email;
			HashedPassword = hashedPassword;
		}

		public bool ComparePassword(SecureString password) {
			return true;
		}
	}
}
