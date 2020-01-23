using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    public enum JGenre { Sport, Science, LifeStile, Fusion};
    public class Journal :Item
    {
        public int Id { get; set; }
        public static int CodeGenerator = 2000000;
        public JGenre Genre { get; set; }
        public DateTime? PrintDate { get; set; }

        public Journal()
        {
            Discount = 0;
            CodeGenerator++;
            ItemCode = CodeGenerator;
        }
    }
}
