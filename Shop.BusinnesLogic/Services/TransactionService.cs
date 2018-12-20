using Shop.BusinnesLogic.Services.Fuctory;
using Shop.Data;
using Shop.Data.DataModels;
using Shop.Data.DTOs;
using Shop.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BusinnesLogic.Services
{
    public interface ITransactionService
    {
        int Add(TransactionDto transactionDto);

        void Update(TransactionDto transactionDto);

        void Delete(int id);

        TransactionDto  GetDetails(int id);

        List<TransactionDto> Get();
    }


    public class TransactionService : ITransactionService
    {
        private IUnitOfWork _unitOfWork;

        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Add(TransactionDto transactionDto)
        {
            var transaction = transactionDto.ToSqlModel();
            _unitOfWork.EFTransacyionRepository.Add(transaction);

            _unitOfWork.Save();

            return 0;
        }

        public void Delete(int id)
        {
            _unitOfWork.EFTransacyionRepository.Delete(id);

            _unitOfWork.Save();
        }

        public List<TransactionDto> Get()
        {
            return _unitOfWork.EFTransacyionRepository.Get().Select(x=>x.ToDto()).ToList();
        }

        public TransactionDto GetDetails(int id)
        {
            return _unitOfWork.EFTransacyionRepository.GetDeteils(id).ToDto();
        }

        public void Update(TransactionDto transactionDto)
        {
            var transaction = transactionDto.ToSqlModel();
            _unitOfWork.EFTransacyionRepository.Update(transaction);

            _unitOfWork.Save();
        }

        public Transaction AddTransaction(int transactionType)
        {
            Dictionary<int, TransactionCreator> transactioTypes = new Dictionary<int, TransactionCreator>();
            transactioTypes.Add(1, new OrdinaryTransactionCreator());
            transactioTypes.Add(2, new CraditTransactionCreator());

            var creator = transactioTypes[transactionType];

            return creator.CreateTransaction();

        }
    }
}
