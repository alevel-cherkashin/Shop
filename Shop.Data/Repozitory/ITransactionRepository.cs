using Shop.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repozitory
{
    interface ITransactionRepository
    {
        int Add(Transaction transaction);

        void Update(Transaction transaction);

        void Delete(int id);

        Transaction GetDeteils(int id);

        List<Transaction> Get();
    }
}
