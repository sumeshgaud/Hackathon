using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using DataModel;
using AutoMapper;
using BusinessModel;

namespace BusinessModel
{
    public class TransactionService : ITransactionService
    {
        private IUnitOfWork _unitOfWork;

        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<beAccount> GetAccountsByUserId(Guid userId)
        {
            Func<Account, bool> predicate = (p => p.UserId == userId);
            var accountModel = _unitOfWork.AccountRepository.GetMany(predicate).ToList();
            if (accountModel != null)
            {
                Mapper.CreateMap<Account, beAccount>();

                var userAccount = Mapper.Map<List<Account>, List<beAccount>>(accountModel);
                return userAccount;
            }
            return null;
        }

        public IEnumerable<beTransaction> GetAllTransaction()
        {
            throw new NotImplementedException();
        }

        public Guid CreateTransaction(beTransaction transEntity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTransaction(Guid transId, beTransaction transEntity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTransaction(Guid transId)
        {
            throw new NotImplementedException();
        }

        public beTransaction GetTransactionById(Guid transId)
        {
            throw new NotImplementedException();
        }
    }
}
