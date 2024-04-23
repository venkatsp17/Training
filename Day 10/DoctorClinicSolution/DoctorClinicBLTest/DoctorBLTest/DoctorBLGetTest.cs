using DoctorClinicBLLibrary;
using DoctorClinicBLLibrary.DoctorExceptions;
using DoctorClinicBLLibrary.GeneralExceptions;
using ModeClassDALLibrary;
using ModelClassLibrary;

namespace DoctorClinicBLTest.DoctorBLTest
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
        public void GetDoctorByIDSuccessTest()
        {
            //Arrange

            //Action
            var result = doctorServices.GetDoctorById(1);
            //Asert
            Assert.That(result.DoctorID, Is.EqualTo(1));
        }

        [Test]
        public void GetDoctorByIDExceptionTest()
        {
            //Arrange

            //Action
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorServices.GetDoctorById(2));
            //Asert
            Assert.That(exception.Message, Is.EqualTo("Doctor Not Found!"));
        }

        [Test]
        public void GetDoctorBySpecializationSuccessTest()
        {
            //Arrange

            //Action
            var result = doctorServices.GetDoctorsBySpecialization("ENT");
            //Asert
            Assert.That(result[0].DoctorID, Is.EqualTo(1));
        }

        [Test]
        public void GetDoctorBySpecializationDoctorNotFoundExceptionTest()
        {
            //Arrange

            //Action
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorServices.GetDoctorsBySpecialization("CARDIO"));
            //Asert
            Assert.That(exception.Message, Is.EqualTo("Doctor Not Found!"));
        }

        [Test]
        public void GetDoctorBySpecializationNoDataAvailableExceptionTest()
        {
            //Arrange
            doctorServices.DeleteDoctor(1);
            //Action
            var exception = Assert.Throws<NoDataAvailableException>(() => doctorServices.GetDoctorsBySpecialization("CARDIO"));
            //Asert
            Assert.That(exception.Message, Is.EqualTo("No Data Available"));
        }
    }
}