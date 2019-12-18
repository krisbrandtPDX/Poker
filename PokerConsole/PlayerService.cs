using PokerConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokerConsole
{
    public class PlayerService
    {
        private readonly HttpClient _client;

        public PlayerService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Player> Login()
        {
            var players = await GetPlayers();          
            string prompt = "Enter player name to login: ";
            string playerName = UI.Prompt(prompt);

            var player = players.Where(p => p.Name == playerName).FirstOrDefault();
            if (player == null)
            {
                if (UI.Prompt("Player not found, create now? <Y>/N ", "Y") == "Y")
                {
                    await PostPlayer(playerName);
                    UI.Notify("Player posted.");
                    await Login();
                }
            }
            return player;
        }

        public async Task PostPlayer(string name)
        {
            var content = new StringContent(name, Encoding.UTF8, "application/json");
            await _client.PostAsync("api/Players?name=" + name, content);
        }

        public async Task<List<Player>> GetPlayers()
        {
            var serializer = new DataContractJsonSerializer(typeof(List<Player>));
            var streamTask = _client.GetStreamAsync("api/Players");
            var players = serializer.ReadObject(await streamTask) as List<Player>;
            return players;
        }

    }
}
 