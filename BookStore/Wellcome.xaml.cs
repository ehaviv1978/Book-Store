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
            InitializeDB();
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }

        public void InitializeDB()
        {
            using Server.Data.BookStoreContext context = new Server.Data.BookStoreContext();
            DB.DbCustomers = context.DbCustomers.ToList<Customer>();
            DB.DbEmployees = context.DbEmployees.ToList<Employee>();
            DB.DbBooks = context.DbBooks.ToList<Book>();
            DB.DbJournals = context.DbJournals.ToList<Journal>();
            DB.DbTransactions = context.DbTransactions
                .Include(x => x.Buyer)
                .Include(X => X.Seller).ToList<Transaction>();
            DB.DbTransactionItems = context.DbTransactionItems.ToList<TransactionItem>();
            DB.DBDiscounts = context.DBDiscounts.ToList<Discount>();
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
