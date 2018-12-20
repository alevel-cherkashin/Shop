using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Data.DataModels;
using Shop.Data.DTOs;

namespace Shop.BusinnesLogic.Services.Fuctory
{
    public class CraditTransactionCreator : TransactionCreator
    {
        public override Transaction CreateTransaction()
        {
            var trasaction = new CraditTransaction();

            trasaction.Overdraft = GetOverdraft(1);
            trasaction.CommitmenData = GetCommitmenData();

            return trasaction;
        }

        private double GetOverdraft(int transactionId)
        {
            return 0;
        }

        private DateTime GetCommitmenData()
        {
            return DateTime.Now;
        }


    }
}
