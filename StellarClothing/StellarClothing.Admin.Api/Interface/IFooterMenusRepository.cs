using StellarClothing.Admin.Api.Domain;
using StellarClothing.BuildingBlocks.Domain;
using System.Collections.Generic;

namespace StellarClothing.Admin.Api.Interface
{
    public interface IFooterMenusRepository : IRepository<FooterMenu>
    {
        IEnumerable<FooterMenu> GetFooterMenuFirstColumn();
        IEnumerable<HeadingMenu> GetFooterMenuSecondColumn();
        IEnumerable<HeadingMenu> GetFooterMenuThirdColumn();
    }
}
