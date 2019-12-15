using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<Player> Get()
        {
            return _context.Players;
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public Player Get(int id)
        {
            return _context.Players.Find(id);
        }

        // POST: api/Players
        [HttpPost]
        public void Post([FromBody] Player player)
        {
            _context.Add(player);
            _context.SaveChanges();
        }

       
    }
}
