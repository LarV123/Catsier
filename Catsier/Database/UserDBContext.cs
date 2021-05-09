using Catsier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Database {
	class UserDBContext {

		private UserRepository userRepo;
		private DBConnection dbConnection;
		private AddNewUserCommand newUserCommand;
		private UpdateUserRepositoryCommand updateUserCommand;

		public UserDBContext(UserRepository userRepository, DBConnection dbConnection) {
			userRepo = userRepository;
			this.dbConnection = dbConnection;
			newUserCommand = new AddNewUserCommand(dbConnection);
			updateUserCommand = new UpdateUserRepositoryCommand(userRepository, dbConnection);
			userRepo.onNewUser += OnNewUser;
			Mediator.Subscribe("Update User Data", UpdateUserRepository);
		}

		public void OnNewUser(User user) {
			newUserCommand.Execute(user.Name, user.Email, user.HashedPassword);
		}

		public void UpdateUserRepository(object o) {
			updateUserCommand.Execute();
		}

	}
}
