using DoctorClinicBLLibrary.DoctorExceptions;
using DoctorClinicBLLibrary.PatientExceptions;
using DoctorClinicDALLibrary.Models;
using ModeClassDALLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicBLLibrary
{
    public class PatientBL: IPatientServices
    {
        readonly IRepository<int, Patient> _patientRepository;
        [ExcludeFromCodeCoverage]
        public PatientBL(IRepository<int, Patient> repository)
        {
            _patientRepository = repository;
        }

        public async Task<int> AddPatient(Patient patient)
        {
            var result = await _patientRepository.Add(patient);
            if (result != null)
            {
                return result.PatientId;
            }

            throw new DuplicatePatientException();
        }

        public async Task<Patient> DeletePatient(int PatientID)
        {
            Patient patient = await _patientRepository.Get(PatientID);
            if (patient != null)
            {
                return await _patientRepository.Delete(PatientID);
            }
            throw new PatientNotFoundException();
        }

        public async Task<Patient> GetPatientById(int PatientID)
        {
            Patient patient = await _patientRepository.Get(PatientID);
            if (patient != null)
            {
                return patient;
            }
            throw new PatientNotFoundException();
        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {
            Patient patient1 = await _patientRepository.Get(patient.PatientId);
            if (patient1 != null)
            {
                return await _patientRepository.Update(patient1);
            }
            throw new PatientNotFoundException();
        }
    }
}
