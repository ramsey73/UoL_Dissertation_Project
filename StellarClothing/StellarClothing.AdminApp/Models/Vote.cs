using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarClothing.AdminApp.Models
{
    public class Vote
    {
        public long VoteId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public DateTime Time { get; set; }

        public int OptionId { get; set; }
        public Option Option { get; set; }
    }
}
