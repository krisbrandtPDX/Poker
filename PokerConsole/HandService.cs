using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PokerConsole
{
    class HandService
    {
        private readonly HttpClient _client;

        public HandService(HttpClient client)
        {
            _client = client;
        }
    }
}
