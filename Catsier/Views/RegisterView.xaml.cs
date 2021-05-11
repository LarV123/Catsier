using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Catsier.Views {
	/// <summary>
	/// Interaction logic for RegisterView.xaml
	/// </summary>
	public partial class RegisterView : UserControl {
		public RegisterView() {
			InitializeComponent();
		}

		private void Password_PasswordChanged(object sender, RoutedEventArgs e) {

			if (DataContext != null) {
				((dynamic)DataContext).SecurePassword = ((PasswordBox)sender).SecurePassword;
			}

		}
	}
}
