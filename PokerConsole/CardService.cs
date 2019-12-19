using PokerConsole.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace PokerConsole
{
    class CardService
    {
        private readonly HttpClient _client;

        public CardService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Card> GetCard(int id)
        {
            var serializer = new DataContractJsonSerializer(typeof(Card));
            var streamTask = _client.GetStreamAsync("api/Cards/" + id);
            var card = serializer.ReadObject(await streamTask) as Card;
            return card;
        }
        //public async Task PostCard(int cardId, int handId)
        //{
        //    var content = new StringContent("");
        //    await _client.PostAsync("api/Players?name=" + name, content);
        //}
    }
}
 