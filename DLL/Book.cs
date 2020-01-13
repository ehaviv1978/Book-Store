using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreC
{
    public enum BGenre { Drama, Fantasy, Children, Horror, ScienceFiction, Thriller, Novel };
    public class Book : Item
    {
        public string Author;
        public BGenre Genre;
        public int YearPublished;
        public int Pages;
        public int ISBN;
        public int Edition;
    }
}
