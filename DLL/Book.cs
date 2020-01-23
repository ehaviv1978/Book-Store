using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    public enum BGenre { Drama, Fantasy, Children, Horror, ScienceFiction, Thriller, Novel,SciFi };
    public class Book : Item
    {
        public int Id { get; set; }
        public static int CodeGenerator = 1000000;
        public string Author { get; set; }
        public BGenre Genre { get; set; }
        public int YearPublished { get; set; }
        public int Pages { get; set; }
        public long ISBN { get; set; }
    
        public Book()
        {
            Discount = 0;
            CodeGenerator++;
            ItemCode = CodeGenerator;
        }
    }
}
