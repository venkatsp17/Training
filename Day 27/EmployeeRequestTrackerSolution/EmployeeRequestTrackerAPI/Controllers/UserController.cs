using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Login")]
        [ProducesResponseType(typeof(LoginReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginReturnDTO>> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                var result = await _userService.Login(userLoginDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }
        [HttpPost("Register")]
        [ProducesResponseType(typeof(RegisterReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RegisterReturnDTO>> Register(EmployeeUserDTO userDTO)
        {
            try
            {
                RegisterReturnDTO result = await _userService.Register(userDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("UpdateAccountStatus")]
        [HttpPut]
        public async Task<ActionResult<string>> UpdateStatus(UpdateUserStatusDTO updateStatusDTO)
        {
           
            try
            {
                var employeeId = User.FindFirst(ClaimTypes.Name)?.Value;
                if (employeeId == null)
                {
                    throw new NotLoggedInException();
                }
                var employee = await _userService.UpdateUserAccountStatus(updateStatusDTO);
                return Ok(employee);
            }
            catch (NotLoggedInException ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
            catch (Exception nsee)
            {
                return NotFound(nsee.Message);
            }
        }
    }
}
