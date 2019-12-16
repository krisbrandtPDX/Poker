using Microsoft.AspNetCore.Mvc;
using PokerAPI.Data;
using PokerAPI.Models;
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
        public IEnumerable<Entities.Hand> Get()
        {
            return new HandService(_context).GetHands();
        }
        // GET: api/Hands/5
        [HttpGet("{Id}")]
        public Hand Get(int Id)
        {
            return new HandService(_context).GetHand(Id);
        }

        // POST: api/Hands
        [HttpPost]
        public void Post([FromBody] List<Entities.Hand> hands)
        {
            new HandService(_context).PostHands(hands);
        }
    }
}
