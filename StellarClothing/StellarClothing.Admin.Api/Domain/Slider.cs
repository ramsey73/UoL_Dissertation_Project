using StellarClothing.BuildingBlocks.Domain;
using System.Collections.Generic;

namespace StellarClothing.Admin.Api.Domain
{
    public class Slider : Entity<int>
    {
        public bool Active { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public ICollection<SliderPhoto> SliderPhotos { get; set; }
    }
}
