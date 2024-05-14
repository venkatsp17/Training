using DoctorClinicAPI.Exceptions;
using DoctorClinicAPI.Models;
using DoctorClinicAPI.Repositories;
using System.Collections.Generic;

namespace DoctorClinicAPI.Services
{
    public class DoctorBasicService : IDoctorServices
    {
        private readonly IRepository<int, Doctor> _repository;

        public DoctorBasicService(IRepository<int, Doctor> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = await _repository.Get();
            if (doctors.Count() == 0)
                throw new NoDoctorFoundException();
            return doctors;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorSpeciality(string speciality)
        {
            var doctors = await _repository.Get();
            if (doctors.Count() == 0)
                throw new NoDoctorFoundException();
            List<Doctor> specialDoctors = new List<Doctor>();
            foreach (var doctor in doctors)
            {
                if(doctor.Specialization == speciality)
                {
                   specialDoctors.Add(doctor);
                }
            }
            return specialDoctors;
        }

        public async Task<Doctor> UpdateDoctorExperience(int DoctorID, int Experience)
        {
            var doctor = await _repository.Get(DoctorID);
            if (doctor == null)
                throw new NoDoctorFoundException();
            doctor.Experience = Experience;
            doctor = await _repository.Update(doctor);
            return doctor;
        }
    }
}
