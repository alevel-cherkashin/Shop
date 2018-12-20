using Shop.BusinnesLogic.Models;
using Shop.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BusinnesLogic.Convesions
{
    public static class CategoryClientConversion
    {
        public static CategoryClientViewModel ToViewModel(this CategoryClientDto categoryClientDto)
        {
            return new CategoryClientViewModel
            {
                Id = categoryClientDto.Id,
                CategoryName = categoryClientDto.CategoryName,
                IsDeleted = categoryClientDto.IsDeleted
            };
        }

        public static CategoryClientDto ToDto(this CategoryClientViewModel categoryClientViewModel)
        {
            return new CategoryClientDto
            {
                Id = categoryClientViewModel.Id,
                CategoryName = categoryClientViewModel.CategoryName,
                IsDeleted = categoryClientViewModel.IsDeleted
            };
        }
    }
}
