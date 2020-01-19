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
    /// Interaction logic for NewWorker.xaml
    /// </summary>
    public partial class NewWorker : Page
    {
        public NewWorker()
        {
            InitializeComponent();
            comboPosition.ItemsSource = Enum.GetValues(typeof(DLL.EPosition));
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtPhoneNumber.Text != "" && comboPosition.Text !="")
            {
                Employee newEmployee = new Employee();
                newEmployee.FirstName = txtFirstName.Text;
                newEmployee.LastName = txtLastName.Text;
                newEmployee.Birthdate = datePickerBirthDate.SelectedDate;
                newEmployee.Adress = txtAddress.Text;
                newEmployee.Password = "1234";
                if (txtPhoneNumber.Text != "")
                {
                    newEmployee.PhoneNumber = Convert.ToInt32(txtPhoneNumber.Text);
                }
                newEmployee.Email = txtEmail.Text;
                newEmployee.Position = (DLL.EPosition)comboPosition.SelectedItem;

                DB.DbEmployees.Add(newEmployee);
                MessageBox.Show("New Employee Add");
                NavigationService.Navigate(new Contacts());
            }
            else
            {
                MessageBox.Show("First Name, Last Name and phone number are required fields");
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewWorker());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Contacts());
        }
    }
}
