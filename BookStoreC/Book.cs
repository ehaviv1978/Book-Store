using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreC
{
    public class Book : Item
    {
        public enum Genre { Drama, Fantasy, Children, Horror, ScienceFiction, Thriller, Novel };
        public int Pages;
        public int ISBN;
        public int Edition;
    }
}
