using StellarClothing.Admin.Api.Domain;
using System.Collections.Generic;
using System.Linq;

namespace StellarClothing.Admin.Api.Infrastructure.Repository
{
    public class FooterMenusRepository
    {
        private readonly AdminContext _context;
        public FooterMenusRepository(AdminContext context)
        {
            _context = context;
        }
        public IEnumerable<FooterMenu> GetFooterMenuFirstColumn()
        {
            return _context.FooterMenus;
        }
        public IEnumerable<HeadingMenu> GetFooterMenuSecondColumn()
        {
            return _context.HeadingMenus.Where(h => h.Parent == _context.HeadingMenus.First(he => he.HasChildren == true).Id);
        }
        public IEnumerable<HeadingMenu> GetFooterMenuThirdColumn()
        {
            return _context.HeadingMenus.Where(h => h.Parent == _context.HeadingMenus.Last(he => he.HasChildren == true).Id);
        }
    }
}
