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
using System.Windows.Shapes;
using DLL;
using Server;

namespace GUI
{
    /// <summary>
    /// Interaction logic for EmployeeLogIn.xaml
    /// </summary>
    public partial class EmployeeLogIn : Window
    {
        public EmployeeLogIn()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {       
            bool logIn = false;
            string logString = TextBoxNameLog.Text.Replace(" ", "");
            logString =logString.ToLower();
            foreach (Employee employee in DB.DbEmployees)
            {
                string name = employee.FirstName + employee.LastName;
                name = name.ToLower();
                if (logString == name && TextBoxPasswordLog.Password == employee.Password)
                {
                    logIn = true;
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.lblUser.Content = $"{employee.FirstName} {employee.LastName} - {employee.Position}";
                    if (employee.Position == EPosition.Seller)
                    {
                        //mainWindow.btnRemoveItem.IsEnabled = false;
                        mainWindow.btnAddItem.Visibility = Visibility.Hidden;
                    }
                    mainWindow.Show();
                    this.Close();
                }
            }
            if (!logIn)
            {
                TextBoxPasswordLog.Password = "";
                MessageBox.Show("Incorect User name or password, try again.");
            }
        }
    }
}
