using Microsoft.EntityFrameworkCore;
using StellarClothing.Admin.Api.Domain;
using System.Linq;

namespace StellarClothing.Admin.Api.Infrastructure.Repository
{
    public class PollsRepository
    {
        private readonly AdminContext _context;
        public PollsRepository(AdminContext context)
        {
            _context = context;
        }

        public Poll GetActivePoll()
        {
            return _context.Polls
                .Include(p => p.Options)
                .SingleOrDefault(p => p.Active == true);
        }
    }
}
