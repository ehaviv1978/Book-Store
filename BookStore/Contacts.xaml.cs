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
    /// Interaction logic for Contacts.xaml
    /// </summary>
    public partial class Contacts : Page
    {
        public Contacts()
        {
            List<Person> PersonList = InitializePersonList();
            InitializeComponent();
            listViewItems.ItemsSource = PersonList;
        }

        public List<Person> InitializePersonList()
        {
            List<Person> personList = new List<Person>();
            foreach (Employee employee in DB.DbEmployees)
            {
                Person person = new Person();
                person.FirstName = employee.FirstName;
                person.LastName = employee.LastName;
                person.PhoneNumber = employee.PhoneNumber;
                person.Email = employee.Email;
                person.Birthdate = employee.Birthdate;
                personList.Add(person);
            }
            foreach (Customer customer in DB.DbCustomers)
            {
                Person person = new Person();
                person.FirstName = customer.FirstName;
                person.LastName = customer.LastName;
                person.PhoneNumber = customer.PhoneNumber;
                person.Email = customer.Email;
                person.Birthdate = customer.Birthdate;
                personList.Add(person);
            }
            return personList;
        }

        private void RadioCustomers_Checked(object sender, RoutedEventArgs e)
        {
            listViewItems.ItemsSource = DB.DbCustomers;
        }

        private void RadioEmployee_Checked(object sender, RoutedEventArgs e)
        {
            listViewItems.ItemsSource = DB.DbEmployees;
        }

        private void RadioAll_Checked(object sender, RoutedEventArgs e)
        {
            List<Person> PersonList = InitializePersonList();
            listViewItems.ItemsSource = PersonList;
        }

        private void TextBoxSerchItem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RadioAll != null)
            {
                RadioAll.IsChecked = true;
            }
            List<Person> serchList = new List<Person>();
            List<Person> showList = new List<Person>();
            serchList = InitializePersonList();

            foreach (Person item in serchList)
            {
                string name = (item.FirstName+item.LastName).ToLower().Replace(" ", "");
                if (name.Contains(TextBoxSerchItem.Text.ToLower().Replace(" ", "")))
                    showList.Add(item);
            }

            listViewItems.ItemsSource = showList;
        }
    }
}
