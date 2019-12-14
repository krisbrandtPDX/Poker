namespace PokerAPI.Models
{
    public class Card
    {
        private string[] _suits = new string[4] { "Hearts", "Clubs", "Diamonds", "Spades" };
        private string[] _ranks = new string[13] { "Two", "Three", "Four", "Five","Six", "Seven", "Eight" ,"Nine", "Ten", "Jack", "Queen", "King", "Ace"};

        public int Id { get; set; }
        public int Rank => Id % 13;
        public int Suit => Id / 13;
        public string Name => _ranks[Rank] + "Of" + _suits[Suit];
    }
}
