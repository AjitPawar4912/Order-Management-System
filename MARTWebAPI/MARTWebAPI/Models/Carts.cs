using System;
using System.Collections.Generic;

namespace MARTWebAPI.Models
{
    public partial class Carts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brandname { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }
        public string Image { get; set; }
        public int? Quantity { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }

        public Products Product { get; set; }
        public Users User { get; set; }
    }
}
