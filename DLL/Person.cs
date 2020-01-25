using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    public abstract class Person
    {
        public int Id { get; set; }
        public long PersonStoreID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Adress { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
