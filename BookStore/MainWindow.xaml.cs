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

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int currentItemCode;
        public static int currentPersonID;
        public static string user = "manager";
        public MainWindow()
        {
            
            InitializeComponent();
           // Page Inventory = new StoreInventory();
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

        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new RemoveItem();
        }

        private void btnContacts_Click(object sender, RoutedEventArgs e)
        {

            Main.Content = new Contacts();
        }
    }
}
