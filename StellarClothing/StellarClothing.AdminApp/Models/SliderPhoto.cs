using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarClothing.AdminApp.Models
{
    public class SliderPhoto
    {
        public int PhotoId { get; set; }
        public string Source { get; set; }
        public string Alt { get; set; }
        public int SliderId { get; set; }
        public Slider Slider { get; set; }
    }
}
