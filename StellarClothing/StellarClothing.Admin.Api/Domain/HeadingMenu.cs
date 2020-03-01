using StellarClothing.BuildingBlocks.Domain;

namespace StellarClothing.Admin.Api.Domain
{
    public class HeadingMenu : Entity<int>
    {
        public HeadingMenu()
        {
        }

        public string Link { get; set; }
        public string Name { get; set; }
        public bool HasChildren { get; set; }
        public byte Parent { get; set; }
        public byte ItemColumn { get; set; }
    }
}
