using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoEmployee.Data.DTO
{
    public class Employee 
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string jobTitle { get; set; }
        public string phoneNumber { get; set; }
        public DateTime hireDate { get; set; }
      
    }
}
