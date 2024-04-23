﻿using DoctorClinicBLLibrary.AppointmentExceptions;
using DoctorClinicBLLibrary.GeneralExceptions;
using DoctorClinicBLLibrary;
using ModeClassDALLibrary;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicBLTest.AppointmentBLTest
{
    public class AppointmentBLGetAppointmentsForPatientTest
    {
        IRepository<int, Appointment> appointmentRepository;
        IAppointmentServices appointmentServices;
        [SetUp]

        public void Setup()
        {
            appointmentRepository = new AppointmentRepository();

        }

        [Test]
        public void GetAppointmentsForPatientSuccessTest()
        {
            //Arrange
            Doctor doctor = new Doctor() { DoctorID = 1, Age = 40, Experience = 10, LicenseNumber = "A123", Name = "JOHN", PhoneNumber = "1112223334", Qualification = "MD", Specialization = "ENT" };
            Patient patient = new Patient() { PatientId = 1, Name = "JOHN", PhoneNumber = "1112223334", Address = "TVL", DateOfBirth = Convert.ToDateTime("2002-09-01"), Gender = "Male" };
            Appointment appointment = new Appointment() { AppointmentDateTime = DateTime.Now, Doctor = doctor, Duration = TimeSpan.FromHours(1), Notes = "Fever", Patient = patient, Reason = "High Fever", Status = "Initiated" };
            appointmentRepository.Add(appointment);
            appointmentServices = new AppointmentBL(appointmentRepository);
            //Action
            var result = appointmentServices.GetAppointmentsForPatient(1);
            //Assert
            Assert.That(result[0].AppointmentId, Is.EqualTo(1));
        }

        [Test]
        public void GetAppointmentsForPatientAppointmentNotFoundExceptionTest()
        {
            //Arrange
            Doctor doctor = new Doctor() { Age = 40, Experience = 10, LicenseNumber = "A123", Name = "JOHN", PhoneNumber = "1112223334", Qualification = "MD", Specialization = "ENT" };
            Patient patient = new Patient() { Name = "JOHN", PhoneNumber = "1112223334", Address = "TVL", DateOfBirth = Convert.ToDateTime("2002-09-01"), Gender = "Male" };
            Appointment appointment = new Appointment() { AppointmentDateTime = DateTime.Now, Doctor = doctor, Duration = TimeSpan.FromHours(1), Notes = "Fever", Patient = patient, Reason = "High Fever", Status = "Initiated" };
            appointmentRepository.Add(appointment);
            appointmentServices = new AppointmentBL(appointmentRepository);
            var exception = Assert.Throws<AppointmentNotFoundException>(() => appointmentServices.GetAppointmentsForPatient(2));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Appointment Not Found!"));
        }

        [Test]
        public void GetAppointmentsForPatientNotDataAvailabeleExceptionTest()
        {
            //Arrange
            appointmentServices = new AppointmentBL(appointmentRepository);
            //Action
            var exception = Assert.Throws<NoDataAvailableException>(() => appointmentServices.GetAppointmentsForPatient(1));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("No Data Available"));
        }
    }
}