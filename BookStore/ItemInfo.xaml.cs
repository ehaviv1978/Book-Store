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
