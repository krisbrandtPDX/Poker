using PokerService.Models;
using System.Collections.Generic;
using System.Linq;

namespace PokerService
{
    public class CardService
    {
        private readonly PokerServiceContext _context;

        public CardService(PokerServiceContext context)
        {
            _context = context;
        }
        public List<int> GetCards()
        {
            return _context.Cards.Select(c => c.CardId).ToList();
        }

        public List<int> GetCards(int handId)
        {
            return _context.Cards.Where(c => c.HandId == handId).Select(c => c.CardId).ToList();
        }

        public void PostCard(int cardId, int handId)
        {
            Card c = new Card() { CardId = cardId, HandId = handId };
            _context.Cards.Add(c);
            _context.SaveChanges();
        }

    }
}
