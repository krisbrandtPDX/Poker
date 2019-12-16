using System.Collections.Generic;

namespace PokerAPI.Models
{
    public class Player
    {
        public Player()
        {
            Hands = new List<Hand>();
        }

        public List<Hand> Hands { get; set; }
    }
}
