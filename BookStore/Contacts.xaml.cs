using System;
using System.Collections.Generic;
using System.Linq;
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
        List<Person> allPersons = DB.DbEmployees.Cast<Person>().Concat(DB.DbCustomers.Cast<Person>()).ToList();
        List<Person> shownPersons = new List<Person>();

        public Contacts()
        {
            InitializeComponent();
            listViewItems.ItemsSource = allPersons;
        }
   

        private void RadioCustomers_Checked(object sender, RoutedEventArgs e)
        {
            Serch(DB.DbCustomers.Cast<Person>().ToList());
        }

        private void RadioEmployee_Checked(object sender, RoutedEventArgs e)
        {
            Serch(DB.DbEmployees.Cast<Person>().ToList());
        }

        private void RadioAll_Checked(object sender, RoutedEventArgs e)
        {
            Serch(allPersons);
        }

        private void TextBoxSerchItem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RadioAll.IsChecked.Value == true)
            {
                Serch(allPersons);
            }
            else if (RadioCustomers.IsChecked == true)
            {
                Serch(DB.DbCustomers.Cast<Person>().ToList());
            }
            else
            {
                Serch(DB.DbEmployees.Cast<Person>().ToList());
            }
        }

        private void Serch(List<Person> Persons)
        {
            shownPersons.Clear();
            foreach (Person person in Persons)
            {
                string name = person.FirstName.ToLower().Replace(" ", "")+person.LastName.ToLower().Replace(" ", "");
                if (name.Contains(TextBoxSerchItem.Text.ToLower().Replace(" ", "")))
                    shownPersons.Add(person);
            }
            listViewItems.ItemsSource = shownPersons;
            listViewItems.Items.Refresh();
        }

        private void BtnClearSerch_Click(object sender, RoutedEventArgs e)
        {
            TextBoxSerchItem.Text = "";
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Person person = (Person)listViewItems.SelectedItems[0];
            MainWindow.currentPersonID = person.PersonStoreID;
            NavigationService.Navigate(new PersonInfo());
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCustomer());
        }
    }
}
