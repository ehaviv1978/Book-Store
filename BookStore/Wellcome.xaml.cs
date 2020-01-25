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
            DB.DbCustomers = context.DbCustomers.ToList();
            DB.DbEmployees = context.DbEmployees.ToList();
            DB.DbBooks = context.DbBooks.ToList();
            DB.DbJournals = context.DbJournals.ToList();
            DB.DbTransactions = context.DbTransactions
                .Include(x => x.Buyer)
                .Include(X => X.Seller).ToList();
            DB.DbTransactionItems = context.DbTransactionItems.ToList();
            DB.DBDiscounts = context.DBDiscounts.ToList();
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
