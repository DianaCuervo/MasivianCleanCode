using Microsoft.EntityFrameworkCore;
using RouletteApi.Models;

namespace RouletteApi.Data
{
    public class RouletteContext : DbContext
    {
        public RouletteContext(DbContextOptions<RouletteContext> opt) : base(opt)
        {
            
        }
        public DbSet<Roulette> Roulettes { get; set; }        
    }
}