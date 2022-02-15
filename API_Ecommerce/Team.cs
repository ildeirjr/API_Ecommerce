using System;
using System.Collections.Generic;

namespace API_Ecommerce
{
    public partial class Team
    {
        public Team()
        {
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string VehicleLicensePlate { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
