using System.Collections.Generic;

namespace PokerConsole.Models
{
    class Player
    {
        public Player()
        {
            Hands = new List<Hand>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Hand> Hands { get; set; }

    }
}
