using Shop.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BusinnesLogic.Services.Fuctory
{
    public abstract class TransactionCreator
    {
        public virtual Transaction CreateTransaction()
        {
            return new Transaction();
        }


    }
}
