using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;

namespace Catsier.Database {
	class AddNewUserCommand {

		private string commandString = @"INSERT INTO kasir (NAME, EMAIL, PASSWORD) VALUES ('{0}', '{1}', '{2}');";

		private DBConnection dbConnection;

		public AddNewUserCommand(DBConnection dbConnection) {
			this.dbConnection = dbConnection;
		}

		public void Execute(string name, string email, string hashedPassword) {
			MySqlCommand command = new MySqlCommand(string.Format(commandString, name, email, hashedPassword), dbConnection.Connection);
			dbConnection.Connection.Open();
			command.ExecuteNonQuery();
			dbConnection.Connection.Close();
		}

	}
}
