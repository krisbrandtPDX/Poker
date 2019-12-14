using Microsoft.AspNetCore.Mvc;
using PokerAPI.Models;

namespace PokerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly PokerAPIContext _context;
        public GamesController(PokerAPIContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public Game Get()
        {
            Game game = new Game();
            game.Players = _context.Players;
            return game;
        }
    }
}
