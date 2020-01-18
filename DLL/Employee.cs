using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    public enum EPosition { Manager, Seller };
    public class Employee : Person
    {
        public static int CodeGenerator = 10000;
        public EPosition Position { get; set; }
        public string Password { get; set; }
        public int PersonStoreID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Adress { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        public Employee()
        {
            CodeGenerator++;
            PersonStoreID = CodeGenerator;
        }
    }
}
