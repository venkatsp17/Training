using EmployeeAPIApp.Exceptions;
using EmployeeAPIApp.Models;
using EmployeeAPIApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeService;

        public EmployeeController(IEmployeeServices employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult<IList<Employee>>> Get()
        {
            try
            {
                var employees = await _employeeService.GetEmployees();
                return Ok(employees.ToList());
            }
            catch (NoEmployeeFoundException nefe)
            {
                return NotFound(nefe.Message);
            }
        }

        [Route("GetEmployeeByPhone")]
        [HttpPost]
        public async Task<ActionResult<Employee>> Get([FromBody] string phone)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByPhone(phone);
                return Ok(employee);
            }
            catch (NoEmployeeFoundException nefe)
            {
                return NotFound(nefe.Message);
            }
        }
    }
}
