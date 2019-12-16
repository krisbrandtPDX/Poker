using PokerAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace PokerAPI.Data
{
    public class CardService
    {
        private readonly PokerAPIContext _context;

        public CardService(PokerAPIContext context)
        {
            _context = context;
        }
        public List<Entities.Card> GetCards()
        {
            return _context.Cards.ToList();
        }
        public Card GetCard(int id)
        {
            return new Card(id);
        }

        public List<Card> GetCards(int handId)
        {
            List<Card> cards = new List<Card>();
            List<Entities.Card> cardEntities = _context.Cards.Where(c => c.HandId == handId).ToList();
            foreach (Entities.Card c in cardEntities)
            {
                cards.Add(new Card(c.CardId));
            }
            return cards;
        }

        public void PostCards(List<Entities.Card> cards)
        {
            foreach (Entities.Card c in cards)
            {
                _context.Cards.Add(c);
            }
            _context.SaveChanges();
        }
    }
}
