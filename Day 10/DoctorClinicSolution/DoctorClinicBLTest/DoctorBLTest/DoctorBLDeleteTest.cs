using DoctorClinicBLLibrary.DoctorExceptions;
using DoctorClinicBLLibrary;
using ModeClassDALLibrary;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicBLTest.DoctorBLTest
{
    public class DoctorBLDeleteTest
    {
        IRepository<int, Doctor> doctorrepository;
        IDoctorServices doctorServices;
        [SetUp]

        public void Setup()
        {
            doctorrepository = new DoctorRepository();
            Doctor doctor = new Doctor() { Age = 40, Experience = 10, LicenseNumber = "A123", Name = "JOHN", PhoneNumber = "1112223334", Qualification = "MD", Specialization = "ENT" };
            doctorrepository.Add(doctor);
            doctorServices = new DoctorBL(doctorrepository);
        }

        [Test]
        public void DeleteDoctorSuccessTest()
        {
            //Arrange

            //Action
            var result = doctorServices.DeleteDoctor(1);
            //Asert
            Assert.That(result.DoctorID, Is.EqualTo(1));
        }

        [Test]
        public void DeleteDoctorotFoundExceptionTest()
        {
            //Arrange
            doctorServices.DeleteDoctor(1);
            //Action
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorServices.DeleteDoctor(1));
            //Asert
            Assert.That(exception.Message, Is.EqualTo("Doctor Not Found!"));
        }
    }
}
