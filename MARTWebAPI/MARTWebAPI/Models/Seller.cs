using System;
using System.Collections.Generic;

namespace MARTWebAPI.Models
{
    public partial class Seller
    {
        public Seller()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Sname { get; set; }
        public string Emailadress { get; set; }
        public long? Mobilenumber { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
