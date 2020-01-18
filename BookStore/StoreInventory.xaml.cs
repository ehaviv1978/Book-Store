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
using System.Collections.ObjectModel;

namespace GUI
{
    public partial class StoreInventory : Page
    {
        List<Item> allItems = DB.DbBooks.Cast<Item>().Concat(DB.DbJournals.Cast<Item>()).ToList();
        List<Item> shownItems = new List<Item>();

        public StoreInventory()
        {
            InitializeComponent();
            if (MainWindow.user == "manager")
            {
                btnAddItem.Visibility = Visibility.Visible;
            }
            else
            {
                btnAddItem.Visibility = Visibility.Hidden;

            }
        }


        private void RadioAll_Checked(object sender, RoutedEventArgs e)
        {
            Serch(allItems);
        }

        private void RadioBooks_Checked(object sender, RoutedEventArgs e)
        {
            Serch(DB.DbBooks.Cast<Item>().ToList());
        }

        private void RadioJournals_Checked(object sender, RoutedEventArgs e)
        {
            Serch(DB.DbJournals.Cast<Item>().ToList());
        }

        private void TextBoxSerchItem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RadioAll.IsChecked.Value == true)
            {
                Serch(allItems);
            }
            else if (RadioBooks.IsChecked == true)
            {
                Serch(DB.DbBooks.Cast<Item>().ToList());
            }
            else
            {
                Serch(DB.DbJournals.Cast<Item>().ToList());
            }
        }

        private void Serch(List<Item> Items)
        {
            shownItems.Clear();
            foreach (Item item in Items)
            {
                string name = item.Name.ToLower().Replace(" ", "");
                if (name.Contains(TextBoxSerchItem.Text.ToLower().Replace(" ", "")))
                    shownItems.Add(item);
            }
            listViewItems.ItemsSource = shownItems;
            listViewItems.Items.Refresh();
        }

        private void BtnClearSerch_Click(object sender, RoutedEventArgs e)
        {
            TextBoxSerchItem.Text = "";
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Item item = (Item)listViewItems.SelectedItems[0];
            MainWindow.currentItemCode = item.ItemCode;
            NavigationService.Navigate(new ItemInfo());
        }

        private void btnAddToOrder_Click(object sender, RoutedEventArgs e)
        {
            if (listViewItems.SelectedItems.Count == 0)
                return;

            Item item = (Item)listViewItems.SelectedItems[0];
            foreach (Book book in DB.DbBooks)
            {
                if (book.ItemCode == item.ItemCode)
                {
                    if (book.Stock > 0)
                    {
                        book.Stock--;
                        MessageBox.Show("Item Add to order");
                    }
                }
            }
            foreach (Journal journal in DB.DbJournals)
            {
                if (journal.ItemCode == item.ItemCode)
                {
                    if (journal.Stock > 0)
                    {
                        journal.Stock--;
                        MessageBox.Show("Item Add to order");
                    }
                }
            }
            listViewItems.Items.Refresh();
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddItem());
        }
    }
}
