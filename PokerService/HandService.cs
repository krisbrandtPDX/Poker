using PokerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerService
{
    public class HandService
    {
        private readonly PokerServiceContext _context;

        public HandService(PokerServiceContext context)
        {
            _context = context;
        }
        public List<int> GetHands()
        {
            return _context.Hands.Select(h => h.Id).ToList();
        }
        public List<int> GetHands(int playerId)
        {
            return _context.Hands.Where(h => h.PlayerId == playerId).Select(h => h.Id).ToList();
        }

        public void PostHand(int playerId)
        {
            Hand h = new Hand() { PlayerId = playerId, Timestamp = DateTime.Now };
            _context.Hands.Add(h);
            _context.SaveChanges();
        }
    }
}
