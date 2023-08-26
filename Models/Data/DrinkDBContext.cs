using Microsoft.EntityFrameworkCore;

namespace DrinksMachine.Models.Data
{
    public class DrinkDBContext : DbContext
    {
        public DrinkDBContext(DbContextOptions<DrinkDBContext> options)
        : base(options)
        {
        }

        public DbSet<Drink> Drinks { get; set; }
    }
}