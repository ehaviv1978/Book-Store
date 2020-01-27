using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    public class TransactionShow
    {
        //public List<Item> Items { get; set; }
        public int Id { get; set; }
        public Employee Seller { get; set; }
        public Customer Buyer { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
}
