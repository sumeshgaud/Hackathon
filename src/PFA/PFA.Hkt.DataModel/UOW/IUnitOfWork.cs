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
        GenericRepository<Employee> EmployeeRepository { get; }
        GenericRepository<TravelPlan> TravelPlanRepository { get; }
        #endregion

        void Save();
    }
}
