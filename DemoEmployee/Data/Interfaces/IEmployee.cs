using DemoEmployee.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoEmployee.Data.Interfaces
{
    
        public interface IEmployeeRepository : IRepository<Employee>
        {
        }
    
}
