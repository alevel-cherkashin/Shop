using Shop.Data.DataModels;
using Shop.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Extensions
{
    public static class TransactionConversions
    {

        public static TransactionDto ToDto(this Transaction transaction)
        {
            if (transaction == null)
            {
                return null;
            }

            return new TransactionDto
            {
                Amount = transaction.Amount.Value,
                Date = transaction.Date.Value,
                ClientId = transaction.ClientId.Value,
                Id = transaction.Id,
                Client = transaction.Client.ToDto()
            };
        }

        public static Transaction ToSqlModel(this TransactionDto transactionDto)
        {
            if (transactionDto == null)
            {
                return null;
            }

            return new Transaction
            {
                Amount = transactionDto.Amount,
                Date = transactionDto.Date,
                ClientId = transactionDto.ClientId,
                Id = transactionDto.Id,
            };

        }
    }
}
