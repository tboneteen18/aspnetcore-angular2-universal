using System;

namespace AspCoreServer.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double SalePrice { get; set; }
        public double PurchaseCost { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
