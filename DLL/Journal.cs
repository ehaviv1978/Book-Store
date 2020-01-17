using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    public enum JGenre { Sport, Science, LifeStile, Fusion};
    public class Journal :Item
    {
        public static int CodeGenerator = 20000;
        public JGenre Genre { get; set; }
        public DateTime? PrintDate { get; set; }
        public int ItemCode { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int? Edition { get; set; }

        public Journal()
        {
            CodeGenerator++;
            ItemCode = CodeGenerator;
        }
    }
}
