using System;
using System.Collections.Generic;

namespace MARTWebAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            Carts = new HashSet<Carts>();
            Orders = new HashSet<Orders>();
        }

        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Emailadress { get; set; }
        public long? Mobilenumber { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public ICollection<Carts> Carts { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
