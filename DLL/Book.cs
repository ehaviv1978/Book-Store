using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    public enum BGenre { Drama, Fantasy, Children, Horror, ScienceFiction, Thriller, Novel,SciFi };
    public class Book : Item
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public BGenre Genre { get; set; }
        public int YearPublished { get; set; }
        public int Pages { get; set; }
        public long ISBN { get; set; }
    
        public Book()
        {
            Discount = 0;
            ItemCode = Convert.ToInt64((DateTime.Now.Ticks).ToString().
                Substring((DateTime.Now.Ticks).ToString().Length - 9)) + 1000000000;
        }
    }
}
