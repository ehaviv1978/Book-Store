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
            InitializeDbBook();
            InitializeDbJournals();
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
                itemList.Add(item);
            }
            return itemList;
        }

        public void InitializeDbBook()
        {
            DB.DbBooks.Add(new Book()
            {
                ItemCode = 99,
                Name = "Dune",
                Author = "Frank Herbert",
                Stock = 5,
                Price = 75.99,
                Genre = BGenre.SciFi,
                Description = "Best SciFi book",
                YearPublished = 1990,
                ISBN = 0441172717,
                Pages = 412
            });
            DB.DbBooks.Add(new Book()
            {
                ItemCode = 77,
                Name = "The English Patient",
                Author = "Michael Ondaatje",
                Stock = 2,
                Price = 39.99,
                Genre = BGenre.Novel,
                Description = "WW2 Eara Moving noval",
                YearPublished = 1992,
                ISBN = 0771068867,
                Pages = 320
            });
        }

        public void InitializeDbJournals()
        {
            DB.DbJournals.Add(new Journal()
            {
                ItemCode = 880,
                Name = "Popular Science",
                Stock = 5,
                Price = 5.99,
                Genre = JGenre.Science,
                Description = "American quarterly magazine carrying popular science content",
                Edition =45,
                PrintDate = new DateTime(2008, 3, 1)
            });
            DB.DbJournals.Add(new Journal()
            {
                ItemCode = 890,
                Name = "Popular Science",
                Stock = 5,
                Price = 5.99,
                Genre = JGenre.Science,
                Description = "American quarterly magazine carrying popular science content",
                Edition = 46,
                PrintDate = new DateTime(2008, 4, 1)
            });

        }
    }
}
