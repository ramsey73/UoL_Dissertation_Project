using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarClothing.AdminApp.Models
{
    public class Slider
    {
        public int Slider_id { get; set; }
        public bool Active { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public ICollection<SliderPhoto> SliderPhotos { get; set; }
    }
}
