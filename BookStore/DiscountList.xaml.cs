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
    /// Interaction logic for DiscountList.xaml
    /// </summary>
    public partial class DiscountList : Page
    {
        public DiscountList()
        {
            InitializeComponent();
            btnRemoveDiscount.IsEnabled = false;
            if (MainWindow.user == "seller"){
                btnAddDiscount.Visibility = Visibility.Hidden;
                btnRemoveDiscount.Visibility = Visibility.Hidden;
            }
            listViewItems.ItemsSource = DB.DBDiscounts;

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StoreInventory());

        }

        private void listViewItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                btnRemoveDiscount.IsEnabled = true;
            }
            else
            {
                btnRemoveDiscount.IsEnabled = false;
            }
        }

        private void btnRemoveDiscount_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Remove Discount", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                DB.DBDiscounts.Remove((Discount)listViewItems.SelectedItem);
                foreach (Book book in DB.DbBooks)
                {
                    book.Discount = 0;
                }
                foreach (Journal journal in DB.DbJournals)
                {
                    journal.Discount = 0;
                }
                listViewItems.Items.Refresh();
                MessageBox.Show("Discount Removed");
            }
        }

        private void btnAddDiscount_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddDiscount());
        }
    }
}
