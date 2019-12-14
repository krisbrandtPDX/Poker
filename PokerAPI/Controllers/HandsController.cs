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
    public class HandsController : ControllerBase
    {
        private readonly PokerAPIContext _context;
        public HandsController(PokerAPIContext context)
        {
            _context = context;
        }

        // GET: api/Hands
        [HttpGet]
        public Hand GetRandom()
        {
            return new Hand();
        }

        // GET: api/Hands/5
        [HttpGet("{PlayerId}")]
        public IEnumerable<Hand> Get(int playerId)
        {
            return _context.Hands.Where(h => h.PlayerId == playerId).ToArray();
        }

        // POST: api/Hands
        [HttpPost]
        public void Post([FromBody] List<Hand> hands)
        {
            _context.Add(hands);
            _context.SaveChanges();
        }
    }
}
