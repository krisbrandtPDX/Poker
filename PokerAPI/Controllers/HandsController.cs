using Microsoft.AspNetCore.Mvc;
using PokerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace PokerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandsController : ControllerBase
    {
        private readonly PokerAPIContext _context;
        public HandsController(PokerAPIContext context)
        {
            _context = context;
        }

        // GET: api/Hands
        [HttpGet]
        public Hand Get()
        {
            Hand hand = new Hand();
            while (hand.Cards.Count() < 5)
            {
                Random rnd = new Random();
                Card card = new Card() { CardId = rnd.Next(0, 51) };
                if (hand.Cards.Where(c => c.CardId == card.CardId).Count() == 0)
                {
                    hand.Cards.Add(card);
                }
            }
            hand.Cards = hand.Cards.OrderBy(c => c.Rank).ThenBy(c => c.Suit).ToList();
            return hand;
        }

        // GET: api/Hands/5
        [HttpGet("{Id}")]
        public Hand Get(int Id)
        {
            Hand hand = _context.Hands.Find(Id);
            hand.Cards = _context.Cards.Where(c => c.HandId == Id).ToList();
            hand.Cards = hand.Cards.OrderBy(c => c.Rank).ThenBy(c => c.Suit).ToList();
            return hand;
        }

        // POST: api/Hands
        [HttpPost]
        public void Post([FromBody] Hand hand)
        {
            hand.Timestamp = DateTime.Now;
            _context.Hands.Add(hand);
            foreach(Card c in hand.Cards)
            {
                c.HandId = hand.Id;
                _context.Cards.Add(c);
            }
            _context.SaveChanges();
        }
    }
}
