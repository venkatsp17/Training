using DoctorClinicBLLibrary.GeneralExceptions;
using ModeClassDALLibrary;
using DoctorClinicBLLibrary.DoctorExceptions;
using System.Diagnostics.CodeAnalysis;
using DoctorClinicDALLibrary.Models;

namespace DoctorClinicBLLibrary
{
    public class DoctorBL : IDoctorServices
    {
        readonly IRepository<int, Doctor> _doctorRepository;
        [ExcludeFromCodeCoverage]
        public DoctorBL(IRepository<int, Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<int> AddDoctor(Doctor doctor)
        {
            var result = await _doctorRepository.Add(doctor);
            if(result != null)
            {
                return result.DoctorId;
            }

            throw new DuplicateDoctorException();
        }

        public async Task<Doctor> DeleteDoctor(int DoctorID)
        {
            Doctor doctor = await _doctorRepository.Get(DoctorID);
            if (doctor != null)
            {
                return await _doctorRepository.Delete(DoctorID);
            }
            throw new DoctorNotFoundException();
        }

        public async Task<Doctor> GetDoctorById(int DoctorID)
        {
            Doctor doctor = await _doctorRepository.Get(DoctorID);
            if (doctor != null)
            {
                return doctor;
            }
            throw new DoctorNotFoundException();
        }

        public async Task<IList<Doctor>> GetDoctorsBySpecialization(string specialization)
        {
            IList<Doctor> doctors = await _doctorRepository.GetAll();
            IList<Doctor> result = new List<Doctor>();
            if(doctors!= null)
            {
                foreach (var doctor in doctors)
                {
                    if(doctor.Specialization == specialization)
                    {
                        result.Add(doctor);
                    }
                }
                if(result.Count > 0)
                {
                    return result;
                }
                else
                {
                    throw new DoctorNotFoundException();
                }
            }
            throw new NoDataAvailableException();
        }

        public async Task<Doctor> UpdateDoctorDetails(Doctor doctor)
        {
            Doctor doctor1 = await _doctorRepository.Get(doctor.DoctorId);
            if (doctor1 != null)
            {
                return await _doctorRepository.Update(doctor1);
            }
            throw new DoctorNotFoundException();
        }
    }
}
