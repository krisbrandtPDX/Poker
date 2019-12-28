using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokerConsole.Models
{
    public class Game
    {
        private readonly HttpClient _client;
        private readonly PokerClient _pokerClient;

        public Game()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44308/");
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _pokerClient = new PokerClient(_client);
        }
        public async Task Play()
        {
            Player player = await Login();
            while (player != null)
            {
                UI.Notify(string.Format("Welcome, {0:G}", player.Name));
                await MainMenu(player);
                player = await Login();
            }
            UI.Notify(string.Format("Goodbye"));
        }

        public async Task<Player> Login()
        {
            var players = await _pokerClient.GetPlayers();
            string playerName = UI.Prompt("Enter player name to login: ");

            if (playerName != "")
            {
                var player = players.Where(p => p.Name == playerName).FirstOrDefault();
                if (player == null)
                {
                    return await CreateNewPlayer(playerName);
                }
                return await _pokerClient.GetPlayer(player.Id);
            }
            return null;
        }

        public async Task<Player> CreateNewPlayer(string playerName)
        {
            if (UI.Prompt("Player not found, create now? <Y>/N ", "Y") == "Y")
            {
                await _pokerClient.PostPlayer(playerName);
                UI.Notify("Player posted.");
                return new Player() { Name = playerName };
            }
            return null;
        }

        public async Task MainMenu(Player player)
        {
            string prompt = "Select option - <ENTER>:Deal <H>:Hand History <Q>:Quit";
            string menuChoice = UI.Prompt(prompt, "D");

            while (menuChoice != "Q")
            {
                switch (menuChoice)
                {
                    case "D":
                        Hand hand = await _pokerClient.Deal();
                        await _pokerClient.PostHand(player.Id, hand);
                        player.Hands.Add(hand);
                        UI.DisplayHand(hand);
                        break;
                    case "H":
                        foreach (Hand h in player.Hands.OrderByDescending(h => h.Timestamp))
                        {
                            UI.DisplayHand(h);
                        }
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
