using StellarClothing.BuildingBlocks.Domain;

namespace StellarClothing.Admin.Api.Domain
{
    public class FooterMenu : Entity<int>
    {
        public FooterMenu()
        {
        }
        public string Link { get; set; }
        public string Name { get; set; }
    }
}
