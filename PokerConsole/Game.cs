using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
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

            var player = players.Where(p => p.Name == playerName).FirstOrDefault();
            if (player == null)
            {
                if (playerName != "")
                {
                    if (UI.Prompt("Player not found, create now? <Y>/N ", "Y") == "Y")
                    {
                        await _pokerClient.PostPlayer(playerName);
                        UI.Notify("Player posted.");
                        player = await Login();
                    }
                }
            }
            return await _pokerClient.GetPlayer(player.Id);
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
                        await _pokerClient.PostHand(hand);
                        string display = "";
                        foreach (Card c in hand.Cards)
                        {
                            display += c.ShortName + " ";
                        }
                        UI.Notify(display);
                        break;
                    case "S":
                        //Statistics(player);
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
