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
using DLL;
using Server;

namespace GUI
{
    /// <summary>
    /// Interaction logic for PersonInfo.xaml
    /// </summary>
    public partial class PersonInfo : Page
    {
        public PersonInfo()
        {
            InitializeComponent();

            txtStoreID.IsReadOnly = true;
            txtAddress.IsReadOnly = true;
            txtEmail.IsReadOnly = true;
            txtFirstName.IsReadOnly = true;
            txtLastName.IsReadOnly = true;
            txtPhoneNumber.IsReadOnly = true;
            datePickerBirthDate.IsEnabled = false;

            txtStoreID.Text = MainWindow.currentPersonID.ToString();
            foreach (Customer customer in DB.DbCustomers)
            {
                if (customer.PersonStoreID == MainWindow.currentPersonID)
                {
                    txtFirstName.Text = customer.FirstName;
                }
            }
            foreach (Employee employee in DB.DbEmployees)
            {
                if (employee.PersonStoreID == MainWindow.currentPersonID)
                {
                    txtFirstName.Text = employee.FirstName;
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
