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
    public class DoctorBLUpdateTest
    {
        public class Tests
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
            public void UpdateDoctorSuccessTest()
            {
                //Arrange
                Doctor doctor = doctorServices.GetDoctorById(1);
                doctor.Name = "Test";
                //Action
                var result = doctorServices.UpdateDoctorDetails(doctor);
                //Asert
                Assert.That(result.Name, Is.EqualTo(doctor.Name));
            }

            [Test]
            public void UpdateDoctorNotFoundExceptionTest()
            {
                //Arrange

                //Action
                var exception = Assert.Throws<DoctorNotFoundException>(() => doctorServices.GetDoctorById(2));
                //Asert
                Assert.That(exception.Message, Is.EqualTo("Doctor Not Found!"));
            }
        }
    }
}
