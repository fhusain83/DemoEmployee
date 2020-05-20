using DemoEmployee.Data.Context;
using DemoEmployee.Data.Interfaces;
using DemoEmployee.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoEmployee.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DatabaseContext _context) : base(_context)
        {

        }
    }
}
