using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;

namespace Catsier.Database {
	class DBConnection {

		private MySqlConnection connection;
		public MySqlConnection Connection {
			get {
				return connection;
			}
		}
		private string server;
		private string database;
		private string uid;
		private string password;

		private DatabaseInitializer databaseInitializer;

		public DBConnection() {
			Initialize();
			databaseInitializer = new DatabaseInitializer(this);
			databaseInitializer.Initialize();
		}

		private void Initialize() {
			server = "localhost";
			database = "catsier";
			uid = "root";
			password = "admin";
			string connectionString = string.Format("SERVER={0};DATABASE={1};UID={2};PASSWORD={3};", server, database, uid, password);
			connection = new MySqlConnection(connectionString);
		}

	}
}
