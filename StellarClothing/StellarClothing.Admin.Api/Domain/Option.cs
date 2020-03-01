using StellarClothing.BuildingBlocks.Domain;
using System.Collections.Generic;

namespace StellarClothing.Admin.Api.Domain
{
    public class Option : Entity<int>
    {
        public string Name { get; set; }
        public short PollId { get; set; }

        public Poll Poll { get; set; }
        public ICollection<Vote> Votes { get; set; }
    }
}
