using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Globalization;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Employee currentEmployee = new Employee();
        public static long currentItemCode;
        public static long currentPersonID;
        public static string user = "manager";
        public static TransactionShow curentTransaction = new TransactionShow();
        
        public MainWindow()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            InitializeComponent();
            Main.Content = new StoreInventory();
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            EmployeeLogIn login = new EmployeeLogIn();
            login.Show();
            this.Close();
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }
        
        private void btnStoreInventory_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new StoreInventory();
        }

        private void btnContacts_Click(object sender, RoutedEventArgs e)
        {

            Main.Content = new Contacts();
        }

        private void btnCurentOrder_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CurrentOrder();
        }

        private void btnTransactionHistory_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new TransactionHistory();
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ChangePassword();
        }

        private void btnDiscountList_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new DiscountList();

        }
    }
}
