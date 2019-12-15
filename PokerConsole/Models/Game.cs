using System.Collections.Generic;

namespace PokerConsole.Models
{

    public class Game
    {
        public List<Player> Players { get; set; }
    }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //class Hand
    //{
    //    public int Id { get; set; }
    //    public int PlayerId { get; set; }
    //    public string Name { get; set; }
    //}

    //class Card
    //{
    //    public int Id { get; set; }
    //    public int HandId { get; set; }
    //}

}
