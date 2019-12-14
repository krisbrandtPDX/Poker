using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokerAPI.Models;

namespace PokerAPI.Models
{
    public class PokerAPIContext : DbContext
    {
        public PokerAPIContext (DbContextOptions<PokerAPIContext> options)
            : base(options)
        {
        }

        public DbSet<PokerAPI.Models.Player> Players { get; set; }

        public DbSet<PokerAPI.Models.Hand> Hands { get; set; }
    }
}
