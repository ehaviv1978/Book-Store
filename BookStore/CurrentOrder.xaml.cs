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
    public partial class CurrentOrder : Page
    {
        public CurrentOrder()
        {
            InitializeComponent();
            listViewItems.ItemsSource = DB.DBCurentOrder;
            if (DB.DBCurentOrder.Count == 0)
            {
                btnConfirmOrder.IsEnabled = false;
                btnCancel.IsEnabled = false;
                btnRemoveFromOrder.IsEnabled = false;
            }
            showPrice();
        }

        private void showPrice()
        {
            double totalPrice = 0;
            foreach (Item item in DB.DBCurentOrder)
            {
                totalPrice += item.FinalPrice;
            }
            lblTotalPrice.Content = $"Total: {String.Format("{0:0.00}", totalPrice)}₪";
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Cancel Order", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                using Server.Data.BookStoreContext context = new Server.Data.BookStoreContext();
                foreach (Item item in DB.DBCurentOrder)
                {
                    foreach (Item item1 in context.DBItems)
                    {
                        if(item.ItemCode == item1.ItemCode)
                        {
                            item1.Stock++;
                            break;
                        }
                    }
                }
                context.SaveChanges();
                DB.DbBooks = context.DbBooks.ToList();
                DB.DbJournals = context.DbJournals.ToList();
                DB.DBCurentOrder.Clear();
                MessageBox.Show("Order Canceled");
                listViewItems.Items.Refresh();
                lblTotalPrice.Content = "Total: 0.00$";
                btnConfirmOrder.IsEnabled = false;
                btnCancel.IsEnabled = false;
                btnRemoveFromOrder.IsEnabled = false;
            }
        }

        private void btnRemoveFromOrder_Click(object sender, RoutedEventArgs e)
        {
            if (listViewItems.SelectedItems.Count == 0)
                return;
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Cancel Order", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                using Server.Data.BookStoreContext context = new Server.Data.BookStoreContext();
                Item selectedItem = (Item)listViewItems.SelectedItems[0];
                foreach (Item item in context.DBItems)
                {
                    if (selectedItem.ItemCode== item.ItemCode)
                    {
                        item.Stock++;
                        DB.DBCurentOrder.Remove(selectedItem);
                        break;
                    }
                }
                context.SaveChanges();
                DB.DbBooks = context.DbBooks.ToList();
                DB.DbJournals = context.DbJournals.ToList();
            }
            
            if (DB.DBCurentOrder.Count == 0)
            {
                btnConfirmOrder.IsEnabled = false;
                btnCancel.IsEnabled = false;
                btnRemoveFromOrder.IsEnabled = false;
            }
            listViewItems.Items.Refresh();
            showPrice();
        }

        private void btnConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderConfirm());

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StoreInventory());
        }
    }
}
