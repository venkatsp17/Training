using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestServices _requestServices;

        public RequestController(IRequestServices requestServices)
        {
            _requestServices = requestServices;
        }

        [Authorize]
        [Route("RaiseRequest")]
        [HttpPost]
        public async Task<ActionResult<Request>> Get([FromBody] RaiseRequestDTO raiseRequestDTO)
        {
            try
            {
                var employeeId = User.FindFirst(ClaimTypes.Name)?.Value;
                if (employeeId == null)
                {
                    throw new NotLoggedInException();
                }
                var request = await _requestServices.RaiseRequest(raiseRequestDTO);
                return Ok(request);
            }
            catch (NotLoggedInException ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
            catch (Exception nefe)
            {
                return NotFound(nefe.Message);
            }
        }

        [Authorize]
        [HttpGet("GetRequests")]
        [ProducesResponseType(typeof(IEnumerable<Request>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequest()
        {
            try
            {
                var employeeId = User.FindFirst(ClaimTypes.Name)?.Value;
                if (employeeId == null)
                {
                    throw new NotLoggedInException();
                }
                var result = await _requestServices.GetAllOpenRequest(Convert.ToInt32(employeeId));
                return Ok(result);
            }
            catch (NotLoggedInException ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }
    }
}
