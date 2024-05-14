using DoctorClinicAPI.Models;

namespace DoctorClinicAPI.Services
{
    public interface IDoctorServices
    {
        public Task<Doctor> UpdateDoctorExperience(int DoctorID, int Experience);
        public Task<IEnumerable<Doctor>> GetDoctors();
        public Task<IEnumerable<Doctor>> GetDoctorSpeciality(string speciality);
    }
}
