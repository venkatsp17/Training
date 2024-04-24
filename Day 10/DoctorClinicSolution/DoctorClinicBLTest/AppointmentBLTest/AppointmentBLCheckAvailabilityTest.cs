using DoctorClinicBLLibrary;
using DoctorClinicBLLibrary.GeneralExceptions;
using ModeClassDALLibrary;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicBLTest.AppointmentBLTest
{
    public class AppointmentBLCheckAvailabilityTest
    {
        IRepository<int, Appointment> appointmentRepository;
        IAppointmentServices appointmentServices;
        [SetUp]

        public void Setup()
        {
            appointmentRepository = new AppointmentRepository();
            appointmentServices = new AppointmentBL(appointmentRepository);
        }

        [Test]
        public void CheckAvailabilitySuccessTest()
        {
            //Arrange
            Doctor doctor = new Doctor() { Age = 40, Experience = 10, LicenseNumber = "A123", Name = "JOHN", PhoneNumber = "1112223334", Qualification = "MD", Specialization = "ENT" };
            Patient patient = new Patient() { Name = "JOHN", PhoneNumber = "1112223334", Address = "TVL", DateOfBirth = Convert.ToDateTime("2002-09-01"), Gender = "Male" };
            Appointment appointment = new Appointment() { AppointmentDateTime = DateTime.Now, Doctor = doctor, Duration = TimeSpan.FromHours(1), Notes = "Fever", Patient = patient, Reason = "High Fever", Status = "Initiated" };
            appointmentRepository.Add(appointment);
            //Action
            var result = appointmentServices.CheckAvailability(1, DateTime.Now);
            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CheckAvailabilityNoDataAvailableExceptionTest()
        {
            //Arrange
            
            //Action
            var exception = Assert.Throws<NoDataAvailableException>(() => appointmentServices.CheckAvailability(1, DateTime.Now));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("No Data Available"));
        }
    }
}
