using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    public class Customer : Person
    {
        public int Id { get; set; }
        public static int CodeGenerator = 20000;
        public double TotalSpent { get; set; }

        public Customer()
        {
            CodeGenerator++;
            PersonStoreID = CodeGenerator;
        }
    }

}
