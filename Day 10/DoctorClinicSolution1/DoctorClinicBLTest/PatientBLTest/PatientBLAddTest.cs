using DoctorClinicBLLibrary.DoctorExceptions;
using DoctorClinicBLLibrary;
using ModeClassDALLibrary;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorClinicBLLibrary.PatientExceptions;

namespace DoctorClinicBLTest.PatientBLTest
{
    public class PatientBLAddTest
    {
        IRepository<int, Patient> patientrepository;
        IPatientServices patientServices;
        [SetUp]

        public void Setup()
        {
            patientrepository = new PatientRepository();
            patientServices = new PatientBL(patientrepository);
        }

        [Test]
        public void AddPatientSuccessTest()
        {
            //Arrange
            Patient patient = new Patient() { Name = "JOHN", PhoneNumber = "1112223334", Address = "TVL", DateOfBirth = Convert.ToDateTime("2002-09-01"), Gender = "Male" };
            //Action
            int id = patientServices.AddPatient(patient);
            //Asert
            Assert.That(id, Is.EqualTo(1));
        }

        [Test]
        public void AddPatientDuplicateDoctorExceptionTest()
        {
            //Arrange
            Patient patient = new Patient() { Name = "JOHN", PhoneNumber = "1112223334", Address = "TVL", DateOfBirth = Convert.ToDateTime("2002-09-01"), Gender = "Male" };
            patientServices.AddPatient(patient);
            //Action
            var exception = Assert.Throws<DuplicatePatientException>(() => patientServices.AddPatient(patient));
            //Asert
            Assert.That(exception.Message, Is.EqualTo("Patient Already Exists!"));
        }
    }
}
