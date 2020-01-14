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
        
        public MainWindow()
        {
            InitializeComponent();
            List<Item> itemList = InitializeItemList();
            listViewItems.ItemsSource = itemList;
        }

        public List<Item> InitializeItemList()
        {
            List<Item> itemList = new List<Item>();
            foreach (Book book in DB.DbBooks)
            {
                Item item = new Item();
                item.ItemCode = book.ItemCode;
                item.Name = book.Name;
                item.Stock = book.Stock;
                item.Price = book.Price;
                item.Description = book.Description;
                itemList.Add(item);
            }
            foreach (Journal journal in DB.DbJournals)
            {
                Item item = new Item();
                item.ItemCode = journal.ItemCode;
                item.Name = journal.Name;
                item.Stock = journal.Stock;
                item.Price = journal.Price;
                item.Edition = journal.Edition;
                item.Description = journal.Description;
                itemList.Add(item);
            }
            return itemList;
        }

        private void RadioBooks_Checked(object sender, RoutedEventArgs e)
        {
            listViewItems.ItemsSource = DB.DbBooks;
        }

        private void RadioAll_Checked(object sender, RoutedEventArgs e)
        {
            List<Item> itemList = InitializeItemList();
            listViewItems.ItemsSource = itemList;
        }

        private void RadioJournals_Checked(object sender, RoutedEventArgs e)
        {
            listViewItems.ItemsSource = DB.DbJournals;
        }


        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            EmployeeLogIn login = new EmployeeLogIn();
            login.Show();
            this.Close();
        }
    }
}
