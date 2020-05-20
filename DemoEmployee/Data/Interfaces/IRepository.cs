using DemoEmployee.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoEmployee.Data.Interfaces
{
    public interface IRepository<T> where T : BaseEntity

    {

        IEnumerable<T> GetAll();
        void AddRange(IEnumerable<T> entities);
        T GetById(int id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(int id);

    }
}
