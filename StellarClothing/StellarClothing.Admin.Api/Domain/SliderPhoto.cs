using StellarClothing.BuildingBlocks.Domain;

namespace StellarClothing.Admin.Api.Domain
{
    public class SliderPhoto : Entity<int>
    {
        public string Source { get; set; }
        public string Alt { get; set; }
        public int SliderId { get; set; }

        public Slider Slider { get; set; }
    }
}
