using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    public enum JGenre { Sport, Science, LifeStile, Fusion};
    public class Journal :Item
    {
        public int Id { get; set; }
        public JGenre Genre { get; set; }
        public DateTime? PrintDate { get; set; }

        public Journal()
        {
            Discount = 0;
            ItemCode = Convert.ToInt64((DateTime.Now.Ticks).ToString().
                Substring((DateTime.Now.Ticks).ToString().Length - 9)) + 2000000000;
        }
    }
}
