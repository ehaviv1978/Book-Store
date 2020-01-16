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
using System.Text.RegularExpressions;
using System.Linq;
using DLL;
using Server;

namespace GUI
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Page
    {
        public AddItem()
        {
            InitializeComponent();
            radioBook.IsChecked = true;
            for (int i = 0; i <= DateTime.Now.Year; i++)
            {
                comboPublishedYear.Items.Add(i);
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBoxSerchItem_TextChanged(object sender, TextChangedEventArgs e)
        {
            string strTemp= txtPrice.Text;
            int i = 0;
            foreach (char item in txtPrice.Text)
            {           
                if (!string.Equals(item.ToString(),"0")&& !string.Equals(item.ToString(), "1") && !string.Equals(item.ToString(), "2") &&
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

        private void radioBook_Checked(object sender, RoutedEventArgs e)
        {
            ComboGenre.ItemsSource = Enum.GetValues(typeof(DLL.BGenre));

            txtAuthor.IsEnabled = true;
            txtISBN.IsEnabled = true;
            txtPages.IsEnabled = true;
            comboPublishedYear.IsEnabled = true;
            txtEdition.IsEnabled = false;
            datePrintDate.IsEnabled = false;

            lblAuthor.IsEnabled = true;
            lblISBN.IsEnabled = true;
            lblPages.IsEnabled = true;
            lblYearPublished.IsEnabled = true;
            lblEdition.IsEnabled = false;
            lblPrintDate.IsEnabled = false;


        }

        private void radioJournal_Checked(object sender, RoutedEventArgs e)
        {
            ComboGenre.ItemsSource= Enum.GetValues(typeof(DLL.JGenre));

            txtAuthor.IsEnabled = false;
            txtISBN.IsEnabled = false;
            txtPages.IsEnabled = false;
            comboPublishedYear.IsEnabled = false;
            txtEdition.IsEnabled = true;
            datePrintDate.IsEnabled = true;

            lblAuthor.IsEnabled = false;
            lblISBN.IsEnabled = false;
            lblPages.IsEnabled = false;
            lblYearPublished.IsEnabled = false;
            lblEdition.IsEnabled = true;
            lblPrintDate.IsEnabled = true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtStock.Text=="" || txtPrice.Text =="")
            {
                MessageBox.Show("Must enter Name, Stock and Price!!");
                return;
            }
            if (radioBook.IsChecked == true)
            {
                Book book = new Book();
                book.Name = txtName.Text;
                book.Stock = Convert.ToInt32(txtStock.Text);
                book.Price = Convert.ToDouble(txtPrice.Text);
                if (ComboGenre.SelectedItem != null)
                {
                    book.Genre = (DLL.BGenre)ComboGenre.SelectedItem;
                }
                book.Author = txtAuthor.Text;
                if (txtPages.Text != "")
                {
                    book.Pages = Convert.ToInt32(txtPages.Text);
                }
                if (comboPublishedYear.Text != "")
                {
                    book.YearPublished = Convert.ToInt32(comboPublishedYear.Text);
                }
                if (txtISBN.Text != "")
                {
                    book.ISBN = Convert.ToInt32(txtISBN.Text);
                }
                book.Description = txtDescription.Text;

                DB.DbBooks.Add(book);
            }
            else
            {
                Journal journal = new Journal();
                journal.Name = txtName.Text;
                journal.Stock = Convert.ToInt32(txtStock.Text);
                journal.Price = Convert.ToDouble(txtPrice.Text);
                if (ComboGenre.SelectedItem != null)
                {
                    journal.Genre = (DLL.JGenre)ComboGenre.SelectedItem;
                }
                if (txtEdition.Text != "")
                {
                    journal.Edition = Convert.ToInt32(txtEdition.Text);
                }
                journal.PrintDate = datePrintDate.SelectedDate;
                journal.Description = txtDescription.Text;

                DB.DbJournals.Add(journal);
            }
            MessageBox.Show("New Item Add to Inventory");
        }
    }
}
