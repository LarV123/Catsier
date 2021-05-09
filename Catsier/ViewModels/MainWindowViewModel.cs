using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Catsier.ViewModels {
	class MainWindowViewModel : ViewModelBase {
        private ICommand gotoLoginView;
        private object currentView;
        private object startingView;
        private object loginView;
        private object dashboardView;
        private object profileView;

        public MainWindowViewModel() {
            startingView = new StartingViewModel();
            loginView = new LoginViewModel();
            dashboardView = new DashboardViewModel();
            profileView = new UserProfileViewModel();
            Mediator.Subscribe("Change View To Dashboard", GotoDasboard);
            Mediator.Subscribe("Change View To Profile", GotoProfile);
            CurrentView = startingView;
        }

        public object CurrentView {
            get { return currentView; }
            set {
                currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }

        public ICommand GoToLoginViewCommand {
            get {
                return gotoLoginView ?? (gotoLoginView = new RelayCommand(
                   x => {
                       GotoLoginView();
                   }));
            }
        }

        private void GotoLoginView() {
            CurrentView = loginView;
        }

        private void GotoDasboard() {
            CurrentView = dashboardView;
		}

        private void GotoProfile() {
            CurrentView = profileView;
		}
    }
}
