

namespace Vendor.Models
{
    using System.Collections.Generic;
    using System.Dynamic;

    public class VendingOptions
    {
        public List<Product> Products { get; set; }

        public List<double> AvailableChange { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }

        public double Price { get; set; }
    }
}