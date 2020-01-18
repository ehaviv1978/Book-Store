using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    public class Customer : Person
    {
        public List<Transaction> BuyHistory;
        public static int CodeGenerator = 20000;

        public int PersonStoreID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Adress { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        public Customer()
        {
            CodeGenerator++;
            PersonStoreID = CodeGenerator;
        }
    }

}
