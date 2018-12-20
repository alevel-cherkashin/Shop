using Shop.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repozitory
{
    public class EFTransacyionRepository: ITransactionRepository
    {
        private ShopDataModel _context;

        public EFTransacyionRepository(ShopDataModel context)
        {
            _context = context;
        }

        public int Add(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
            return transaction.Id;
        }

        public void Delete(int id)
        {
            var transaction = GetDeteils(id);
            transaction.IsDeleted = true;
        }

        public List<Transaction> Get()
        {
            return _context.Transaction.Where(x => x.IsDeleted == false).ToList();
        }

        public Transaction GetDeteils(int id)
        {
            var transaction =_context.Transaction.FirstOrDefault(x => x.Id == id);

            if (transaction.IsDeleted == false)
            {
                return transaction;
            }
            else
            {
                return null;
            }
        }

        public void Update(Transaction transaction)
        {
            Transaction temp = GetDeteils(transaction.Id);
            temp.ClientId = transaction.ClientId;
            temp.Date = transaction.Date;
            temp.Amount = transaction.Amount;
        }
    }
}
