using DemoEmployee.Data.Context;
using DemoEmployee.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoEmployee.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;
        public UnitOfWork(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEmployeeRepository employeeRepository
        {
            get
            {
                return new EmployeeRepository(_databaseContext);
            }
        }



        public void Commit()

        { _databaseContext.SaveChanges(); }



        public void RollBack()

        { _databaseContext.Dispose(); }

    }
}
