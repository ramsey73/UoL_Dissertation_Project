using Microsoft.EntityFrameworkCore;
using StellarClothing.Admin.Api.Domain;

namespace StellarClothing.Admin.Api.Infrastructure
{
    public class AdminContext : DbContext
    {
        public AdminContext()
        {
        }
        public AdminContext(DbContextOptions<AdminContext> options) : base(options)
        {
        }

        public DbSet<FooterMenu> FooterMenus { get; set; }
        public DbSet<HeadingMenu> HeadingMenus { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderPhoto> SliderPhotos { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
