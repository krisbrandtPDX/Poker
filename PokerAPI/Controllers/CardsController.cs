using Microsoft.AspNetCore.Mvc;
using PokerAPI.Data;
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
        public IEnumerable<Entities.Card> Get()
        {
            return new CardService(_context).GetCards();
        }
        // GET: api/Cards/5
        [HttpGet("{Id}")]
        public Card Get(int Id)
        {
            return new CardService(_context).GetCard(Id);
        }

        // POST: api/Cards
        [HttpPost]
        public void Post([FromBody] List<Entities.Card> cards)
        {
            new CardService(_context).PostCards(cards);
        }
    }
}