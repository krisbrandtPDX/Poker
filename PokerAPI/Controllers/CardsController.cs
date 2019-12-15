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
            return  _context.Cards.Find(Id);
        }

        // POST: api/Hands
        [HttpPost]
        public void Post([FromBody] List<Card> cards)
        {
            _context.Add(cards);
            _context.SaveChanges();
        }
    }
}