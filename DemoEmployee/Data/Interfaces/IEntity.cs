using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoEmployee.Data.Models
{
    public interface IEntity

    {

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
