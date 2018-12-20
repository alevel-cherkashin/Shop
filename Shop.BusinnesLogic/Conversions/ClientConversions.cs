using Shop.BusinnesLogic.Models;
using Shop.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BusinnesLogic.Convesions
{
    public static class ClientConversions
    {
        public static ClientViewModel ToViewModel(this ClientDto clientDto)
        {
            if (clientDto == null)
            {
                return null;
            }

            return new ClientViewModel
            {
                Id = clientDto.Id,
                Name = clientDto.Name
            };
        }

        public static ClientDto ToDto(this ClientViewModel clientViewModel)
        {
            if (clientViewModel == null)
            {
                return null;
            }

            return new ClientDto
            {
                Id = clientViewModel.Id,
                Name = clientViewModel.Name
            };
        }
    }
}
