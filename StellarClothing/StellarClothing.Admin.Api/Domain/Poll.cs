using StellarClothing.BuildingBlocks.Domain;
using System.Collections.Generic;

namespace StellarClothing.Admin.Api.Domain
{
    public class Poll : Entity<int>
    {
        public string Question { get; set; }
        public bool Active { get; set; }

        public ICollection<Option> Options { get; set; }
    }
}
