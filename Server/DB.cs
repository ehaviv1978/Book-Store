 using System;
using System.Collections.Generic;
using System.Text;
using DLL;

namespace Server
{
    public static class DB
    {
        public static List<Discount> DBDiscounts = new List<Discount>();
        public static List<Item> DBCurentOrder = new List<Item>();
        public static List<Book> DbBooks = new List<Book>();
        public static List<Journal> DbJournals = new List<Journal>();
        public static List<Customer> DbCustomers = new List<Customer>();
        public static List<Employee> DbEmployees = new List<Employee>();
        public static List<Transaction> DbTransactions = new List<Transaction>();
        public static List<TransactionItem> DbTransactionItems = new List<TransactionItem>();
        public static List<TransactionShow> transactionShows = new List<TransactionShow>();
    }
   
}
