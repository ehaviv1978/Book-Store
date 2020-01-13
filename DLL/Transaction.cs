using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreC
{
    class Transaction
    {
        public int ItemCode;
        public Employee Seller;
        public Customer Buyer;
        public DateTime Date;
        public double Price;
    }
}
