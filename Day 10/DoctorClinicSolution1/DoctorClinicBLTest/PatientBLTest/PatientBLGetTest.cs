using DoctorClinicBLLibrary;
using DoctorClinicBLLibrary.DoctorExceptions;
using DoctorClinicBLLibrary.GeneralExceptions;
using DoctorClinicBLLibrary.PatientExceptions;
using ModeClassDALLibrary;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicBLTest.PatientBLTest
{
    public class PatientBLGetTest
    {
        IRepository<int, Patient> patientrepository;
        IPatientServices patientServices;
        [SetUp]

        public void Setup()
        {
            patientrepository = new PatientRepository();
            Patient patient = new Patient() { Name = "JOHN", PhoneNumber = "1112223334", Address = "TVL", DateOfBirth = Convert.ToDateTime("2002-09-01"), Gender = "Male" };
            patientrepository.Add(patient);
            patientServices = new PatientBL(patientrepository);
        }

        [Test]
        public void GetPatientByIDSuccessTest()
        {
            //Arrange

            //Action
            var result = patientServices.GetPatientById(1);
            //Asert
            Assert.That(result.PatientId, Is.EqualTo(1));
        }

        [Test]
        public void GetPatientByIDExceptionTest()
        {
            //Arrange

            //Action
            var exception = Assert.Throws<PatientNotFoundException>(() => patientServices.GetPatientById(2));
            //Asert
            Assert.That(exception.Message, Is.EqualTo("Patient Not Found!"));
        }
    }
}
