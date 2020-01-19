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
using System.Text.RegularExpressions;


namespace GUI
{
    /// <summary>
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Page
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtPhoneNumber.Text != "")
            {
                Customer newCustomer = new Customer();
                newCustomer.FirstName = txtFirstName.Text;
                newCustomer.LastName = txtLastName.Text;
                newCustomer.Birthdate = datePickerBirthDate.SelectedDate;
                newCustomer.Adress = txtAddress.Text;
                if (txtPhoneNumber.Text != "")
                {
                    newCustomer.PhoneNumber = Convert.ToInt32(txtPhoneNumber.Text);
                }
                newCustomer.Email = txtEmail.Text;

                DB.DbCustomers.Add(newCustomer);
                MessageBox.Show("New Customer Add");
                NavigationService.Navigate(new Contacts());
            }
            else
            {
                MessageBox.Show("First Name, Last Name and phone number are required fields");
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCustomer());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Contacts());
        }
    }
}
