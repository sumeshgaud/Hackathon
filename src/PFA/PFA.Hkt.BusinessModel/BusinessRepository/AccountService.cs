using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using DataModel;
using AutoMapper;

namespace BusinessModel
{
  public class AccountService:IAccountService
    {
        private IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public beAccount GetUserById(Guid accountId)
        {
            var account = _unitOfWork.AccountRepository.GetById(accountId);
            if (account != null)
            {
                Mapper.CreateMap<Account, beAccount>();

                var accountModel = Mapper.Map<Account, beAccount>(account);
                return accountModel;
            }
            return null;
        }

        public IEnumerable<beAccount> GetAllAccounts()
        {
            var account = _unitOfWork.AccountRepository.GetAll().ToList();
            if (account != null)
            {
                Mapper.CreateMap<Account, beAccount>();

                var userModel = Mapper.Map<List<Account>, List<beAccount>>(account);
                return userModel;
            }
            return null;
        }

        public beAccount GetAccountById(Guid accountId)
        {
            throw new NotImplementedException();
        }

        public Guid CreateAccount(beAccount accountEntity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAccount(Guid accountId, beAccount accountEntity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAccount(Guid accountId)
        {
            throw new NotImplementedException();
        }
    }
}
