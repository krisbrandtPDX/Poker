using Microsoft.AspNetCore.Mvc;
using PokerAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace PokerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly PokerAPIContext _context;
        public PlayersController(PokerAPIContext context)
        {
            _context = context;
        }
        // GET: api/Players
        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return _context.Players;
        }

        // GET: api/Players/5
        [HttpGet("{Id}")]
        public Player Get(int Id)
        {
            Player player = _context.Players.Find(Id);
            player.Hands = _context.Hands.Where(h => h.PlayerId == Id).ToList();
            foreach(Hand h in player.Hands)
            {
                h.Cards = _context.Cards.Where(c => c.HandId == h.Id).ToList();
            }
            return player;
        }

        // POST: api/Players
        [HttpPost]
        public void Post([FromBody] string playerName)
        {
            _context.Players.Add(new Player() { Name = playerName });
            _context.SaveChanges();
        }
    }
}
