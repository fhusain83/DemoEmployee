using DemoEmployee.Data.Context;
using DemoEmployee.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoEmployee.InMemoryDB
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(
                serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            {
                // Look for any board games.
                if (context.employees.Any())
                {
                    return;   // Data was already seeded
                }
                var listEmployees = new List<Employee>();
                listEmployees.Add(new Employee
                {
                    Id = 1,
                    firstName = "Adam",
                    lastName = "Wagner",
                    email = "awagner@gmail.com",
                    jobTitle = "Senior Software Developer",
                    phoneNumber = "4699553041",
                    hireDate = new DateTime(2012, 1, 1)

                });
                listEmployees.Add(new Employee
                {
                    Id = 2,
                    firstName = "Ben",
                    lastName = "Carson",
                    email = "bCarson@gmail.com",
                    jobTitle = "Senior QA",
                    phoneNumber = "4699553042",
                    hireDate = new DateTime(2012, 1, 2)
                });
                     listEmployees.Add(new Employee
                     {
                         Id = 3,
                         firstName = "Caleb",
                         lastName = "Rob",
                         email = "crob@gmail.com",
                         jobTitle = "Senior Business Analyst",
                         phoneNumber = "4699553043",
                         hireDate = new DateTime(2012, 1, 3)
                     });
                      listEmployees.Add(new Employee
                      {
                          Id = 4,
                          firstName = "David",
                          lastName = "Brown",
                          email = "dbrown@gmail.com",
                          jobTitle = "Senior Manager",
                          phoneNumber = "4699553043",
                          hireDate = new DateTime(2012, 1, 7)
                      });
                      listEmployees.Add(new Employee
                      {
                          Id = 5,
                          firstName = "Emily",
                          lastName = "Hart",
                          email = "ehart@gmail.com",
                          jobTitle = "Senior Database Developer",
                          phoneNumber = "4699553044",
                          hireDate = new DateTime(2012, 1, 1)
                      });
                      listEmployees.Add(new Employee
                    {
                        Id = 6,
                        firstName = "Frank",
                        lastName = "Sinatra",
                        email = "fsinatra@gmail.com",
                        jobTitle = "Senior Technical Writer",
                        phoneNumber = "4699553045",
                        hireDate = new DateTime(2012, 1, 1)
                    });
                context.employees.AddRange(listEmployees);
    

                context.SaveChanges();
            }
        }
    }
}
