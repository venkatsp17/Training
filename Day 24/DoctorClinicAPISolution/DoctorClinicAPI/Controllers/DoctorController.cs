using DoctorClinicAPI.Exceptions;
using DoctorClinicAPI.Models;
using DoctorClinicAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorServices _doctorService;

        public DoctorController(IDoctorServices doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> Get()
        {
            try
            {
                var doctors = await _doctorService.GetDoctors();
                return Ok(doctors.ToList());
            }
            catch (NoDoctorFoundException nefe)
            {
                return NotFound(nefe.Message);
            }
        }

        [Route("GetDoctorBySpeialization")]
        [HttpPost]
        public async Task<ActionResult<IList<Doctor>>> Get([FromBody] string specialization)
        {
            try
            {
                var doctor = await _doctorService.GetDoctorSpeciality(specialization);
                return Ok(doctor);
            }
            catch (NoDoctorFoundException nefe)
            {
                return NotFound(nefe.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Doctor>> Update(int DoctorID, int experience)
        {
            try
            {
                var doctor = await _doctorService.UpdateDoctorExperience(DoctorID, experience);
                return Ok(doctor);
            }
            catch (NoDoctorFoundException nefe)
            {
                return NotFound(nefe.Message);
            }
        }
    }
}
