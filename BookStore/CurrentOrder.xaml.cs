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
    /// Interaction logic for CurrentOrder.xaml
    /// </summary>
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
                totalPrice += item.Price;
            }
            lblTotalPrice.Content = $"Total: {totalPrice}$";
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Cancel Order", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                foreach (Item item in DB.DBCurentOrder)
                {
                    foreach (Book book in DB.DbBooks)
                    {
                        if (item.ItemCode == book.ItemCode)
                        {
                            book.Stock++;
                            break;
                        }
                    }
                    foreach (Journal jouranl in DB.DbJournals)
                    {
                        if (item.ItemCode == jouranl.ItemCode)
                        {
                            jouranl.Stock++;
                            break;
                        }
                    }
                }
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
            Item selectedItem = (Item)listViewItems.SelectedItems[0];
            foreach (Item item in DB.DBCurentOrder)
            {
                if (selectedItem.ItemCode == item.ItemCode)
                {
                    DB.DBCurentOrder.Remove(item);
                    break;
                }
            }
            foreach (Book book in DB.DbBooks)
            {
                if (selectedItem.ItemCode == book.ItemCode)
                {
                    book.Stock++;
                    break;
                }
            }
            foreach (Journal jouranl in DB.DbJournals)
            {
                if (selectedItem.ItemCode == jouranl.ItemCode)
                {
                    jouranl.Stock++;
                    break;
                }
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
    }
}
