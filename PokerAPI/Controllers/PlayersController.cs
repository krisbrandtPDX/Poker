using Microsoft.AspNetCore.Mvc;
using PokerAPI.Data;
using PokerAPI.Models;
using System.Collections.Generic;

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
        public IEnumerable<Entities.Player> Get()
        {
            return new PlayerService(_context).GetPlayers();
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public Player Get(int id)
        {
            return new PlayerService(_context).GetPlayer(id);
        }

        // POST: api/Players
        [HttpPost]
        public void Post([FromBody] List<Entities.Player> players)
        {
            new PlayerService(_context).PostPlayers(players);
        }
    }
}
