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
    public class PokerClient
    {
        private readonly HttpClient _client;

        public PokerClient(HttpClient client)
        {
            _client = client;
        }

        public async Task PostPlayer(string name)
        {
            var content = new StringContent("");
            await _client.PostAsync("api/Players?name=" + name, content);
        }

        public async Task<List<Player>> GetPlayers()
        {
            var serializer = new DataContractJsonSerializer(typeof(List<Player>));
            var streamTask = _client.GetStreamAsync("api/Players");
            var players = serializer.ReadObject(await streamTask) as List<Player>;
            return players;
        }

        public async Task<Player> GetPlayer(int playerId)
        {
            var serializer = new DataContractJsonSerializer(typeof(Player));
            var streamTask = _client.GetStreamAsync("api/Players/" + playerId);
            var player = serializer.ReadObject(await streamTask) as Player;
            return player;
        }

        public async Task<Hand> Deal()
        {
            var serializer = new DataContractJsonSerializer(typeof(Hand));
            var streamTask = _client.GetStreamAsync("api/Hands");
            var hand = serializer.ReadObject(await streamTask) as Hand;
            return hand;
        }

        public async Task PostHand(int playerId, Hand hand)
        {
            var json = JsonSerializer.Serialize(hand);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync("api/Hands/" + playerId, content);
        }

    }
}
 