using DemoEmployee.Data.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using DemoEmployee.Controllers;
using DemoEmployee.Business;
using AutoMapper;
using DemoEmployee.Data.Context;
using DemoEmployee.Data.Models;
using Microsoft.EntityFrameworkCore;
using DemoEmployee.Data.Repositories;
using Xunit;
using System.Threading.Tasks;
using System.Linq;

namespace XUnitDemoEmployeeTestProject.Controller
{
    public class EmployeesControllerTests
    {
        private  Mock<DatabaseContext> _mockContext;
        private readonly Mock<UnitOfWork> _mockUOW;
        private readonly IEmployeeLookup _mockBus;
       // private readonly DemoEmployeeController _controller;
        private readonly Mapper IMapper;
        public EmployeesControllerTests()
        {
            var myProfile = new MapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
          
            setUpDb();
            _mockUOW = new Mock<UnitOfWork>(_mockContext.Object);
            _mockBus = new EmployeeLookup(_mockUOW.Object);
           // _controller = new DemoEmployeeController(_mockBus,mapper);
        }


        public void setUpDb()
        {
           
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
            var employeeDbSet =
                DbSetExtensions.GetQueryableMockDbSet(listEmployees);
            _mockContext = new Mock<DatabaseContext>();
            _mockContext.Setup(x => x.employees).Returns(employeeDbSet);
        }
       
        [Fact]
        public async Task<int> GetEmployeeByColumn_ReturnsSearchedEmployeesFirstName()
        {
            var result = await _mockBus.findEmployeeByColumn("First Name","a","asc");
            result.ToList().ForEach(x => Assert.Contains("a", x.firstName));
            return 1;
           
        }



        [Fact]
        public async Task<int> GetEmployeeByColumn_ReturnsSearchedEmployeesLastName()
        {
            var result = await _mockBus.findEmployeeByColumn("Last Name", "a", "asc");
            result.ToList().ForEach(x => Assert.Contains("a", x.lastName));
            
            return 1;

        }

        [Fact]
        public async Task<int> GetEmployeeByColumn_ReturnsSearchedEmployeesEmail()
        {
            var result = await _mockBus.findEmployeeByColumn("Last Name", "a", "asc"); 
            result.ToList().ForEach(x => Assert.Equal("awagner@gmail.com", x.email));

            return 1;

        }

        [Fact]
        public async Task<int> GetEmployeeByColumn_ReturnsSearchedEmployeesJobTitle()
        {
            var result = await _mockBus.findEmployeeByColumn("Last Name", "Senior Software Developer", "asc"); 
            result.ToList().ForEach(x => Assert.Equal("Senior Software Developer", x.jobTitle));

            return 1;

        }

        [Fact]
        public async Task<int> GetEmployeeByColumn_ReturnsSearchedEmployeesPhone()
        {
            var result = await _mockBus.findEmployeeByColumn("Phone", "4699553041", "asc");
            result.ToList().ForEach(x => Assert.Equal("4699553041", x.phoneNumber));

            return 1;

        }

        [Fact]
        public async Task<int> GetEmployeeByColumn_ReturnsSearchedEmployeesHireDate()
        {
            var result = await _mockBus.findEmployeeByColumn("Hire Date", "1/1/2012", "asc"); 
            result.ToList().ForEach(x => Assert.Equal(new DateTime(2012, 1, 1), x.hireDate));

            return 1;

        }

    }
    public static class DbSetExtensions
    {
        public static DbSet<Employee> GetQueryableMockDbSet(this IEnumerable<Employee> sourceList) //where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<Employee>>();
            dbSet.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            
            return dbSet.Object;
        }
    }
}
