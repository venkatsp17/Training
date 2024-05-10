﻿
using DoctorClinicDALLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicBLLibrary
{
    public interface IAppointmentServices
    {
        /// <summary>
        /// Function to schedule Appointment
        /// </summary>
        /// <param name="appointment">appointment as (object of Appointment)</param>
        /// <returns></returns>
        Task<int> ScheduleAppointment(Appointment appointment);
        /// <summary>
        /// Function to Cancel Appointment
        /// </summary>
        /// <param name="AppointmentID">AppointmentID as (int)</param>
        /// <returns></returns>
        Task<Appointment> CancelAppointment(int AppointmentID);
        /// <summary>
        /// Function to Reschedule Appointment
        /// </summary>
        /// <param name="AppointmentID">AppointmentID as (int)</param>
        /// <returns></returns>
        Task<Appointment> RescheduleAppointment(int AppointmentID, DateTime newDateTime);
        /// <summary>
        /// Get particular Appointment By Id
        /// </summary>
        /// <param name="AppointmentID">AppointmentID as (int)</param>
        /// <returns></returns>
        Task<Appointment> GetAppointmentById(int AppointmentID);
        /// <summary>
        /// Function to Update Appointment Status
        /// </summary>
        /// <param name="AppointmentID">AppointmentID as (int)</param>
        /// <returns></returns>
        Task<Appointment> UpdateAppointmentStatus(int AppointmentID, string status);
        /// <summary>
        /// Function to get all Apointment by particular status
        /// </summary>
        /// <param name="status">Status as (string)</param>
        /// <returns></returns>
        Task<IList<Appointment>> GetAppointmentsByStatus(string status);
        /// <summary>
        /// Function to get Appointments alloted by particular Patient
        /// </summary>
        /// <param name="PatientID">PatientID as (int)</param>
        /// <returns></returns>
        Task<IList<Appointment>> GetAppointmentsForPatient(int PatientID);
        /// <summary>
        /// Function to get Appointments allocated to particular Doctor
        /// </summary>
        /// <param name="DoctorID">DoctorID as (int)</param>
        /// <returns></returns>
        Task<IList<Appointment>> GetAppointmentsForDoctor(int DoctorID);
        /// <summary>
        /// Function to check Availability of particular Doctor at required Date and Time
        /// </summary>
        /// <param name="DoctorID">DoctorID as (int)</param>
        /// <param name="date">date as (DateTime)</param>
        /// <returns></returns>
        Task<bool> CheckAvailability(int DoctorID, DateTime date);

    }
}
