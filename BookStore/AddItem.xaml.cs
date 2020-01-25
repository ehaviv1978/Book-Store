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

            txtAuthor.Visibility = Visibility.Visible;
            txtISBN.Visibility = Visibility.Visible;
            txtPages.Visibility = Visibility.Visible;
            comboPublishedYear.Visibility = Visibility.Visible;
            txtEdition.Visibility = Visibility.Hidden;
            datePrintDate.Visibility = Visibility.Hidden;

            lblAuthor.Visibility = Visibility.Visible;
            lblISBN.Visibility = Visibility.Visible;
            lblPages.Visibility = Visibility.Visible;
            lblYearPublished.Visibility = Visibility.Visible;
            lblEdition.Visibility = Visibility.Hidden;
            lblPrintDate.Visibility = Visibility.Hidden;
        }

        private void radioJournal_Checked(object sender, RoutedEventArgs e)
        {
            ComboGenre.ItemsSource= Enum.GetValues(typeof(DLL.JGenre));

            txtAuthor.Visibility = Visibility.Hidden;
            txtISBN.Visibility = Visibility.Hidden;
            txtPages.Visibility = Visibility.Hidden;
            comboPublishedYear.Visibility = Visibility.Hidden;
            txtEdition.Visibility = Visibility.Visible;
            datePrintDate.Visibility = Visibility.Visible;

            lblAuthor.Visibility = Visibility.Hidden;
            lblISBN.Visibility = Visibility.Hidden;
            lblPages.Visibility = Visibility.Hidden;
            lblYearPublished.Visibility = Visibility.Hidden;
            lblEdition.Visibility = Visibility.Visible;
            lblPrintDate.Visibility = Visibility.Visible;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            using Server.Data.BookStoreContext context = new Server.Data.BookStoreContext();
            if (txtName.Text == "" || txtStock.Text=="" || txtPrice.Text =="")
            {
                MessageBox.Show("Must enter Name, Stock and Price!!");
                return;
            }
            if (radioBook.IsChecked == true)
            {
                context.DbBooks.Add(new Book()
                {
                    Name = txtName.Text,
                    Author = txtAuthor.Text,
                    Stock = (txtStock.Text == "") ? 0 : Convert.ToInt32(txtStock.Text),
                    Price = (txtPrice.Text == "") ? 0 : Convert.ToDouble(txtPrice.Text),
                    Genre = (ComboGenre.Text == "") ? (BGenre)(-1) :(BGenre)ComboGenre.SelectedItem,
                    Description = txtDescription.Text,
                    YearPublished = (comboPublishedYear.Text == "") ? 9999 :Convert.ToInt32(comboPublishedYear.Text),
                    ISBN = (txtISBN.Text == "") ? 0 : Convert.ToInt64(txtISBN.Text),                
                    Pages = (txtPages.Text == "") ? 0 : Convert.ToInt32(txtPages.Text) 
                        
                });
               
                context.SaveChanges();
                DB.DbBooks = context.DbBooks.ToList<Book>();
            }
            else
            {
                context.DbJournals.Add(new Journal()
                {
                    Name = txtName.Text,
                    Stock = (txtStock.Text == "") ? 0 : Convert.ToInt32(txtStock.Text),
                    Price = (txtPrice.Text == "") ? 0 : Convert.ToDouble(txtPrice.Text),
                    Genre = (ComboGenre.Text == "") ? (JGenre)(-1) : (JGenre)ComboGenre.SelectedItem,
                    Description = txtDescription.Text,
                    Edition = (txtEdition.Text =="") ? 0 :Convert.ToInt32(txtEdition.Text),
                    PrintDate = datePrintDate.SelectedDate,
                });

                context.SaveChanges();
                DB.DbJournals = context.DbJournals.ToList();
            }
            MessageBox.Show("New Item Add to Inventory");
            NavigationService.Navigate(new StoreInventory());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StoreInventory());
        }
    }
}
