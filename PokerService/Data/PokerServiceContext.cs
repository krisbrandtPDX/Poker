using Microsoft.EntityFrameworkCore;

namespace PokerService.Models
{
    public class PokerServiceContext : DbContext
    {
        public PokerServiceContext(DbContextOptions<PokerServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Hand> Hands { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}