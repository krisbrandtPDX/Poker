using Microsoft.AspNetCore.Mvc;
using PokerAPI.Models;
using System.Collections.Generic;

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
        public IEnumerable<Card> Get()
        {
            return _context.Cards;
        }
        // GET: api/Cards/5
        [HttpGet("{Id}")]
        public Card Get(int Id)
        {
            return new Card() { CardId = Id };
        }

        // POST: api/Cards
        [HttpPost]
        public void Post([FromBody] int cardId, int handId)
        {
            Card c = new Card() { CardId = cardId, HandId = handId };
            _context.Cards.Add(c);
            _context.SaveChanges();
        }
    }
}