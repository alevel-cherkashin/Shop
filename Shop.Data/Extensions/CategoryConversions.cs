using Shop.Data.DataModels;
using Shop.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Extensions
{
    public static class CategoryConversions
    {
        public static CategoryClient ToSqlModel(this CategoryClientDto categoryClientDto)
        {
            return new CategoryClient
            {
                Id = categoryClientDto.Id,
                CategoryName = categoryClientDto.CategoryName,
                IsDeleted = categoryClientDto.IsDeleted
            };
        }

        public static CategoryClientDto ToDto(this CategoryClient categoryClient)
        {
            return new CategoryClientDto
            {
                Id = categoryClient.Id,
                CategoryName = categoryClient.CategoryName,
                IsDeleted = categoryClient.IsDeleted
            };
        }


    }
}
