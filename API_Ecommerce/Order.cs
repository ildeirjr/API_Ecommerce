using System;
using System.Collections.Generic;

namespace API_Ecommerce
{
    public partial class Order
    {
        public Order()
        {
            Products = new HashSet<Product>();
        }

        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Address { get; set; } = null!;
        public long? TeamId { get; set; }

        public virtual Team? Team { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
