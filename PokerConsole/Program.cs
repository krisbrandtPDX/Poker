using PokerConsole.Models;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokerConsole
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            UI.Notify("Hello and welcome to the poker game");
            Game game = await GetGame();
            Login(game);
        }


        private static async Task Login(Game game)
        {
            string prompt = "Enter player name to login: ";
            string playerName = UI.Prompt(prompt);

            var player = game.Players.Where(p => p.Name == playerName).FirstOrDefault();
            if (player == null)
            {
                if (UI.Prompt("Player not found, create now? <Y>/N ", "Y") == "Y")
                {
                    UI.Notify("Player posted to db.");
                    await PostPlayer(playerName);
                    game = await GetGame();
                    await Login(game);
                }
            }

            UI.Prompt(string.Format("Welcome, {0:G}", player.Name));
        }

        static async Task<Game> GetGame()
        {
            string Uri = "https://localhost:44308/api/Game";
            string json = await client.GetStringAsync(Uri);
            return JsonSerializer.Deserialize<Game>(json);
        }
        static async Task PostPlayer(string Name)
        {
            string Uri = "https://localhost:44308/api/Players";
            var content = new StringContent(Name, Encoding.UTF8, "application/json");
            await client.PostAsync(Uri, content);
        }

        //private static void PlayGame(Player player)
        //{
        //    UI.Notify("Welcome, " + player.Name + "!");
        //    string prompt = "Select option - <ENTER>:Deal <S>:Player Stats <Q>:Quit";
        //    string menuChoice = UI.Prompt(prompt, "D");

        //    while (menuChoice != "Q")
        //    {
        //        switch (menuChoice)
        //        {
        //            case "D":
        //                //var cards = await Deal();
        //                //UI.Notify(hand.Name);
        //                //increment player score
        //                break;
        //            case "S":
        //                Statistics(player);
        //                break;
        //            default:
        //                menuChoice = "Q";
        //                break;
        //        }
        //        menuChoice = UI.Prompt(prompt, "D");
        //    }
        //}
        //static async Task<Hands> GetHands(int playerId)
        //{
        //    string Uri = "https://localhost:44308/api/Hands/" + playerId;
        //    string json = await client.GetStringAsync(Uri);
        //    return JsonSerializer.Deserialize<Hands>(json);
        //}

        //private static void Statistics(Player player)
        //{
        //    var hands = GetHands(player.Id);
        //    UI.Notify("Total Hands Played:");
        //}

        //    return JsonSerializer.Deserialize<Game>(json);
        //}
        //static async Task<Cards> Deal()
        //{
        //    string Uri = "https://localhost:44308/api/Hands";
        //    string json = await client.GetStringAsync(Uri);
        //    return JsonSerializer.Deserialize<Hand>(json);
        //

    }
}

