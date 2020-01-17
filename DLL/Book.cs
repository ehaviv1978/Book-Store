using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    public enum BGenre { Drama, Fantasy, Children, Horror, ScienceFiction, Thriller, Novel,SciFi };
    public class Book : Item
    {
        public static int CodeGenerator = 10000;

        public string Author { get; set; }
        //public enum Genre { Drama, Fantasy, Children, Horror, ScienceFiction, Thriller, Novel, SciFi };
        public BGenre Genre { get; set; }
        public int YearPublished { get; set; }
        public int Pages { get; set; }
        public long ISBN { get; set; }
        public int ItemCode { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int? Edition { get; set; }

        public Book()
        {
            CodeGenerator++;
            ItemCode = CodeGenerator;
        }
    }
}
