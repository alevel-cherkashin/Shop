using Shop.Data.DataModels;
using Shop.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BusinnesLogic.Services.Fuctory
{
    public static class ClientSimpleFuctoty
    {
        private static Dictionary<int, Client> _client = new Dictionary<int, Client>();

        static ClientSimpleFuctoty()
        {
            _client.Add(1, new OneTimeClient());
            _client.Add(2, new LongTimeClient());
        }

        public static Client CreateClient(int clientType)
        {
            var client = _client[clientType];
            return client;
        }
    }
}
