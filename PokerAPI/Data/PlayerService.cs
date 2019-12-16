using PokerAPI.Models;
using System.Collections.Generic;
using System.Linq;


namespace PokerAPI.Data
{
    public class PlayerService
    {
        private readonly PokerAPIContext _context;
        public PlayerService(PokerAPIContext context)
        {
            _context = context;
        }
       
        public List<Entities.Player> GetPlayers()
        {
            return _context.Players.ToList();
        }
        public Player GetPlayer(int playerId)
        {
            Player player = new Player();
            player.Hands = new HandService(_context).GetHands(playerId);
            return player;
        }

        public void PostPlayers(List<Entities.Player> players)
        {
            foreach (Entities.Player p in players)
            {
                _context.Players.Add(p);
            }
            _context.SaveChanges();
        }
    }
}
