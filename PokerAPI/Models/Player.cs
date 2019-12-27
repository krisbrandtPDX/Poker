using System.Collections.Generic;


namespace PokerAPI.Models
{

    public class Player
    {
        public Player()
        {
            Hands = new List<Hand>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Hand> Hands { get; set; }

    }
}
 