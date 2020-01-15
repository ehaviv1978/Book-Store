using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    public enum EPosition { Manager, Seller };
    public class Employee : Person
    {
        public EPosition Position { get; set; }
        public string Password { get; set; }
    }
}
