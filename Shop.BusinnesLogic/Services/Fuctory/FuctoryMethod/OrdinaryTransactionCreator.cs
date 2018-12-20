using Shop.Data.DataModels;
using Shop.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BusinnesLogic.Services.Fuctory
{
    class OrdinaryTransactionCreator: TransactionCreator
    {
        public override Transaction CreateTransaction()
        {
            var transaction = new OrdinaryTransaction();

            return transaction;

        }
    }
}
