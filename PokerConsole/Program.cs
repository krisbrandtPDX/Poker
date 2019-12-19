using PokerConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
