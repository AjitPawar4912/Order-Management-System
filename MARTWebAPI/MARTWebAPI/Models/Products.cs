using System;
using System.Collections.Generic;

namespace MARTWebAPI.Models
{
    public partial class Products
    {
        public Products()
        {
            Carts = new HashSet<Carts>();
        }

        public int ProductId { get; set; }
        public int? SellerId { get; set; }
        public string Name { get; set; }
        public string Brandname { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public Seller Seller { get; set; }
        public ICollection<Carts> Carts { get; set; }
    }
}
