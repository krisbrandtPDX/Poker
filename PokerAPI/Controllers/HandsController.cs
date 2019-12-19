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
        public IEnumerable<Hand> Get()
        {
            return _context.Hands;
        }
        // GET: api/Hands/5
        [HttpGet("{Id}")]
        public Hand Get(int Id)
        {
            Hand hand = _context.Hands.Find(Id);
            hand.Cards = _context.Cards.Where(c => c.HandId == Id).ToList();
            return hand;
        }

        // POST: api/Hands
        [HttpPost]
        public void Post(int playerId)
        {
            Hand hand = new Hand() { PlayerId = playerId, Timestamp = DateTime.Now };
            _context.Hands.Add(hand);
            _context.SaveChanges();
        }
    }
}
