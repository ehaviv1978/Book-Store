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
        public ItemInfo()
        {
            InitializeComponent();

            comboPublishedYear.Visibility = Visibility.Hidden;
            ComboGenre.Visibility = Visibility.Hidden;

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
            datePrintDate.IsEnabled = false;

            foreach (Book book in DB.DbBooks)
            {
                if (book.ItemCode== MainWindow.curentItemCode)
                {
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
                  
                }
            }
            foreach (Journal journal in DB.DbJournals)
            {
                if (journal.ItemCode == MainWindow.curentItemCode)
                {
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
    }
}
