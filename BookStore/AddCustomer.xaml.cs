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
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Page
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtPhoneNumber != null)
            {
                Customer newCustomer = new Customer();
                newCustomer.FirstName = txtFirstName.Text;
                newCustomer.LastName = txtLastName.Text;
                newCustomer.Birthdate = datePickerBirthDate.SelectedDate;
                newCustomer.Adress = txtAddress.Text;
                newCustomer.PhoneNumber = Convert.ToInt32(txtPhoneNumber.Text);
                newCustomer.Email = txtEmail.Text;

                DB.DbCustomers.Add(newCustomer);
                MessageBox.Show("New Customer Add");
            }
            else
            {
                MessageBox.Show("First Name, Last Name and phone number are required fields");
            }

        }
    }
}
