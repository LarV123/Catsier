using System;
using System.Collections.Generic;
using System.Text;
using Catsier.Models;
using MySqlConnector;

namespace Catsier.Database {
	class UpdateUserRepositoryCommand {

		private MySqlCommand command;
		private DBConnection dbConnection;
		private UserRepository userRepo;
		private string commandString = @"SELECT NAME, EMAIL, PASSWORD FROM kasir;";

		private List<string> name;
		private List<string> email;
		private List<string> password;

		public UpdateUserRepositoryCommand(UserRepository userRepository, DBConnection dbConnection) {
			userRepo = userRepository;
			this.dbConnection = dbConnection;
			command = new MySqlCommand(commandString, dbConnection.Connection);
			name = new List<string>();
			email = new List<string>();
			password = new List<string>();
		}

		public void Execute() {
			name.Clear();
			email.Clear();
			password.Clear();
			dbConnection.Connection.Open();
			MySqlDataReader reader = command.ExecuteReader();
			while (reader.Read()) {
				name.Add((string)reader["NAME"]);
				email.Add((string)reader["EMAIL"]);
				password.Add((string)reader["PASSWORD"]);
			}
			reader.Close();
			dbConnection.Connection.Close();
			userRepo.UpdateData(name.ToArray(), email.ToArray(), password.ToArray());
		}
	}
}
