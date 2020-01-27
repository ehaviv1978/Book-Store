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
using Microsoft.EntityFrameworkCore;

namespace GUI
{
    public partial class OrderConfirm : Page
    {
        Employee seller = new Employee();
        Customer buyer = new Customer();
        double totalPrice = 0;
           
    public OrderConfirm()
        {
            InitializeComponent();
            seller.PersonStoreID = 0;
            buyer.PersonStoreID = 0;
            btnConfirm.IsEnabled = false;
            foreach (Item item in DB.DBCurentOrder)
            {
                totalPrice += item.FinalPrice;
            }
            foreach (Employee employee in DB.DbEmployees)
            {
                ComboSeller.Items.Add(employee.FirstName + " " + employee.LastName);
            }
            foreach (Customer customer in DB.DbCustomers)
            {
                comboCustomer.Items.Add(customer.FirstName + " " + customer.LastName);
            }

            txtPhone.IsReadOnly = true;
            txtItemNumber.IsReadOnly = true;
            txtItemNumber.Text = DB.DBCurentOrder.Count.ToString();
            txtTotal.Text = totalPrice.ToString();
        }

        private void comboCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboCustomer.Text = comboCustomer.SelectedItem.ToString();
            using Server.Data.BookStoreContext context = new Server.Data.BookStoreContext();
            buyer = context.DbCustomers.Where(x => (x.FirstName + " " + x.LastName) == comboCustomer.Text).FirstOrDefault();
            txtPhone.Text = buyer.PhoneNumber.ToString();
            if (seller.PersonStoreID != 0 && buyer.PersonStoreID != 0)
            {
                btnConfirm.IsEnabled = true;
            }

        }


        private void ComboSeller_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboSeller.Text = ComboSeller.SelectedItem.ToString();
            using Server.Data.BookStoreContext context = new Server.Data.BookStoreContext();
            seller = context.DbEmployees.Where(x => (x.FirstName + " " + x.LastName) == ComboSeller.Text).FirstOrDefault();
            if (seller.PersonStoreID !=0 && buyer.PersonStoreID !=0)
            {
                btnConfirm.IsEnabled = true;
            }
        }
        private void btnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCustomer());
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CurrentOrder());
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Order Confirm", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                using Server.Data.BookStoreContext context = new Server.Data.BookStoreContext();
                context.DbTransactions.Add(new Transaction()
                {
                    SellerId = context.DbPersons.Where(x=>x.PersonStoreID ==seller.PersonStoreID).FirstOrDefault().Id,
                    BuyerId = context.DbPersons.Where(x => x.PersonStoreID == buyer.PersonStoreID).FirstOrDefault().Id,
                    Price = totalPrice,
                    Date = DateTime.Now,
                });
                context.SaveChanges();
                DB.DbTransactions = context.DbTransactions.ToList();
                DB.transactionShows.Add(new TransactionShow
                {
                    Id = DB.DbTransactions.Last().Id,
                    Buyer = buyer,
                    Seller = seller,
                    Price = totalPrice,
                    Date = DateTime.Now
                });
                foreach (Item item in DB.DBCurentOrder)
                {
                    context.DbTransactionItems.Add(new TransactionItem
                    {
                        ItemID = item.Id,
                        TransactionID = DB.DbTransactions.Last().Id,
                    });
                }
                context.SaveChanges();
                DB.DbTransactionItems = context.DbTransactionItems.ToList();
                DB.DBCurentOrder.Clear();
                MessageBox.Show("Order Confirmed");
                NavigationService.Navigate(new TransactionHistory());
            }
        }
    }
}
