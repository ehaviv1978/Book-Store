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
    /// <summary>
    /// Interaction logic for TransactionHistory.xaml
    /// </summary>
    public partial class TransactionHistory : Page
    {
        public TransactionHistory()
        {
            InitializeComponent();
            listViewItems.ItemsSource = DB.DbTransactions;

        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Transaction transaction= (Transaction)listViewItems.SelectedItems[0];
            MainWindow.curentTransaction = transaction;
            NavigationService.Navigate(new TransactionInfo());
        }
    }
}
