using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(IList<Employee>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<Employee>>> Get()
        {
            try
            {
                var employeeId = User.FindFirst(ClaimTypes.Name)?.Value;
                if (employeeId == null)
                {
                    throw new NotLoggedInException();
                }
                var employees = await _employeeService.GetEmployees();
                return Ok(employees.ToList());
            }
            catch (NotLoggedInException ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
            catch (NoEmployeesFoundException nefe)
            {
                return NotFound(new ErrorModel(404,nefe.Message));
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<Employee>> Put(int id, string phone)
        {
            try
            {
                var employeeId = User.FindFirst(ClaimTypes.Name)?.Value;
                if (employeeId == null)
                {
                    throw new NotLoggedInException();
                }
                var employee = await _employeeService.UpdateEmployeePhone(id, phone);
                return Ok(employee);
            }
            catch (NotLoggedInException ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
            catch (NoSuchEmployeeException nsee)
            {
                return NotFound(nsee.Message);
            }
        }

        [Authorize]
        [Route("GetEmployeeByPhone")]
        [HttpPost]
        public async Task<ActionResult<Employee>> Get([FromBody]string phone)
        {
            try
            {
                var employeeId = User.FindFirst(ClaimTypes.Name)?.Value;
                if (employeeId == null)
                {
                    throw new NotLoggedInException();
                }
                var employee = await _employeeService.GetEmployeeByPhone(phone);
                return Ok(employee);
            }
            catch (NotLoggedInException ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
            catch (NoSuchEmployeeException nefe)
            {
                return NotFound(nefe.Message);
            }
        }

    }
}
