using System;

namespace DLL
{
    public interface Item
    {
        public int ItemCode { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int? Edition { get; set; }
        public int Discount { get; set; }
        public double FinalPrice { get; set; }
    }


}
