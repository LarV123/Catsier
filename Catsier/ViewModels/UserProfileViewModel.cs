using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.ViewModels {
	class UserProfileViewModel : ViewModelBase{
	
		public string Name {
			get {
				return Auth.Instance.LoggedUser.Name;
			}
		}

		public string Email {
			get {
				return Auth.Instance.LoggedUser.Email;
			}
		}

	}
}
