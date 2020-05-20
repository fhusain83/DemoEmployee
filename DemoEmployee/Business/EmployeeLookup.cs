using DemoEmployee.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.DynamicLinq;
using DemoEmployee.Data.Models;

namespace DemoEmployee.Business
{
    public class EmployeeLookup :IEmployeeLookup
    {
        IUnitOfWork uow;
        public EmployeeLookup(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        public async Task<IEnumerable<Employee>> findEmployeeByColumn(string columnName, string searchParam, string sortOrder)
        {

           return await Task.Run(() => {
               IEnumerable<Employee> allEmployees = new List<Employee>() ;
                try
                {

                    switch (columnName)
                    {
                        case "Id":
                            allEmployees = uow.employeeRepository.GetAll().Where(col => col.Id == Int32.Parse(searchParam));
                            break;
                        case "First Name":
                            allEmployees = uow.employeeRepository.GetAll().Where(col => col.firstName.Contains(searchParam, StringComparison.CurrentCultureIgnoreCase));
                            break;
                        case "Last Name":
                            allEmployees = uow.employeeRepository.GetAll().Where(col => col.lastName.Contains(searchParam, StringComparison.CurrentCultureIgnoreCase)); 
                           break;
                        case "Email":
                            allEmployees = uow.employeeRepository.GetAll().Where(col => col.email == searchParam);
                            break;
                        case "Job Title":
                            allEmployees = uow.employeeRepository.GetAll().Where(col => col.jobTitle.Contains(searchParam, StringComparison.CurrentCultureIgnoreCase));
                            break;
                        case "Phone Number":
                            allEmployees = uow.employeeRepository.GetAll().Where(col => col.phoneNumber == searchParam);
                            break;
                        case "Hire Date":
                            allEmployees = uow.employeeRepository.GetAll().Where(col => col.hireDate == DateTime.Parse(searchParam));
                            break;
                       case "Any":
                           allEmployees = uow.employeeRepository.GetAll().Where(m => m.GetType().GetProperties().Any(x => x.GetValue(m, null) != null && x.GetValue(m, null).ToString().Contains(searchParam))) ;
                           break;
                       default:
                            // column not handled - nothing to filter
                            break;
                    }

                }
                catch (Exception ex)
                { }
               return allEmployees;
            });
            
        }

    }
}
