using System.Net.Http;
using PokerConsole.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokerConsole
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            UI.Notify("Hello and welcome to the poker game");
            MainMenu(await Login());
        }

        static async Task<int> Login()
        {
            Game game = new Game();
            Player player = new Player();
            string Uri = "https://localhost:44308/api/Players/1";
            string json = await client.GetStringAsync(Uri);
            player = JsonSerializer.Deserialize<Player>(json);
            return player.Id;
        }
        //private static async Task<string> Login()
        //{
        //    Task<string> json = await client.GetStringAsync(Uri);
        //    List<Player> players = new List<Player>();
        //    if (json != "")
        //    {
        //        players = JsonSerializer.Deserialize<Player>(json); ;
        //    }
        //    string prompt = "Enter player name to login: ";
        //    string playerName = UI.Prompt(prompt);

        //    //while (playerName != "")
        //    //{
        //    //    if (players.Where(p => p.Name == playerName).Count() == 0)
        //    //    {
        //    //        if (UI.Prompt("User not found, create now? <Y>/N ", "Y") == "Y")
        //    //        {
        //    //            user = new User() { Name = userName };
        //    //            ledger.Users.Add(user);
        //    //            UI.Notify("User created successfully.");
        //    //        }
        //    //    }

        //    //    if (user != null)
        //    //    {
        //    //        user = UpdateAccounts(user);
        //    //    }
        //    //    playerName = UI.Prompt(prompt);
        //    //}
        //    return playerName;
        //}
        private static void MainMenu(int playerId)
        {
            string prompt = "Select option - <D>:Deal <S>:Save Game <Q>:Quit";
            string menuChoice = UI.Prompt(prompt, "D");

            while (menuChoice != "Q")
            {
                switch (menuChoice)
                {
                    case "D":
                        //call api to get new hand
                        //increment player score
                        break;
                    case "S":
                        //prompt for login
                        //put or post player
                        break;
                    default:
                        menuChoice = "Q";
                        break;
                }
                menuChoice = UI.Prompt(prompt, "D");
            }
        }
    }
}
