using Shop.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repozitory
{
    interface IClientRepository
    {
        int Add(Client client);

        void Update(Client client);

        void Delete(int id);

        Client GetDeteils(int id);

        List<Client> Get();
    }
}
