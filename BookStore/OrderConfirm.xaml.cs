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
    /// <summary>
    /// Interaction logic for OrderConfirm.xaml
    /// </summary>
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
            foreach (Customer customer in DB.DbCustomers)
            {
                if (comboCustomer.Text == customer.FirstName + " " + customer.LastName)
                {
                    buyer = customer;
                    txtPhone.Text = buyer.PhoneNumber.ToString();
                }
            }
            if (seller.PersonStoreID != 0 && buyer.PersonStoreID != 0)
            {
                btnConfirm.IsEnabled = true;
            }

        }


        private void ComboSeller_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboSeller.Text = ComboSeller.SelectedItem.ToString();
            foreach (Employee employee in DB.DbEmployees)
            {
                if (ComboSeller.Text == employee.FirstName + " " + employee.LastName)
                {
                    seller = employee;
                }
            }
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

                //List<Item> order = new List<Item>();
                //foreach (Item item in DB.DBCurentOrder)
                //{
                //    order.Add(item);
                //}
                //Transaction sell = new Transaction();
                //sell.Buyer = buyer;
                //sell.Date = DateTime.Now;
                //sell.Seller = seller;
                ////sell.Items = order;
                //sell.Price = totalPrice;

                context.DbTransactions.Add(new Transaction()
                {
                    Seller = seller,
                    Buyer = buyer,
                    Price = totalPrice,
                    Date = DateTime.Now,
                });
                //context.DbTransactions.Add(sell);
                context.SaveChanges();
                DB.DbTransactions = context.DbTransactions.Include(x => x.Buyer).Include(X => X.Seller).ToList();
                DB.DBCurentOrder.Clear();
                MessageBox.Show("Order Confirmed");
                NavigationService.Navigate(new TransactionHistory());

            }
        }
    }
}
