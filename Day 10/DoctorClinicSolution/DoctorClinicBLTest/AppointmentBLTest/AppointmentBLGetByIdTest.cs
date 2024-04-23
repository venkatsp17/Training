﻿using DoctorClinicBLLibrary.GeneralExceptions;
using DoctorClinicBLLibrary;
using ModeClassDALLibrary;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorClinicBLLibrary.AppointmentExceptions;

namespace DoctorClinicBLTest.AppointmentBLTest
{
    public class AppointmentBLGetByIdTest
    {
        IRepository<int, Appointment> appointmentRepository;
        IAppointmentServices appointmentServices;
        [SetUp]

        public void Setup()
        {
            appointmentRepository = new AppointmentRepository();
           
        }

        [Test]
        public void GetAppointmentByIdSuccessTest()
        {
            //Arrange
            Doctor doctor = new Doctor() { Age = 40, Experience = 10, LicenseNumber = "A123", Name = "JOHN", PhoneNumber = "1112223334", Qualification = "MD", Specialization = "ENT" };
            Patient patient = new Patient() { Name = "JOHN", PhoneNumber = "1112223334", Address = "TVL", DateOfBirth = Convert.ToDateTime("2002-09-01"), Gender = "Male" };
            Appointment appointment = new Appointment() { AppointmentDateTime = DateTime.Now, Doctor = doctor, Duration = TimeSpan.FromHours(1), Notes = "Fever", Patient = patient, Reason = "High Fever", Status = "Initiated" };
            appointmentRepository.Add(appointment);
            appointmentServices = new AppointmentBL(appointmentRepository);
            //Action
            var result = appointmentServices.GetAppointmentById(1);
            //Assert
            Assert.That(result.AppointmentId, Is.EqualTo(1));
        }

        [Test]
        public void GetAppointmentByIdAppointmentNotFoundExceptionTest()
        {
            //Arrange
            appointmentServices = new AppointmentBL(appointmentRepository);
            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => appointmentServices.GetAppointmentById(1));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Appointment Not Found!"));
        }
    }
}
