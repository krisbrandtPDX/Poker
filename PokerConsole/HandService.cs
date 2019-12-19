using PokerConsole.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace PokerConsole
{
    class HandService
    {
        private readonly HttpClient _client;

        public HandService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Hand> Deal()
        {
            var serializer = new DataContractJsonSerializer(typeof(Hand));
            var streamTask = _client.GetStreamAsync("api/Hands");
            var hand = serializer.ReadObject(await streamTask) as Hand;
            return hand;
        }

        public async Task PostHand(Hand hand)
        {
            var json = JsonSerializer.Serialize(hand);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync("api/Hands", content);
        }
    }
}
