using System;
using System.Collections.Generic;

namespace API_Ecommerce
{
    public partial class Product
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }
        public long? OrderId { get; set; }

        public virtual Order? Order { get; set; }
    }
}
