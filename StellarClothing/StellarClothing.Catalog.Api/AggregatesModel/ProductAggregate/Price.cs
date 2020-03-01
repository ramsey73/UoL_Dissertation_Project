using StellarClothing.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarClothing.Catalog.Domain
{
    public class Price : Entity<long>
    {
        public double NetPrice { get; set; }
        public double Discount { get; set; }
        public bool Active { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
