using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    public enum EPosition { Manager, Seller };
    public class Employee : Person
    {
        public int Id { get; set; }
        public EPosition Position { get; set; }
        public string Password { get; set; }

        public Employee()
        {       
            PersonStoreID = Convert.ToInt64((DateTime.Now.Ticks).ToString().
                Substring((DateTime.Now.Ticks).ToString().Length - 9)) +1000000000;
        }
    }
}
