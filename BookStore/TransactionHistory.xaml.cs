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
using Server;
using DLL;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GUI
{
   
    public partial class TransactionHistory : Page
    {
        
        public TransactionHistory()
        {
            InitializeComponent();
            radioEmployee.IsChecked = true;
            //listViewItems.ItemsSource = DB.transactionShows;
            foreach (Employee employee in DB.DbEmployees)
            {
                comboEmployee.Items.Add(employee.FirstName + " " + employee.LastName);
            }
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                TransactionShow transaction = (TransactionShow)listViewItems.SelectedItems[0];
                MainWindow.curentTransaction = transaction;
                NavigationService.Navigate(new TransactionInfo());
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StoreInventory());
           
        }

        private void comboEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboEmployee.SelectedIndex == -1)
            {
                listViewItems.ItemsSource = DB.transactionShows;
                return;
            }
            listViewItems.ItemsSource = null;
            List<TransactionShow> searchList = new List<TransactionShow>();
            foreach (TransactionShow transaction in DB.transactionShows)
            {
                if ((transaction.Seller.FirstName + " " + transaction.Seller.LastName) == comboEmployee.SelectedItem.ToString())
                {
                    searchList.Add(transaction);
                }
            }
            listViewItems.ItemsSource = searchList;
        }

        private void radioCoustomer_Checked(object sender, RoutedEventArgs e)
        {
            comboEmployee.IsEnabled = false;
            comboEmployee.Visibility = Visibility.Hidden;

            txtSearchCoustomer.IsEnabled = true;
            txtSearchCoustomer.Visibility = Visibility.Visible;

            listViewItems.ItemsSource = DB.transactionShows;
            txtSearchCoustomer.Text = "";

        }

        private void radioEmployee_Checked(object sender, RoutedEventArgs e)
        {
            comboEmployee.IsEnabled = true;
            comboEmployee.Visibility = Visibility.Visible;

            txtSearchCoustomer.IsEnabled = false;
            txtSearchCoustomer.Visibility = Visibility.Hidden;

            listViewItems.ItemsSource = DB.transactionShows;
            comboEmployee.SelectedIndex = -1;
        }

        private void txtSearchCoustomer_TextChanged(object sender, TextChangedEventArgs e)
        {
            listViewItems.ItemsSource = null;
            List<TransactionShow> searchList = new List<TransactionShow>();
            foreach (TransactionShow transaction in DB.transactionShows)
            {
                string name = transaction.Buyer.FirstName.ToLower() + transaction.Buyer.LastName.ToLower();
                if (name.Contains(txtSearchCoustomer.Text.ToLower().Replace(" ", "")))
                    searchList.Add(transaction);
            }
            listViewItems.ItemsSource = searchList;
        }
    }
}
