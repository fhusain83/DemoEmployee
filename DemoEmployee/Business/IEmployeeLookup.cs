using DemoEmployee.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoEmployee.Business
{
  public  interface IEmployeeLookup
    {
         Task<IEnumerable<Employee>> findEmployeeByColumn(string columnName, string searchParam, string sortOrder);
    }
}
