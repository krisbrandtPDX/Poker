using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokerAPI.Models;

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
        public Player GetNew()
        {
            return new Player();
        }

        // GET: api/Players/5
        [HttpGet("{id}", Name = "Get")]
        public Player Get(int id)
        {
            Player player = _context.Players.Find(id);
            player.Hands = _context.Hands.Where(h => h.PlayerId == id).ToList();
            return player;
        }

        // POST: api/Players
        [HttpPost]
        public void Post([FromBody] Player player)
        {
            _context.Add(player);
            _context.SaveChanges();
        }

        // PUT: api/Players/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Player player)
        {
            if (id == player.Id)
            {
                _context.Entry(player).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Player player = _context.Players.Find(id);
            _context.Players.Remove(player);
            _context.SaveChanges();
        }
    }
}
