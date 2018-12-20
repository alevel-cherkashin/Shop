using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Data.DataModels;

namespace Shop.Data.Repozitory
{
    public class EFClientRepository : IClientRepository
    {
        private ShopDataModel _context;

        public EFClientRepository()
        {
        
        }
        public EFClientRepository(ShopDataModel context)
        {
            _context = context;
        }
        public int Add(Client client)
        {
            _context.Client.Add(client);
            return client.Id;
        }

        public void Delete(int id)
        {
            var client = GetDeteils(id);
            client.IsDeleted = true;
          
        }

        public virtual List<Client> Get()
        {
            return _context.Client.Where(x => x.IsDeleted == false).ToList();
        }

        public Client GetDeteils(int id)
        {
            var client =_context.Client.FirstOrDefault(x => x.Id == id);
            if (client == null)
            {
                return null;
            }
            else if (client.IsDeleted == false)
            {
                return client;
            }
            else
            {
                return null;
            }
        }

        public void Update(Client client)
        {
            var tempClient = GetDeteils(client.Id);
            tempClient.Name = client.Name;
            tempClient.CategoryId = tempClient.CategoryId;
        }
    }
}
