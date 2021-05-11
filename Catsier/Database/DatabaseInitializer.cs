using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Database {
	class DatabaseInitializer {

		private DBConnection connection;

		public DatabaseInitializer(DBConnection connection) {
			this.connection = connection;
		}

	}
}
