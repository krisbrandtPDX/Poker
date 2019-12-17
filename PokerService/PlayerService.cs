using PokerService.Models;
using System.Collections.Generic;
using System.Linq;

namespace PokerService
{
    public class PlayerService
    {
        private readonly PokerServiceContext _context;
        public PlayerService(PokerServiceContext context)
        {
            _context = context;
        }

        public List<string> GetPlayers()
        {
            return _context.Players.Select(p => p.Name).ToList() ;
        }

        public void PostPlayer(string name)
        {
            Player p = new Player() { Name = name };
            _context.Add(p);
            _context.SaveChanges();
        }
    }
}
