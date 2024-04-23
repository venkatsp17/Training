using DoctorClinicBLLibrary.DoctorExceptions;
using DoctorClinicBLLibrary.PatientExceptions;
using ModeClassDALLibrary;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicBLLibrary
{
    public class PatientBL: IPatientServices
    {
        readonly IRepository<int, Patient> _patientRepository;
        PatientBL(IRepository<int, Patient> repository)
        {
            _patientRepository = repository;
        }

        public int AddPatient(Patient patient)
        {
            var result = _patientRepository.Add(patient);
            if (result != null)
            {
                return result.PatientId;
            }

            throw new DuplicatePatientException();
        }

        public Patient DeletePatient(int PatientID)
        {
            Patient patient = _patientRepository.Get(PatientID);
            if (patient != null)
            {
                return _patientRepository.Delete(PatientID);
            }
            throw new PatientNotFoundException();
        }

        public Patient GetPatientById(int PatientID)
        {
            Patient patient = _patientRepository.Get(PatientID);
            if (patient != null)
            {
                return patient;
            }
            throw new PatientNotFoundException();
        }

        public Patient UpdatePatient(Patient patient)
        {
            Patient patient1 = _patientRepository.Get(patient.PatientId);
            if (patient1 != null)
            {
                return _patientRepository.Update(patient1);
            }
            throw new PatientNotFoundException();
        }
    }
}
