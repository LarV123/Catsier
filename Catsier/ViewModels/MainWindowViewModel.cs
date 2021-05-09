using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Catsier.Views;

namespace Catsier.ViewModels {
	class MainWindowViewModel : ViewModelBase {
        private ICommand gotoLoginView;
        private object currentView;
        private object startingView;
        private object loginView;
        private object dashboardView;

        public MainWindowViewModel() {
            startingView = new StartingViewModel();
            loginView = new LoginViewModel();
            dashboardView = new DashboardView();
            Mediator.Subscribe("Change View To Dashboard", GotoDasboard);
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
    }
}
