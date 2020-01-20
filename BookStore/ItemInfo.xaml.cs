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
using System.Text.RegularExpressions;


namespace GUI
{
    /// <summary>
    /// Interaction logic for ItemInfo.xaml
    /// </summary>
    public partial class ItemInfo : Page
    {
        string itemType;
        Item curentItem;
        public ItemInfo()
        {
            InitializeComponent();
            btnSave.Visibility = Visibility.Hidden;
            btnCancel.Visibility = Visibility.Hidden;
            datePrintDate.Focusable = false;
            datePrintDate.IsHitTestVisible = false;
            ComboGenre.ItemsSource = Enum.GetValues(typeof(DLL.BGenre));
            for (int i = 0; i <= DateTime.Now.Year; i++)
            {
                comboPublishedYear.Items.Add(i);
            }

            if (MainWindow.user == "seller")
            {
                btnDeleteItem.Visibility = Visibility.Hidden;
                btnEditItem.Visibility = Visibility.Hidden;
            }

            comboPublishedYear.Visibility = Visibility.Hidden;
            ComboGenre.Visibility = Visibility.Hidden;

            txtDiscount.IsReadOnly = true;
            txtCode.IsReadOnly = true;
            txtName.IsReadOnly = true;
            txtPrice.IsReadOnly = true;
            txtDescription.IsReadOnly = true;
            txtGenre.IsReadOnly = true;
            txtStock.IsReadOnly = true;
            txtAuthor.IsReadOnly = true;
            txtISBN.IsReadOnly = true;
            txtYearPublished.IsReadOnly = true;
            txtPages.IsReadOnly = true;
            txtEdition.IsReadOnly = true;

            foreach (Book book in DB.DbBooks)
            {
                if (book.ItemCode== MainWindow.currentItemCode)
                {
                    txtDiscount.Text = book.Discount.ToString();
                    curentItem = book;
                    itemType = "book";
                    lblHeader.Content = "Book Information:";
                    txtCode.Text = book.ItemCode.ToString();
                    txtName.Text = book.Name;
                    txtPrice.Text = book.Price.ToString();
                    txtDescription.Text = book.Description;
                    txtGenre.Text = book.Genre.ToString();
                    txtStock.Text = book.Stock.ToString();
                    txtAuthor.Text = book.Author;
                    txtISBN.Text = book.ISBN.ToString();
                    txtYearPublished.Text = book.YearPublished.ToString();
                    txtPages.Text = book.Pages.ToString();

                    txtEdition.Visibility = Visibility.Hidden;
                    datePrintDate.Visibility = Visibility.Hidden;

                    lblEdition.Visibility = Visibility.Hidden;
                    lblPrintDate.Visibility = Visibility.Hidden;
                    break;
                }
                itemJournal();
            }

        }

        private void itemJournal()
        {
            foreach (Journal journal in DB.DbJournals)
            {
                if (journal.ItemCode == MainWindow.currentItemCode)
                {
                    txtDiscount.Text = journal.Discount.ToString();
                    curentItem = journal;
                    itemType = "journal";
                    lblHeader.Content = "Journal Information:";
                    txtCode.Text = journal.ItemCode.ToString();
                    txtName.Text = journal.Name;
                    txtPrice.Text = journal.Price.ToString();
                    txtDescription.Text = journal.Description;
                    txtGenre.Text = journal.Genre.ToString();
                    txtStock.Text = journal.Stock.ToString();
                    txtEdition.Text = journal.Edition.ToString();
                    datePrintDate.Text = journal.PrintDate.ToString();

                    txtAuthor.Visibility = Visibility.Hidden;
                    txtISBN.Visibility = Visibility.Hidden;
                    txtYearPublished.Visibility = Visibility.Hidden;
                    txtPages.Visibility = Visibility.Hidden;

                    lblAuthor.Visibility = Visibility.Hidden;
                    lblISBN.Visibility = Visibility.Hidden;
                    lblYearPublished.Visibility = Visibility.Hidden;
                    lblPages.Visibility = Visibility.Hidden;
                    break;
                }
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBoxSerchItem_TextChanged(object sender, TextChangedEventArgs e)
        {
            string strTemp = txtPrice.Text;
            int i = 0;
            foreach (char item in txtPrice.Text)
            {
                if (!string.Equals(item.ToString(), "0") && !string.Equals(item.ToString(), "1") && !string.Equals(item.ToString(), "2") &&
                    !string.Equals(item.ToString(), "3") && !string.Equals(item.ToString(), "4") && !string.Equals(item.ToString(), "5") &&
                    !string.Equals(item.ToString(), "6") && !string.Equals(item.ToString(), "7") && !string.Equals(item.ToString(), "8") &&
                    !string.Equals(item.ToString(), "9") && !string.Equals(item.ToString(), "."))
                {
                    strTemp = txtPrice.Text.Remove(i, 1);
                }
                i++;
            }
            txtPrice.Text = strTemp;

        }

        private void btnAddToOrder_Click(object sender, RoutedEventArgs e)
        {
            if (curentItem.Stock > 0)
            {
                curentItem.Stock--;
                DB.DBCurentOrder.Add(curentItem);
                txtStock.Text = curentItem.Stock.ToString();
                MessageBox.Show("Item Add to order");
            }
            else
            {
                MessageBox.Show("No Item in stock!!");
            }
        }

        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                foreach (Book book in DB.DbBooks)
                {
                    if (book.ItemCode == curentItem.ItemCode)
                    {
                        DB.DbBooks.Remove(book);
                        MessageBox.Show("Item Deleted");
                        NavigationService.Navigate(new StoreInventory());
                        break;
                    }
                }
                foreach (Journal journal in DB.DbJournals)
                {
                    if (journal.ItemCode == curentItem.ItemCode)
                    {
                        DB.DbJournals.Remove(journal);
                        MessageBox.Show("Item Deleted");
                        NavigationService.Navigate(new StoreInventory());
                        break;
                    }
                }
            }
        }

