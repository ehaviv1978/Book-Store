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

            btnSave.Visibility = Visibility.Hidden;

            if (MainWindow.user == "seller")
            {
                btnEdit.Visibility = Visibility.Hidden;
            }

            txtStoreID.IsReadOnly = true;
            txtAddress.IsReadOnly = true;
            txtEmail.IsReadOnly = true;
            txtFirstName.IsReadOnly = true;
            txtLastName.IsReadOnly = true;
            txtPhoneNumber.IsReadOnly = true;
            datePickerBirthDate.Focusable = false;
            datePickerBirthDate.IsHitTestVisible = false;

            txtStoreID.Text = MainWindow.currentPersonID.ToString();
            foreach (Customer coustomer in DB.DbCustomers)
            {
                if (coustomer.PersonStoreID == MainWindow.currentPersonID)
                {              
                    txtFirstName.Text = coustomer.FirstName;
                    txtLastName.Text = coustomer.LastName;
                    txtAddress.Text = coustomer.Adress;
                    txtEmail.Text = coustomer.Email;
                    txtPhoneNumber.Text = coustomer.PhoneNumber.ToString();
                    datePickerBirthDate.Text = coustomer.Birthdate.ToString();
                }
            }
            foreach (Employee employee in DB.DbEmployees)
            {
                if (employee.PersonStoreID == MainWindow.currentPersonID)
                {
                    txtFirstName.Text = employee.FirstName;
                    txtLastName.Text = employee.LastName;
                    txtAddress.Text = employee.Adress;
                    txtEmail.Text = employee.Email;
                    txtPhoneNumber.Text = employee.PhoneNumber.ToString();
                    datePickerBirthDate.Text = employee.Birthdate.ToString();
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            txtAddress.IsReadOnly = false;
            txtEmail.IsReadOnly = false;
            txtFirstName.IsReadOnly = false;
            txtLastName.IsReadOnly = false;
            txtPhoneNumber.IsReadOnly = false;
            datePickerBirthDate.Focusable = true;
            datePickerBirthDate.IsHitTestVisible = true;

            btnSave.Visibility = Visibility.Visible;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Chane Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                txtStoreID.Text = MainWindow.currentPersonID.ToString();
                foreach (Customer coustomer in DB.DbCustomers)
                {
                    if (coustomer.PersonStoreID == MainWindow.currentPersonID)
                    {
                        coustomer.FirstName = txtFirstName.Text;
                        coustomer.LastName = txtLastName.Text;
                        coustomer.Adress = txtAddress.Text;
                        coustomer.Email = txtEmail.Text;
                        coustomer.PhoneNumber = Convert.ToInt32(txtPhoneNumber.Text);
                        coustomer.Birthdate = datePickerBirthDate.SelectedDate;
                    }
                }
                foreach (Employee employee in DB.DbEmployees)
                {
                    if (employee.PersonStoreID == MainWindow.currentPersonID)
                    {
                        employee.FirstName = txtFirstName.Text;
                        employee.LastName = txtLastName.Text;
                        employee.Adress = txtAddress.Text;
                        employee.Email = txtEmail.Text;
                        employee.PhoneNumber = Convert.ToInt32(txtPhoneNumber.Text);
                        employee.Birthdate = datePickerBirthDate.SelectedDate;
                    }
                }
                MessageBox.Show("Changes Saved");
                NavigationService.Navigate(new Contacts());
            }
        }
    }
}
