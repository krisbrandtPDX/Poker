using Microsoft.EntityFrameworkCore;

namespace PokerAPI.Data
{
    public class PokerAPIContext : DbContext
    {
        public PokerAPIContext (DbContextOptions<PokerAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Entities.Player> Players { get; set; }

        public DbSet<Entities.Hand> Hands { get; set; }
        public DbSet<Entities.Card> Cards { get; set; }
    }
}
