using PokerConsole.Models;
using System.Threading.Tasks;

namespace PokerConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            UI.Notify("Hello and welcome to the poker game");
            Game game = new Game();
                await game.Play();
        }
    }
}
