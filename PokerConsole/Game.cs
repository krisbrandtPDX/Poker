using System;
using System.Collections.Generic;
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
            Task<Player> loginTask = Login();
            Player player = await loginTask;
            while (player != null)
            {
                UI.Notify(string.Format("Welcome, {0:G}", player.Name));
                await MainMenu(player);
                player = await loginTask;
            }
            UI.Notify(string.Format("Goodbye"));
        }

        public async Task<Player> Login()
        {
            Task<List<Player>> getPlayersTask = _pokerClient.GetPlayers();
            List<Player> players = await getPlayersTask;
            
            string playerName = UI.Prompt("Enter player name to login: ");

            if (playerName != "")
            {
                var player = players.Where(p => p.Name == playerName).FirstOrDefault();
                if (player == null)
                {
                    if (UI.Prompt("Player not found, create now? <Y>/N ", "Y") == "Y")
                    {
                        Task postPlayerTask = _pokerClient.PostPlayer(playerName);
                        UI.Notify("Player posted.");
                        await postPlayerTask;
                        return await Login();
                    }
                }
                return await _pokerClient.GetPlayer(player.Id);
            }
            return null;
        }

        public async Task MainMenu(Player player)
        {
            Task<Hand> dealTask = _pokerClient.Deal();
            Task postHandTask = null;

            string prompt = "Select option - <ENTER>:Deal <H>:Hand History <Q>:Quit";
            string menuChoice = UI.Prompt(prompt, "D");
            
            while (menuChoice != "Q")
            {
                switch (menuChoice)
                {
                    case "D":
                        Hand hand = await dealTask;
                        UI.DisplayHand(hand);
                        player.Hands.Add(hand);
                        postHandTask = _pokerClient.PostHand(player.Id, hand);
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
                dealTask = _pokerClient.Deal();         //get a new hand
                menuChoice = UI.Prompt(prompt, "D");    //prompt user
                if (postHandTask != null)               //post last hand
                {
                    await postHandTask;
                    postHandTask = null;
                }
            }

        }
    }
}
