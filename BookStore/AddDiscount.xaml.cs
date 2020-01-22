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
    /// Interaction logic for AddDiscount.xaml
    /// </summary>
    public partial class AddDiscount : Page
    {
        public AddDiscount()
        {
            InitializeComponent();
            for (int i = 1; i < 101; i++)
            {
                ComboPercent.Items.Add(i);
                comboDiscountBy.ItemsSource = Enum.GetValues(typeof(DLL.DiscountField));
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DiscountList());
        }

        private void comboDiscountBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboDiscountBy.Text = comboDiscountBy.SelectedItem.ToString();
            comboUseValue.Text = "";
            comboUseValue.ItemsSource = null;
            comboUseValue.Items.Clear();
            comboUseValue.SelectedItem = null;
            comboUseValue.SelectedIndex = -1;
            comboUseValue.ItemsSource = null;
            switch (comboDiscountBy.Text.ToString())
            {
                case "BGenre":
                    comboUseValue.ItemsSource = Enum.GetValues(typeof(DLL.BGenre));
                    break;
                case "JGenre":
                    comboUseValue.ItemsSource = Enum.GetValues(typeof(DLL.JGenre));
                    break;
                case "BAuthor":
                    foreach (Book book in DB.DbBooks)
                    {
                        comboUseValue.Items.Add(book.Author);
                    }
                    break;
                case "BYearPublished":
                    foreach (Book book in DB.DbBooks)
                    {
                        comboUseValue.Items.Add(book.YearPublished);
                    }
                    break;
                default:
                    break;

            }
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Add Discount", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                DB.DBDiscounts.Add(new Discount()
                {
                    Property = (DiscountField)comboDiscountBy.SelectedItem,
                    PropertyValue = comboUseValue.Text,
                    Percent = Convert.ToInt32(ComboPercent.Text)
                }) ;
                MessageBox.Show("Discount add");
                NavigationService.Navigate(new DiscountList());

            }
        }
    }
}
