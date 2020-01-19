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

namespace GUI
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Page
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StoreInventory());
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (passBox1.Password == passBox2.Password && passBox1.Password != "")
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Password Change", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    MainWindow.currentEmployee.Password = passBox1.Password;
                    MessageBox.Show("Password Changed");
                    NavigationService.Navigate(new StoreInventory());
                }
            }
            else
            {
                MessageBox.Show("Passwords are not the same..");
            }
        }
    }
}
