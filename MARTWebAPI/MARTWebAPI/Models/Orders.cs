using System;
using System.Collections.Generic;

namespace MARTWebAPI.Models
{
    public partial class Orders
    {
        public int Id { get; set; }
        public string Emailadress { get; set; }
        public long? Mobilenumber { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? UserId { get; set; }
        public string Address { get; set; }

        public Users User { get; set; }
    }
}
