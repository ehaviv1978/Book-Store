using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DLL;

namespace Server.Data
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Discount> DBDiscounts { get; set; }
        public DbSet<Item> DBItems { get; set;}
        public  DbSet<Book> DbBooks { get; set; }
        public DbSet<Journal> DbJournals { get; set; }
        public DbSet<Customer> DbCustomers { get; set; }
        public DbSet<Employee> DbEmployees { get; set; }
        public DbSet<Transaction> DbTransactions { get; set; }
        public DbSet<Person> DbPersons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=LibraryStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
   
}
