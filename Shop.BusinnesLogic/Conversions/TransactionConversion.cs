using Shop.BusinnesLogic.Models;
using Shop.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BusinnesLogic.Convesions
{
    public static class TransactionConversion
    {
        public static TransactionViewModel ToViewModel(this TransactionDto transactionDto)
        {
            if (transactionDto == null)
            {
                return null;
            }

            return new TransactionViewModel
            {
                Amount = transactionDto.Amount,
                Date = transactionDto.Date,
                ClientId = transactionDto.ClientId,
                Id = transactionDto.Id,
            };
        }

        public static TransactionDto ToDto(this TransactionViewModel transactionViewModel)
        {
            if (transactionViewModel == null)
            {
                return null;
            }

            return new TransactionDto
            {
                Amount = transactionViewModel.Amount,
                Date = transactionViewModel.Date,
                ClientId = transactionViewModel.ClientId,
                Id = transactionViewModel.Id,
            };
        }
    }
}
