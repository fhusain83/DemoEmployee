using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoEmployee.Data.Interfaces
{
   public interface IUnitOfWork
    {
        IEmployeeRepository employeeRepository { get; }
        void Commit();
        void RollBack();

    }
}
