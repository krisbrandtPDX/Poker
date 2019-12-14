using System.Collections.Generic;

namespace PokerAPI.Models
{
    public class Game
    {
        public Game()
        {
            Players = new List<Player>();
        }
        public IEnumerable<Player> Players { get; set; }
    }
}
