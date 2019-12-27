namespace PokerAPI.Models
{
    public class Card
    {
        public Card()
        {
        }
        private string[] _suits = new string[4] { "Hearts", "Clubs", "Diamonds", "Spades" };
        private string[] _ranks = new string[13] { "Two", "Three", "Four", "Five","Six", "Seven", "Eight" ,"Nine", "Ten", "Jack", "Queen", "King", "Ace"};

        public int CardId { get; set; }

        public int HandId { get; set; }
        public int Rank => CardId % 13;
        public int Suit => CardId / 13;
        public string ShortName => ( Rank < 8 ? (Rank + 2).ToString() : _ranks[Rank].Substring(0, 1) ) + _suits[Suit].Substring(0, 1);
        public string Name => _ranks[Rank] + "Of" + _suits[Suit];
    }
}
