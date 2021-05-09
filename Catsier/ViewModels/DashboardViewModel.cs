﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Catsier.ViewModels {
	class DashboardViewModel : ViewModelBase{

		public string Name {
			get {
				return Auth.Instance.LoggedUser.Name;
			}
		}

		public ICommand GoToProfileCommand {
			get {
				return new RelayCommand(x => { Mediator.Invoke("Change View To Profile"); });
			}
		}
	}
}
