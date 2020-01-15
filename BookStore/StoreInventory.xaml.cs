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
    public partial class StoreInventory : Page
    {
        List<Item> itemList= new List<Item>();
        public StoreInventory()
        {
            InitializeItemList();
            InitializeComponent();
            listViewItems.ItemsSource = itemList;
        }

        public void InitializeItemList()
        {
            itemList.Clear();
            foreach (Book book in DB.DbBooks)
            {
                Item item = new Item();
                item.ItemCode = book.ItemCode;
                item.Name = book.Name;
                item.Stock = book.Stock;
                item.Price = book.Price;
                item.Description = book.Description;
                itemList.Add(item);
            }
            foreach (Journal journal in DB.DbJournals)
            {
                Item item = new Item();
                item.ItemCode = journal.ItemCode;
                item.Name = journal.Name;
                item.Stock = journal.Stock;
                item.Price = journal.Price;
                item.Edition = journal.Edition;
                item.Description = journal.Description;
                itemList.Add(item);
            }
        }

        private void RadioAll_Checked(object sender, RoutedEventArgs e)
        {
            listViewItems.ItemsSource = DB.DbJournals; //bug fix
            listViewItems.ItemsSource = DB.DbBooks; //bug fix
            InitializeItemList();
            listViewItems.ItemsSource = itemList;
        }

        private void RadioBooks_Checked(object sender, RoutedEventArgs e)
        {
            itemList.Clear();
            foreach (Book book in DB.DbBooks)
            {
                Item item = new Item();
                item.ItemCode = book.ItemCode;
                item.Name = book.Name;
                item.Stock = book.Stock;
                item.Price = book.Price;
                item.Description = book.Description;
                itemList.Add(item);
            }
            listViewItems.ItemsSource = DB.DbJournals; //bug fix
            listViewItems.ItemsSource = itemList;

        }


        private void RadioJournals_Checked(object sender, RoutedEventArgs e)
        {
            itemList.Clear();
            foreach (Journal journal in DB.DbJournals)
            {
                Item item = new Item();
                item.ItemCode = journal.ItemCode;
                item.Name = journal.Name;
                item.Stock = journal.Stock;
                item.Price = journal.Price;
                item.Edition = journal.Edition;
                item.Description = journal.Description;
                itemList.Add(item);
            }
            listViewItems.ItemsSource = DB.DbJournals; //bug fix
            listViewItems.ItemsSource = itemList;

        }

        private void TextBoxSerchItem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RadioAll != null)
            {
                RadioAll.IsChecked = true;
            }
   
            List<Item> showList = new List<Item>();
            InitializeItemList();

            foreach (Item item in itemList)
            {
                string name = item.Name.ToLower().Replace(" ", "");
                if (name.Contains(TextBoxSerchItem.Text.ToLower().Replace(" ", "")))
                    showList.Add(item);
            }

            itemList = showList;
            listViewItems.ItemsSource = DB.DbJournals; //bug fix
            listViewItems.ItemsSource = DB.DbBooks; //bug fix
            listViewItems.ItemsSource = itemList;
        }

        private void BtnClearSerch_Click(object sender, RoutedEventArgs e)
        {
            TextBoxSerchItem.Text = "";
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

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
                    }
                }
            }

            listViewItems.ItemsSource = DB.DbJournals; //bug fix
            listViewItems.ItemsSource = DB.DbBooks; //bug fix
            InitializeItemList();
            listViewItems.ItemsSource = itemList;
        }

        private void listViewItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
