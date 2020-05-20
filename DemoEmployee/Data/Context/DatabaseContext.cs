using DemoEmployee.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DemoEmployee.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public  DbSet<Employee> employees { get; set; }
        public DatabaseContext()
        { }
        public  DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }
        
    }
}
