using StellarClothing.Admin.Api.Domain;
using StellarClothing.Admin.Api.Interface;
using System.Collections.Generic;
using System.Linq;

namespace StellarClothing.Admin.Api.Infrastructure.Repository
{
    public class HeadingMenusRepository : IHeadingMenusRepository
    {
        private readonly AdminContext _context;
        public HeadingMenusRepository(AdminContext context)
        {
            _context = context;
        }

        public IEnumerable<HeadingMenu> GetToptems()
        {
            var items = _context.HeadingMenus.Where(m => m.Parent == 0);
            return items;
        }

        public IEnumerable<HeadingMenu> GetChildren(int id)
        {
            return _context.HeadingMenus.Where(m => m.Parent == id);
        }

        public byte NumberOfColumns()
        {
            return _context.HeadingMenus.Max(m => m.ItemColumn);
        }
    }
}
