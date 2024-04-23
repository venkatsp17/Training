using DoctorClinicBLLibrary;
using DoctorClinicBLLibrary.DoctorExceptions;
using ModeClassDALLibrary;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicBLTest.DoctorBLTest
{
    public class DoctorBLAddTest
    {
        IRepository<int, Doctor> doctorrepository;
        IDoctorServices doctorServices;
        [SetUp]

        public void Setup()
        {
            doctorrepository = new DoctorRepository();
            doctorServices = new DoctorBL(doctorrepository);
        }

        [Test]
        public void AddDoctorSuccessTest()
        {
            //Arrange
            Doctor doctor = new Doctor() { Age = 40, Experience = 10, LicenseNumber = "A123", Name = "JOHN", PhoneNumber = "1112223334", Qualification = "MD", Specialization = "ENT" };
            //Action
            int id = doctorServices.AddDoctor(doctor);
            //Asert
            Assert.That(id, Is.EqualTo(1));
        }

        [Test]
        public void AddDoctorDuplicateDoctorExceptionTest()
        {
            //Arrange
            Doctor doctor = new Doctor() { Age = 40, Experience = 10, LicenseNumber = "A123", Name = "JOHN", PhoneNumber = "1112223334", Qualification = "MD", Specialization = "ENT" };
            doctorServices.AddDoctor(doctor);
            //Action
            var exception = Assert.Throws<DuplicateDoctorException>(() => doctorServices.AddDoctor(doctor));
            //Asert
            Assert.That(exception.Message, Is.EqualTo("Doctor Already exists!"));
        }
    }
}
