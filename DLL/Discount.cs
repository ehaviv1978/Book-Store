using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    public enum DiscountField { BGenre, JGenre, BAuthor, BYearPublished };
    public class Discount
    {
        public int Percent { get; set; }
        public DiscountField Property { get; set; }
        public string PropertyValue { get; set; }
    }
}
