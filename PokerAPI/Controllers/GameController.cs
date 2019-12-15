using Microsoft.AspNetCore.Mvc;
using PokerAPI.Models;
using PokerAPI.ViewModels;

namespace PokerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly PokerAPIContext _context;

        public GameController(PokerAPIContext context)
        {
            _context = context;
        }
        // GET: api/Game
        [HttpGet]
        public Game Get()
        {
            Game game = new Game();
            game.Players = _context.Players;
            return game;
        }
    }
}
