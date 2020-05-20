using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoEmployee.Business;
using DemoEmployee.Data.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using System.Threading;

namespace DemoEmployee.Controllers
{
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("[controller]")]
    public class DemoEmployeeController : ControllerBase
    {
        IEmployeeLookup employeeLookup;
        IMapper mapper;
        public DemoEmployeeController(IEmployeeLookup _employeeLookup,IMapper _mapper)
        {
            this.employeeLookup = _employeeLookup;
            this.mapper = _mapper;
            
        }

        [HttpGet]
        public async Task<List<Employee>> GetEmployeeByColumn(string columnName, string searchParam, string sortOrder)
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            List<Employee> retEmployees = new List<Employee>();
            var employees = await employeeLookup.findEmployeeByColumn(columnName, searchParam, sortOrder);
            retEmployees= mapper.Map<List<Employee>>(employees);
            return retEmployees;
        }
    }
}
