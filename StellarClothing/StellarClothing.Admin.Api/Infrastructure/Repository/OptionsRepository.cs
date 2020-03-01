using Microsoft.EntityFrameworkCore;
using StellarClothing.Admin.Api.Domain;
using StellarClothing.Admin.Api.Interface;
using System.Linq;

namespace StellarClothing.Admin.Api.Infrastructure.Repository
{
    public class OptionsRepository : IOptionsRepository
    {
        private readonly AdminContext _context;
        public OptionsRepository(AdminContext context)
        {
            _context = context;
        }

        public IQueryable<Option> GetResults(int pollId)
        {
            return _context.Options
                .Include(o => o.Votes)
                .Where(o => o.Id == pollId);
        }
    }
}
