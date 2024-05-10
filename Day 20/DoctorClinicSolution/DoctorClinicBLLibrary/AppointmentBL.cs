using DoctorClinicBLLibrary.AppointmentExceptions;
using DoctorClinicBLLibrary.GeneralExceptions;
using DoctorClinicDALLibrary.Models;
using ModeClassDALLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicBLLibrary
{
    public class AppointmentBL: IAppointmentServices
    {
        readonly IRepository<int, Appointment> _appointmentRepository;

        public AppointmentBL(IRepository<int, Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Appointment> CancelAppointment(int AppointmentID)
        {
            Appointment appointment = await _appointmentRepository.Get(AppointmentID);
            if (appointment != null)
            {
                appointment.Status = "Canceled";
                return await _appointmentRepository.Update(appointment);
            }
            throw new AppointmentNotFoundException();
        }

        public async Task<bool> CheckAvailability(int DoctorID, DateTime date)
        {
            IList<Appointment> appointments = await _appointmentRepository.GetAll();
            bool available = true;
            if (appointments != null)
            {
                foreach (var appointment in appointments)
                {
                    if(appointment.Doctor.DoctorId == DoctorID && appointment.AppointmentDateTime == date)
                    {
                        available = false;
                    }
                }
                return available;
            }
            throw new NoDataAvailableException();
        }

        public async Task<Appointment> GetAppointmentById(int AppointmentID)
        {
            Appointment appointment = await _appointmentRepository.Get(AppointmentID);
            if (appointment != null)
            {
                return appointment;
            }
            throw new AppointmentNotFoundException();
        }

        public async Task<IList<Appointment>> GetAppointmentsByStatus(string status)
        {
            IList<Appointment> appointments = await _appointmentRepository.GetAll();
            IList<Appointment> result = new List<Appointment>();
            if (appointments != null)
            {
                foreach (var appointment in appointments)
                {
                    if (appointment.Status == status)
                    {
                        result.Add(appointment);
                    }
                }
                if(result.Count > 0)
                {
                    return result;
                }
                else
                {
                    throw new AppointmentNotFoundException();
                }
            }
            throw new NoDataAvailableException();
        }

        public async Task<IList<Appointment>> GetAppointmentsForDoctor(int DoctorID)
        {
            IList<Appointment> appointments = await _appointmentRepository.GetAll();
            IList<Appointment> result = new List<Appointment>();
            if (appointments != null)
            {
                foreach (var appointment in appointments)
                {
                    if ((appointment.Doctor).DoctorId == DoctorID)
                    {
                        result.Add(appointment);
                    }
                }
                if (result.Count > 0)
                {
                    return result;
                }
                else
                {
                    throw new AppointmentNotFoundException();
                }
            }
            throw new NoDataAvailableException();
        }

        public async Task<IList<Appointment>> GetAppointmentsForPatient(int PatientID)
        {
            IList<Appointment> appointments = await _appointmentRepository.GetAll();
            IList<Appointment> result = new List<Appointment>();
            if (appointments != null)
            {
                foreach (var appointment in appointments)
                {
                    if (appointment.Patient.PatientId == PatientID)
                    {
                        result.Add(appointment);
                    }
                }
                if (result.Count > 0)
                {
                    return result;
                }
                else
                {
                    throw new AppointmentNotFoundException();
                }
            }
            throw new NoDataAvailableException();
        }

        public async Task<Appointment> RescheduleAppointment(int AppointmentID, DateTime newDateTime)
        {
            Appointment appointment = await _appointmentRepository.Get(AppointmentID);
            if (appointment != null)
            {
                appointment.AppointmentDateTime = newDateTime;
                return await _appointmentRepository.Update(appointment);
            }
            throw new AppointmentNotFoundException();
    }
        [ExcludeFromCodeCoverage]
        public Task<int> ScheduleAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }
       
        public async Task<Appointment> UpdateAppointmentStatus(int AppointmentID, string status)
        {
            Appointment appointment = await _appointmentRepository.Get(AppointmentID);
            if (appointment != null)
            {
                appointment.Status = status;
                return await _appointmentRepository.Update(appointment);
            }
            throw new AppointmentNotFoundException();
        }
    }
}
