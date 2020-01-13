using BookStoreC;
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

namespace BookStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public List<Item> items { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            List<Item> items = new List<Item>();
            items.Add(new Item() { Name = "Eran", ItemCode =1, PrintDate =DateTime.Now, Price = 10, Description = "fdsafa"});
            items.Add(new Item() { Name = "Jane Doe"});
            items.Add(new Item() { Name = "Sammy Doe"});
            listViewItems.ItemsSource = items;
        }
    }
}
