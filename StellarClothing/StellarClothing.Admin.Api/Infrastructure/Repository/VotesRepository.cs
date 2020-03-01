using Microsoft.EntityFrameworkCore;
using StellarClothing.Admin.Api.Domain;
using System;
using System.Linq;

namespace StellarClothing.Admin.Api.Infrastructure.Repository
{
    public class VotesRepository
    {
        private readonly AdminContext _context;
        public VotesRepository(AdminContext context)
        {
            _context = context;
        }

        public bool HasAlreadyVoted(string userId, int pollId)
        {
            return _context.Votes
                .Include(v => v.Option)
                .Any(v => v.Option.PollId == pollId && v.UserId == userId);
        }

        public void Vote(int optionId, int pollId, string userId)
        {
            Vote newVote = new Vote
            {
                OptionId = optionId,
                Time = DateTime.UtcNow,
                UserId = userId
            };
            _context.Add(newVote);
        }
    }
}
