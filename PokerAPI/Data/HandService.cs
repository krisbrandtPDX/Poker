using PokerAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace PokerAPI.Data
{
    public class HandService
    {
        private readonly PokerAPIContext _context;

        public HandService(PokerAPIContext context)
        {
            _context = context;
        }
        public List<Entities.Hand> GetHands()
        {
            return _context.Hands.ToList();
        }
        public Hand GetHand(int handId)
        {
            Hand hand = new Hand();
            hand.Cards = new CardService(_context).GetCards(handId);
            return hand;
        }
        public List<Hand> GetHands(int playerId)
        {
            List<Hand> hands = new List<Hand>();
            List<Entities.Hand> handEntities = _context.Hands.Where(h => h.PlayerId == playerId).ToList();
            foreach (Entities.Hand h in handEntities)
            {
                hands.Add(GetHand(h.Id));
            }
            return hands;
        }

        public void PostHands(List<Entities.Hand> hands)
        {
            foreach (Entities.Hand h in hands)
            {
                _context.Hands.Add(h);
            }
            _context.SaveChanges();
        }
    }
}
