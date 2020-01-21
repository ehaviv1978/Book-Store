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

namespace GUI
{
    /// <summary>
    /// Interaction logic for TransactionHistory.xaml
    /// </summary>
    public partial class TransactionHistory : Page
    {
        //public struct STransaction { public string seller;public string buyer; public int phoneNumber;
        //    public DateTime date; public double price; }
        //List<STransaction> sTransactions = new List<STransaction>();

        public TransactionHistory()
        {
            InitializeComponent();
            //initializeSTransaction();
            radioEmployee.IsChecked = true;
            listViewItems.ItemsSource = DB.DbTransactions;
            foreach (Employee employee in DB.DbEmployees)
            {
                comboEmployee.Items.Add(employee.FirstName + " " + employee.LastName);
            }
            //listViewItems.ItemsSource = sTransactions;
        }

        //private void initializeSTransaction()
        //{
        //    foreach (Transaction transaction in DB.DbTransactions)
        //    {
        //        STransaction sTransaction = new STransaction();
        //        sTransaction.seller = "eran";// transaction.Seller.FirstName + " " + transaction.Seller.LastName;
        //        sTransaction.buyer = transaction.Buyer.FirstName + " " + transaction.Buyer.LastName;
        //        sTransaction.date = transaction.Date;
        //        sTransaction.price = 99;// transaction.Price;
        //        sTransaction.phoneNumber = transaction.Buyer.PhoneNumber;
        //        sTransactions.Add(sTransaction);
        //    }
        //    //sTransactions.Clear();
        //}

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                Transaction transaction = (Transaction)listViewItems.SelectedItems[0];
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
                listViewItems.ItemsSource = DB.DbTransactions;
                return;
            }
            listViewItems.ItemsSource = null;
            List<Transaction> searchList = new List<Transaction>();
            foreach (Transaction transaction in DB.DbTransactions)
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

            listViewItems.ItemsSource = DB.DbTransactions;
            txtSearchCoustomer.Text = "";

        }

        private void radioEmployee_Checked(object sender, RoutedEventArgs e)
        {
            comboEmployee.IsEnabled = true;
            comboEmployee.Visibility = Visibility.Visible;

            txtSearchCoustomer.IsEnabled = false;
            txtSearchCoustomer.Visibility = Visibility.Hidden;

            listViewItems.ItemsSource = DB.DbTransactions;
            comboEmployee.SelectedIndex = -1;
        }

        private void txtSearchCoustomer_TextChanged(object sender, TextChangedEventArgs e)
        {
            listViewItems.ItemsSource = null;
            List<Transaction> searchList = new List<Transaction>();
            foreach (Transaction transaction in DB.DbTransactions)
            {
                string name = transaction.Buyer.FirstName.ToLower() + transaction.Buyer.LastName.ToLower();
                if (name.Contains(txtSearchCoustomer.Text.ToLower().Replace(" ", "")))
                    searchList.Add(transaction);
            }
            listViewItems.ItemsSource = searchList;
        }
    }
}
