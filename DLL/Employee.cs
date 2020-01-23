using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    public enum EPosition { Manager, Seller };
    public class Employee : Person
    {
        public int Id { get; set; }
        public static int CodeGenerator = 10000;
        public EPosition Position { get; set; }
        public string Password { get; set; }

        public Employee()
        {
            CodeGenerator++;
            PersonStoreID = CodeGenerator;
        }
    }
}
