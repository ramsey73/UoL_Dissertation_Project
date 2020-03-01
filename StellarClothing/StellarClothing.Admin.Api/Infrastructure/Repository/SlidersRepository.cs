using Microsoft.EntityFrameworkCore;
using StellarClothing.Admin.Api.Domain;
using StellarClothing.Admin.Api.Interface;
using System.Linq;

namespace StellarClothing.Admin.Api.Infrastructure.Repository
{
    public class SlidersRepository : ISlidersRepository
    {
        private readonly AdminContext _context;
        public SlidersRepository(AdminContext context)
        {
            _context = context;
        }

        public Slider GetActiveSlider()
        {
            return _context.Sliders
                .Include(s => s.SliderPhotos)
                .SingleOrDefault(s => s.Active == true);
        }
    }
}
