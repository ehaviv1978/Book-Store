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
using System.Linq;


namespace GUI
{
    /// <summary>
    /// Interaction logic for TransactionInfo.xaml
    /// </summary>
    public partial class TransactionInfo : Page
    {
        public TransactionInfo()
        {
            InitializeComponent();
            txtBuyer.IsReadOnly = true;
            txtDate.IsReadOnly = true;
            txtItems.IsReadOnly = true;
            txtSeller.IsReadOnly = true;
            txtTotal.IsReadOnly = true;
            using Server.Data.BookStoreContext context = new Server.Data.BookStoreContext();

            string items = "";
            foreach (TransactionItem itemId in DB.DbTransactionItems)
            {
                if (MainWindow.curentTransaction.Id == itemId.TransactionID)
                {
                    var item = context.DBItems.Where(item => item.Id == itemId.ItemID).FirstOrDefault();
                    items += item.ItemCode + "  -  " + item.Name + "\n";
                }
            }

            txtTotal.Text = MainWindow.curentTransaction.Price.ToString();
            txtSeller.Text = MainWindow.curentTransaction.Seller.FirstName + " " + MainWindow.curentTransaction.Seller.LastName;
            txtBuyer.Text = MainWindow.curentTransaction.Buyer.FirstName + " " + MainWindow.curentTransaction.Buyer.LastName;
            txtDate.Text = MainWindow.curentTransaction.Date.ToString();
            txtItems.Text = items;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TransactionHistory());
        }
    }
}
