using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using DataModel;
using AutoMapper;

namespace BusinessModel
{
  public class EmployeeService:IEmployeeService
    {
        private IUnitOfWork _unitOfWork;
        
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public beEmployee GetEmployeeById(int employeeId)
        {
            var employee= _unitOfWork.EmployeeRepository.GetById(employeeId);
            if (employee != null)
            {
                Mapper.CreateMap<Employee, beEmployee>();
                var employeeModel = Mapper.Map<Employee, beEmployee>(employee);
                return employeeModel;
            }
            return null;
        }

        public IEnumerable<beEmployee> GetAllEmployees()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll().ToList();
            if (employees != null)
            {
                Mapper.CreateMap<Employee, beEmployee>();
                var employeeModel = Mapper.Map<List<Employee>, List<beEmployee>>(employees);
                return employeeModel;
            }
            return null;
        }

        public Guid CreateEmployee(beEmployee employeeEntity)
        {
            using (var scope = new TransactionScope())
            {
                var Employee = new Employee
                {
                    FirstName = employeeEntity.FirstName,
                    MiddleName = employeeEntity.MiddleName,
                    LastName=employeeEntity.LastName,
                    Email=employeeEntity.Email,
                    Mobile=employeeEntity.Mobile
                };
                _unitOfWork.EmployeeRepository.Insert(Employee);
                _unitOfWork.Save();
                scope.Complete();
                return Employee.Id;
            }
        }

        public bool UpdateEmployee(int employeeId, beEmployee employeeEntity)
        {
            var success = false;
            if (employeeEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var employee = _unitOfWork.EmployeeRepository.GetById(employeeId);
                    if (employee != null)
                    {
                        employee.FirstName = employeeEntity.FirstName;
                        employee.MiddleName = employeeEntity.MiddleName;
                        employee.LastName = employeeEntity.LastName;
                        employee.Email = employeeEntity.Email;
                        employee.Mobile = employeeEntity.Mobile;

                        _unitOfWork.EmployeeRepository.Update(employee);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteEmployee(int employeeId)
        {
            var success = false;
            if (employeeId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var employee = _unitOfWork.EmployeeRepository.GetById(employeeId);
                    if (employee != null)
                    {
                        _unitOfWork.EmployeeRepository.Delete(employee);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
