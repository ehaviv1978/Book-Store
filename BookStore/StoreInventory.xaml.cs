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
            CalculateDiscounts();
            listViewItems.Items.Refresh();
            if (MainWindow.user == "manager")
            {
                btnAddItem.Visibility = Visibility.Visible;
            }
            else
            {
                btnAddItem.Visibility = Visibility.Hidden;
            }
        }

        private void CalculateDiscounts()
        {
            foreach (Book book in DB.DbBooks)
            {
                foreach (Discount discount in DB.DBDiscounts)
                {
                    if (discount.Percent > book.Discount)
                    {
                        if (discount.Property == DiscountField.BGenre)
                        {
                            if (discount.PropertyValue == book.Genre.ToString())
                            {
                                book.Discount = discount.Percent;
                                book.FinalPrice = 5;// book.Price * (100 - book.Discount) / 100;
                                book.FinalPrice = Math.Round(book.FinalPrice, 2);
                            }
                        }
                        else if (discount.Property == DiscountField.BAuthor)
                        {
                            if (discount.PropertyValue == book.Author)
                            {
                                book.Discount = discount.Percent;
                                book.FinalPrice = 5;// book.Price * (100 - book.Discount) / 100;
                                book.FinalPrice = Math.Round(book.FinalPrice, 2);
                            }
                        }
                        else if (discount.Property == DiscountField.BYearPublished)
                        {
                            if (discount.PropertyValue == book.YearPublished.ToString())
                            {
                                book.Discount = discount.Percent;
                                book.FinalPrice = 5;// book.Price * (100 - book.Discount) / 100;
                                book.FinalPrice = Math.Round(book.FinalPrice, 2);
                            }
                        }
                        else
                        {
                            book.FinalPrice = 5;// book.Price;
                        }
                    }
                        
                }
            }
            foreach (Journal journal in DB.DbJournals)
            {
                foreach (Discount discount in DB.DBDiscounts)
                {
                    if (discount.Property == DiscountField.JGenre && discount.Percent > journal.Discount)
                    {
                        if (discount.PropertyValue == journal.Genre.ToString())
                        {
                            journal.Discount = discount.Percent;
                            journal.FinalPrice = journal.Price * (100 - journal.Discount) / 100;
                            journal.FinalPrice = Math.Round(journal.FinalPrice, 2);
                        }
                        else
                        {
                            journal.FinalPrice = journal.Price;
                        }
                    }
                }
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
            shownItems = Items.FindAll((item => item.Name.ToLower().Replace(" ", "").
                        Contains(TextBoxSerchItem.Text.ToLower().Replace(" ", ""))));
            listViewItems.ItemsSource = shownItems;
            listViewItems.Items.Refresh();
        }

        private void BtnClearSerch_Click(object sender, RoutedEventArgs e)
        {
            TextBoxSerchItem.Text = "";
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listViewItems.SelectedItems.Count >0)
            {
                Item item = (Item)listViewItems.SelectedItems[0];
                MainWindow.currentItemCode = item.ItemCode;
                NavigationService.Navigate(new ItemInfo());
            }
        }

        private void btnAddToOrder_Click(object sender, RoutedEventArgs e)
        {
            if (listViewItems.SelectedItems.Count == 0)
                return;

            Item curentItem = (Item)listViewItems.SelectedItems[0];

            if (curentItem.Stock > 0)
            {
                using Server.Data.BookStoreContext context = new Server.Data.BookStoreContext();
                var item = context.DBItems.Where(x => x.Id == curentItem.Id).FirstOrDefault();
                item.Stock--;
                context.SaveChanges();
                curentItem.Stock = item.Stock;
                DB.DBCurentOrder.Add(curentItem);
                MessageBox.Show("Item Add to order");
            }
            else
            {
                MessageBox.Show("No Item in stock!!");
            }
            listViewItems.Items.Refresh();
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddItem());
        }
    }
}
