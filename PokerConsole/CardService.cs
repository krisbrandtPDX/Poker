using System.Net.Http;

namespace PokerConsole
{
    class CardService
    {
        private readonly HttpClient _client;

        public CardService(HttpClient client)
        {
            _client = client;
        }
    }
}
