using Shop.Data.DataModels;
using Shop.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Extensions
{
    public static class ClientConversions
    {
        public static ClientDto ToDto(this Client client)
        {
            if (client == null)
            {
                return null;
            }

            return new ClientDto
            {
                Id = client.Id,
                Name = client.Name
            };
        }

        public static Client ToSqlModel(this ClientDto clientDto)
        {
            if (clientDto == null)
            {
                return null;
            }

            return new Client
            {
                Id = clientDto.Id,
                Name = clientDto.Name
            };
        }
    }
}
