using DoctorClinicBLLibrary.GeneralExceptions;
using ModeClassDALLibrary;
using ModelClassLibrary;
using DoctorClinicBLLibrary.DoctorExceptions;
namespace DoctorClinicBLLibrary
{
    public class DoctorBL : IDoctorServices
    {
        readonly IRepository<int, Doctor> _doctorRepository;

        public DoctorBL(IRepository<int, Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public int AddDoctor(Doctor doctor)
        {
            var result = _doctorRepository.Add(doctor);
            if(result != null)
            {
                return result.DoctorID;
            }

            throw new DuplicateDoctorException();
        }

        public Doctor DeleteDoctor(int DoctorID)
        {
            Doctor doctor = _doctorRepository.Get(DoctorID);
            if (doctor != null)
            {
                return _doctorRepository.Delete(DoctorID);
            }
            throw new DoctorNotFoundException();
        }

        public Doctor GetDoctorById(int DoctorID)
        {
            Doctor doctor = _doctorRepository.Get(DoctorID);
            if (doctor != null)
            {
                return doctor;
            }
            throw new DoctorNotFoundException();
        }

        public List<Doctor> GetDoctorsBySpecialization(string specialization)
        {
            List<Doctor> doctors = _doctorRepository.GetAll();
            List<Doctor> result = new List<Doctor>();
            if(doctors!= null)
            {
                foreach (var doctor in doctors)
                {
                    if(doctor.Specialization == specialization)
                    {
                        result.Add(doctor);
                    }
                }
                return result;
            }
            throw new NoDataAvailableException();
        }

        public Doctor UpdateDoctorDetails(Doctor doctor)
        {
            Doctor doctor1 = _doctorRepository.Get(doctor.DoctorID);
            if (doctor1 != null)
            {
                return _doctorRepository.Update(doctor1);
            }
            throw new DoctorNotFoundException();
        }
    }
}
