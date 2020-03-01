using StellarClothing.BuildingBlocks.Domain;
using System;

namespace StellarClothing.Admin.Api.Domain
{
    public class Vote : Entity<int>
    {
        public string UserId { get; set; }
        public DateTime Time { get; set; }
        public int OptionId { get; set; }
        public Option Option { get; set; }
    }
}
