using Microsoft.AspNetCore.Mvc;
using PokerAPI.Models;
using System;

namespace PokerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly PokerAPIContext _context;
        public CardsController(PokerAPIContext context)
        {
            _context = context;
        }

       // GET: api/Cards
       [HttpGet]
        public Card Get()
        {
            Random rnd = new Random();
            return new Card() { CardId = rnd.Next(0, 51) };
        }
        // GET: api/Cards/5
        [HttpGet("{Id}")]
        public Card Get(int Id)
        {
            return new Card() { CardId = Id };
        }

        // POST: api/Cards
        [HttpPost]
        public void Post(int cardId, int handId)
        {
            Card c = new Card() { CardId = cardId, HandId = handId };
            _context.Cards.Add(c);
            _context.SaveChanges();
        }
    }
}