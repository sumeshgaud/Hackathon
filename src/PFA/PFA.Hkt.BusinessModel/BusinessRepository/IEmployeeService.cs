using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public interface IEmployeeService
    {
        beEmployee GetEmployeeById(int employeeId);
        IEnumerable<beEmployee> GetAllEmployees();
        Guid CreateEmployee(beEmployee employeeEntity);
        bool UpdateEmployee(int employeeId, beEmployee employeeEntity);
        bool DeleteEmployee(int employeeId);
    }
}
