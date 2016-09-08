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
            var transcationList = _unitOfWork.TransactionRepository.GetAll().ToList();

            try
            {
                if (transcationList != null)
                {
                    Mapper.CreateMap<BankTransaction, beTransaction>();

                    var transactionModel = Mapper.Map<List<BankTransaction>, List<beTransaction>>(transcationList);
                    return transactionModel;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<beTransaction> GetAllTransaction(Guid UserID)
        {
            var transcationList = _unitOfWork.TransactionRepository.GetAll().Where(x => x.UserId == UserID).ToList();

            try
            {
                if (transcationList != null)
                {
                    Mapper.CreateMap<BankTransaction, beTransaction>();

                    var transactionModel = Mapper.Map<List<BankTransaction>, List<beTransaction>>(transcationList);
                    return transactionModel;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Guid CreateTransaction(beTransaction transEntity)
        {
            using (var scope = new TransactionScope())
            {
                var transaction  = new BankTransaction
                {
                   Id = new Guid(),
                   AccountId = transEntity.AccountId,
                   Amount =transEntity.Amount,
                   CategoryId = transEntity.CategoryId,
                   Date = transEntity.Date,
                   Description = transEntity.Description,
                   IsSplitTransaction =transEntity.IsSplitTransaction,
                   Note = transEntity.Note,
                   ParentId = transEntity.ParentId,
                   Payee = transEntity.Payee,
                   ReferenceId = transEntity.ReferenceId,
                   TxSource = transEntity.TxSource,
                   Type = transEntity.Type,
                   UserId = transEntity.UserId
                };

                _unitOfWork.TransactionRepository.Insert(transaction);
                _unitOfWork.Save();
                scope.Complete();
                return transaction.Id;
            }
        }

        public bool UpdateTransaction(Guid transId, beTransaction transEntity)
        {
            var success = false;
            if (transEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var transaction = _unitOfWork.TransactionRepository.GetById(transEntity);
                    if (transaction != null)
                    {
                        transaction.Description = transEntity.Description;
                        transaction.CategoryId = transEntity.CategoryId;
                        _unitOfWork.TransactionRepository.Update(transaction);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteTransaction(Guid transId)
        {
            var success = false;
            if (transId != null)
            {
                using (var scope = new TransactionScope())
                {
                    var transDetail = _unitOfWork.TransactionRepository.GetById(transId);
                    {
                        _unitOfWork.TransactionRepository.Delete(transDetail);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public beTransaction GetTransactionById(Guid transId)
        {
            var transactionDetails = _unitOfWork.TransactionRepository.GetById(transId);
            if (transactionDetails != null)
            {
                Mapper.CreateMap<BankTransaction, beTransaction>();

                var transactionModel = Mapper.Map<BankTransaction, beTransaction>(transactionDetails);
                return transactionModel;
            }
            return null;
        }
    }
}
