using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    public enum JGenre { Sport, Science, LifeStile, Fusion};
    public class Journal :Item
    {
        public JGenre Genre { get; set; }
        public DateTime? PrintDate { get; set; }

        public Journal()
        {
            CodeGenerator++;
            ItemCode = CodeGenerator;
        }
    }
}
