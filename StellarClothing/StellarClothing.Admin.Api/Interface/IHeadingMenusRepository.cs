using StellarClothing.Admin.Api.Domain;
using System.Collections.Generic;

namespace StellarClothing.Admin.Api.Interface
{
    public interface IHeadingMenusRepository
    {
        IEnumerable<HeadingMenu> GetToptems();
        IEnumerable<HeadingMenu> GetChildren(int id);
        byte NumberOfColumns();
    }
}
