using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public interface IUnitOfWork
    {
        #region Model Methods
        GenericRepository<Account> AccountRepository { get; }
        GenericRepository<AuthInfo> AuthInfoRepository { get; }
        GenericRepository<Bank> BankRepository { get; }
        GenericRepository<Budget> BudgetRepository { get; }
        GenericRepository<BudgetDetail> BudgetDetailRepository { get; }
        GenericRepository<Category> CategoryRepository { get; }
        GenericRepository<Currency> CurrencyRepository { get; }
        GenericRepository<Goal> GoalRepository { get; }
        GenericRepository<RecurTransaction> RecurTransactionRepository { get; }
        GenericRepository<BankTransaction> TransactionRepository { get; }
        GenericRepository<User> UserRepository { get; }
        #endregion

        void Save();
    }
}
