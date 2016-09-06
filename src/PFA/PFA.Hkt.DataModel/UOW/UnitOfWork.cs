#region Using Namespaces...
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.Entity.Validation;
using DataModel;
#endregion

namespace DataModel
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Private member variables...
        private EntityDataContext _context = null;
        GenericRepository<Account> _accountRepository;
        GenericRepository<AuthInfo> _authInfoRepository;
        GenericRepository<Bank> _bankRepository;
        GenericRepository<Budget> _budgetRepository;
        GenericRepository<BudgetDetail> _budgetDetailRepository;
        GenericRepository<Category> _categoryRepository;
        GenericRepository<Currency> _currencyRepository;
        GenericRepository<Goal> _goalRepository;
        GenericRepository<RecurTransaction> _recurTransactionRepository;
        GenericRepository<Transaction> _transactionRepository;
        GenericRepository<User> _userRepository;
        #endregion

        #region Constructor
        public UnitOfWork()
        {
            _context = new EntityDataContext();
        }
        #endregion

        #region Public Repository Creation methods.

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new GenericRepository<User>(_context);

                return this._userRepository;
            }
        }

        public GenericRepository<Account> AccountRepository
        {
            get
            {
                if (this._accountRepository == null)
                    this._accountRepository = new GenericRepository<Account>(_context);

                return this._accountRepository;
            }
        }

        public GenericRepository<AuthInfo> AuthInfoRepository
        {
            get
            {
                if (this._authInfoRepository == null)
                    this._authInfoRepository = new GenericRepository<AuthInfo>(_context);

                return this._authInfoRepository;
            }
        }

        public GenericRepository<Bank> BankRepository
        {
            get
            {
                if (this._bankRepository == null)
                    this._bankRepository = new GenericRepository<Bank>(_context);

                return this._bankRepository;
            }
        }

        public GenericRepository<Budget> BudgetRepository
        {
            get
            {
                if (this._budgetRepository == null)
                    this._budgetRepository = new GenericRepository<Budget>(_context);

                return this._budgetRepository;
            }
        }

        public GenericRepository<BudgetDetail> BudgetDetailRepository
        {
            get
            {
                if (this._budgetDetailRepository == null)
                    this._budgetDetailRepository = new GenericRepository<BudgetDetail>(_context);

                return this._budgetDetailRepository;
            }
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (this._categoryRepository == null)
                    this._categoryRepository = new GenericRepository<Category>(_context);

                return this._categoryRepository;
            }
        }

        public GenericRepository<Currency> CurrencyRepository
        {
            get
            {
                if (this._currencyRepository == null)
                    this._currencyRepository = new GenericRepository<Currency>(_context);

                return this._currencyRepository;
            }
        }

        public GenericRepository<Goal> GoalRepository
        {
            get
            {
                if (this._goalRepository == null)
                    this._goalRepository = new GenericRepository<Goal>(_context);

                return this._goalRepository;
            }
        }

        public GenericRepository<RecurTransaction> RecurTransactionRepository
        {
            get
            {
                if (this._recurTransactionRepository == null)
                    this._recurTransactionRepository = new GenericRepository<RecurTransaction>(_context);

                return this._recurTransactionRepository;
            }
        }

        public GenericRepository<Transaction> TransactionRepository
        {
            get
            {
                if (this._transactionRepository == null)
                    this._transactionRepository = new GenericRepository<Transaction>(_context);

                return this._transactionRepository;
            }
        }
        #endregion

        #region Public Method
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);
                throw e;
            }
        }

        #endregion

        #region Implementing IDiosposable...
        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
