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
using System.Windows.Shapes;
using DLL;
using Server;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace GUI
{
    public partial class WindowWelcome : Window
    {
        
        public WindowWelcome()
        {
       
            InitializeComponent();
            InitializeDbBook();
            InitializeDbJournals();
            InitializeDbEmployees();
            InitializeDbCustomers();
            InitializeDbTransactions();
            InitializeDBDiscounts();
            InitializeDbTransactionItems();
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }

        public void InitializeDbCustomers()
        {
            using Server.Data.BookStoreContext context = new Server.Data.BookStoreContext();
            var Coustomers = context.DbCustomers;
            foreach (Person coustomer in Coustomers)
            {
                DB.DbCustomers.Add(new Customer()
                {
                    FirstName = coustomer.FirstName,
                    LastName = coustomer.LastName,
                    PhoneNumber = coustomer.PhoneNumber,
                    Email = coustomer.Email,
                    Adress = coustomer.Adress,
                    Birthdate = coustomer.Birthdate,
                    TotalSpent = 99.99,
                });
            }
        }

        public void InitializeDbEmployees()
        {
            using Server.Data.BookStoreContext context = new Server.Data.BookStoreContext();
            var Employees = context.DbEmployees;
            foreach (Employee employee in Employees)
            {
                DB.DbEmployees.Add(new Employee()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Password = employee.Password,
                    Position = employee.Position,
                    PhoneNumber = employee.PhoneNumber,
                    Email = employee.Email,
                    Adress = employee.Adress,
                    Birthdate = employee.Birthdate,
                });
            }
        }

        public void InitializeDbBook()
        {
            using Server.Data.BookStoreContext context = new Server.Data.BookStoreContext();
            var Books = context.DbBooks;
            foreach (Book book in Books)
            {
                DB.DbBooks.Add(new Book()
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    Stock = book.Stock,
                    Price = book.Price,
                    Genre = book.Genre,
                    Description = book.Description,
                    YearPublished = book.YearPublished,
                    ISBN = book.ISBN,
                    Pages = book.Pages
                }) ;
            }
        }

        public void InitializeDbJournals()
        {
            using Server.Data.BookStoreContext context = new Server.Data.BookStoreContext();
            var journals = context.DbJournals;
            foreach (Journal journal in journals)
            {
                DB.DbJournals.Add(new Journal()
                {
                    Id = journal.Id,
                    Name = journal.Name,
                    Stock = journal.Stock,
                    Price = journal.Price,
                    Genre = journal.Genre,
                    Description = journal.Description,
                    Edition = journal.Edition,
                    PrintDate = journal.PrintDate
                });
            }
        }

        public void InitializeDbTransactions()
        {
            using Server.Data.BookStoreContext context = new Server.Data.BookStoreContext();
            var transactions = context.DbTransactions
                .Include(x => x.Buyer)
                .Include(X => X.Seller);
            foreach (Transaction transaction in transactions)
            {
                DB.DbTransactions.Add(new Transaction()
                {
                    Id = transaction.Id,
                    Seller = transaction.Seller,
                    Buyer = transaction.Buyer,
                    Price = transaction.Price,
                    Date = transaction.Date,
                    Items = new List<Item>()// { DB.DbBooks[2], DB.DbJournals[3] }
                }) ;
            }
          
        }

        public void InitializeDbTransactionItems()
        {
            using Server.Data.BookStoreContext context = new Server.Data.BookStoreContext();
            var transactionItems = context.DbTransactionItems;
            foreach (TransactionItem transactionItem in transactionItems)
            {
                DB.DbTransactionItems.Add(new TransactionItem()
                {
                    Id = transactionItem.Id,
                    TransactionID = transactionItem.TransactionID,
                    ItemID = transactionItem.ItemID
                }) ;
                    

            }
        }

        public void InitializeDBDiscounts()
        {
            using Server.Data.BookStoreContext context = new Server.Data.BookStoreContext();
            var discounts = context.DBDiscounts;
            foreach (Discount discount in discounts)
            {
                DB.DBDiscounts.Add(new Discount()
                {
                    Property = discount.Property,
                    PropertyValue = discount.PropertyValue,
                    Percent = discount.Percent
                });
            }
             
        }

        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            nextWindow();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            nextWindow();
        }

        private void nextWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            //EmployeeLogIn login = new EmployeeLogIn();
            //login.Show();
            this.Close();
        }
    }
}
