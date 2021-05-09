using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Catsier {
	class RelayCommand<T> : ICommand {

		private readonly Predicate<T> canExecute;
		private readonly Action<T> execute;

		public RelayCommand(Action<T> execute) : this(execute, null){
			this.execute = execute;
		}

		public RelayCommand(Action<T> execute, Predicate<T> canExecute) {
			if(execute == null) {
				throw new ArgumentNullException("execute");
			}
			this.execute = execute;
			this.canExecute = canExecute;
		}

		public bool CanExecute(object parameter) {
			return canExecute == null || canExecute((T)parameter);
		}

		public void Execute(object parameter) {
			execute((T)parameter);
		}

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}
	}

	class RelayCommand : ICommand {

		private readonly Predicate<object> canExecute;
		private readonly Action<object> execute;

		public RelayCommand(Action<object> execute) : this(execute, null) {
			this.execute = execute;
		}

		public RelayCommand(Action<object> execute, Predicate<object> canExecute) {
			if (execute == null) {
				throw new ArgumentNullException("execute");
			}
			this.execute = execute;
			this.canExecute = canExecute;
		}

		public bool CanExecute(object parameter) {
			return canExecute == null || canExecute(parameter);
		}

		public void Execute(object parameter) {
			execute(parameter);
		}

		public event EventHandler CanExecuteChanged {
			add {
				CommandManager.RequerySuggested += value;
				CanExecuteChangedInternal += value;
			}
			remove {
				CommandManager.RequerySuggested -= value;
				CanExecuteChangedInternal -= value;
			}
		}

		private event EventHandler CanExecuteChangedInternal;

		public void RaiseCanExecuteChanged() {
			CanExecuteChangedInternal.Raise(this);
		}
	}

}
