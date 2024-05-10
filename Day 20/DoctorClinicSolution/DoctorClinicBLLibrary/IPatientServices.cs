
using DoctorClinicDALLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicBLLibrary
{
    public interface IPatientServices
    {
        /// <summary>
        /// Function to add patient
        /// </summary>
        /// <param name="patient">patient as (object of patient)</param>
        /// <returns></returns>
        Task<int> AddPatient(Patient patient);
        /// <summary>
        /// Function to get particular Patient by Id
        /// </summary>
        /// <param name="PatientID">PatientID as (int)</param>
        /// <returns></returns>
        Task<Patient> GetPatientById(int PatientID);
        /// <summary>
        /// Function to Update Patient Details
        /// </summary>
        /// <param name="patient">patient as (object of patient)</param>
        /// <returns></returns>
        Task<Patient> UpdatePatient(Patient patient);

        Task<Patient> DeletePatient(int PatientID);
    }
}