        private void btnEditItem_Click(object sender, RoutedEventArgs e)
        {
            btnCancel.Visibility = Visibility.Visible;
            btnDeleteItem.Visibility = Visibility.Hidden;
            btnEditItem.Visibility = Visibility.Hidden;
            btnAddToOrder.Visibility = Visibility.Hidden;
            btnSave.Visibility = Visibility.Visible;
            //txtCode.IsReadOnly = false;
            txtName.IsReadOnly = false;
            txtPrice.IsReadOnly = false;
            txtDescription.IsReadOnly = false;
            //txtGenre.IsReadOnly = false;
            txtStock.IsReadOnly = false;
            txtAuthor.IsReadOnly = false;
            txtISBN.IsReadOnly = false;
            //txtYearPublished.IsReadOnly = false;
            txtPages.IsReadOnly = false;
            txtEdition.IsReadOnly = false;
            datePrintDate.Focusable = true;
            datePrintDate.IsHitTestVisible = true;

            if (itemType == "book")
            {
               
                comboPublishedYear.Visibility = Visibility.Visible;
                ComboGenre.Visibility = Visibility.Visible;
                comboPublishedYear.Text = txtYearPublished.Text;
            }
            else
            {
                ComboGenre.ItemsSource = Enum.GetValues(typeof(DLL.JGenre));
                ComboGenre.Visibility = Visibility.Visible;
            }
            ComboGenre.Text = txtGenre.Text;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Change Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (itemType == "book")
                {
                    foreach (Book book in DB.DbBooks)
                    {
                        if (book.ItemCode == MainWindow.currentItemCode)
                        {
                            book.Description = txtDescription.Text;
                            book.Name = txtName.Text;
                            book.Price = Convert.ToDouble(txtPrice.Text);
                            book.Stock = Convert.ToInt32(txtStock.Text);
                            book.Description = txtDescription.Text;
                            book.Author = txtAuthor.Text;
                            book.ISBN = Convert.ToInt32(txtISBN.Text);
                            book.Pages = Convert.ToInt32(txtPages.Text);
                            book.YearPublished = Convert.ToInt32(txtYearPublished.Text);
                            book.Genre = (BGenre)ComboGenre.SelectedItem;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (Journal journal in DB.DbJournals)
                    {
                        if (journal.ItemCode == MainWindow.currentItemCode)
                        {
                            journal.Description = txtDescription.Text;
                            journal.Name = txtName.Text;
                            journal.Price = Convert.ToInt32(txtPrice.Text);
                            journal.Stock = Convert.ToInt32(txtStock.Text);
                            journal.Description = txtDescription.Text;
                            journal.Edition = Convert.ToInt32(txtEdition.Text);
                            journal.PrintDate = datePrintDate.SelectedDate;
                            break;
                        }
                    }
                }
                MessageBox.Show("Changes Saved");
                NavigationService.Navigate(new StoreInventory());
            }
        }

        private void ComboGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboGenre.Text = ComboGenre.SelectedItem.ToString();
            txtGenre.Text = ComboGenre.Text;
        }

        private void comboPublishedYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboPublishedYear.Text = comboPublishedYear.SelectedItem.ToString();
            txtYearPublished.Text = comboPublishedYear.Text;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Cancel Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new ItemInfo());
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StoreInventory());
        }
    }
}
