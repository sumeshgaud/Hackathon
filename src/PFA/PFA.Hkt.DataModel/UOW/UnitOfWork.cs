#region Using Namespaces...
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.Entity.Validation;
#endregion

namespace DataModel
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Private member variables...
        private EntityDataContext _context = null;
        private GenericRepository<Employee> _employeeRepository;
        private GenericRepository<TravelPlan> _travelPlanRepository;
        #endregion

        #region Constructor
        public UnitOfWork()
        {
            _context = new EntityDataContext();
        }
        #endregion

        #region Public Repository Creation methods.

        public GenericRepository<Employee> EmployeeRepository
        {
            get
            {
                if (this._employeeRepository == null)
                    this._employeeRepository = new GenericRepository<Employee>(_context);

                return this._employeeRepository;
            }
        }

        public GenericRepository<TravelPlan> TravelPlanRepository
        {
            get
            {
                if (this._travelPlanRepository == null)
                    this._travelPlanRepository = new GenericRepository<TravelPlan>(_context);

                return this._travelPlanRepository;
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
