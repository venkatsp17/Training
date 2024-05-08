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

        public Appointment CancelAppointment(int AppointmentID)
        {
            Appointment appointment = _appointmentRepository.Get(AppointmentID);
            if (appointment != null)
            {
                appointment.Status = "Canceled";
                return _appointmentRepository.Update(appointment);
            }
            throw new AppointmentNotFoundException();
        }

        public bool CheckAvailability(int DoctorID, DateTime date)
        {
            List<Appointment> appointments = _appointmentRepository.GetAll();
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

        public Appointment GetAppointmentById(int AppointmentID)
        {
            Appointment appointment = _appointmentRepository.Get(AppointmentID);
            if (appointment != null)
            {
                return appointment;
            }
            throw new AppointmentNotFoundException();
        }

        public List<Appointment> GetAppointmentsByStatus(string status)
        {
            List<Appointment> appointments = _appointmentRepository.GetAll();
            List<Appointment> result = new List<Appointment>();
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

        public List<Appointment> GetAppointmentsForDoctor(int DoctorID)
        {
            List<Appointment> appointments = _appointmentRepository.GetAll();
            List<Appointment> result = new List<Appointment>();
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

        public List<Appointment> GetAppointmentsForPatient(int PatientID)
        {
            List<Appointment> appointments = _appointmentRepository.GetAll();
            List<Appointment> result = new List<Appointment>();
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

        public Appointment RescheduleAppointment(int AppointmentID, DateTime newDateTime)
        {
            Appointment appointment = _appointmentRepository.Get(AppointmentID);
            if (appointment != null)
            {
                appointment.AppointmentDateTime = newDateTime;
                return _appointmentRepository.Update(appointment);
            }
            throw new AppointmentNotFoundException();
    }
        [ExcludeFromCodeCoverage]
        public int ScheduleAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }
       
        public Appointment UpdateAppointmentStatus(int AppointmentID, string status)
        {
            Appointment appointment = _appointmentRepository.Get(AppointmentID);
            if (appointment != null)
            {
                appointment.Status = status;
                return _appointmentRepository.Update(appointment);
            }
            throw new AppointmentNotFoundException();
        }
    }
}
