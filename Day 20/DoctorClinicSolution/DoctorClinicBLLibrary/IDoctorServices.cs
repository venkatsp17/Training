
using DoctorClinicDALLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicBLLibrary
{
    public interface IDoctorServices
    {
        /// <summary>
        /// Function to add doctor
        /// </summary>
        /// <param name="doctor">doctor as (object of Doctor)</param>
        /// <returns></returns>
        Task<int> AddDoctor(Doctor doctor);
        /// <summary>
        /// Function to get particular Doctor by ID
        /// </summary>
        /// <param name="DoctorID">DoctorID as (int)</param>
        /// <returns></returns>
        Task<Doctor> GetDoctorById(int DoctorID);
        /// <summary>
        /// Function to get all Doctors of particular specialization
        /// </summary>
        /// <param name="specialization">specialization as (string)</param>
        /// <returns></returns>
        Task<IList<Doctor>> GetDoctorsBySpecialization(string specialization);
        /// <summary>
        /// Function to update Doctor Details
        /// </summary>
        /// <param name="doctor">doctor as (object of Doctor)</param>
        /// <returns></returns>
        Task<Doctor> UpdateDoctorDetails(Doctor doctor);
        /// <summary>
        /// Function to delete Doctor data
        /// </summary>
        /// <param name="doctor">doctor as (object of Doctor)</param>
        /// <returns></returns>
        Task<Doctor> DeleteDoctor(int DoctorID);
    }
}
