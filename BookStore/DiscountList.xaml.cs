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
using System.Linq;


namespace GUI
{
    
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
                using Server.Data.BookStoreContext context = new Server.Data.BookStoreContext();
                context.DBDiscounts.Remove((Discount)listViewItems.SelectedItem);
                DB.DBDiscounts.Remove((Discount)listViewItems.SelectedItem);
                foreach (Item item in context.DBItems)
                {
                    item.Discount = 0;
                }
                context.SaveChanges();
                DB.DbBooks = context.DbBooks.ToList();
                DB.DbJournals = context.DbJournals.ToList();
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
