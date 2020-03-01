using System.Collections.Generic;

namespace StellarClothing.AdminApp.Models
{
    public class Poll
    {
        public short PollId { get; set; }
        public string Question { get; set; }
        public bool Active { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
