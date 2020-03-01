using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarClothing.AdminApp.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        public string Name { get; set; }
        public short PollId { get; set; }
        public Poll Poll { get; set; }
        public IEnumerable<Vote> Votes { get; set; }
    }
}
