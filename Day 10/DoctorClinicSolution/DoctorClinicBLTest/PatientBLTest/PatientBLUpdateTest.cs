using DoctorClinicBLLibrary;
using DoctorClinicBLLibrary.DoctorExceptions;
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
    public class PatientBLUpdateTest
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
        public void UpdatePatientSuccessTest()
        {
            //Arrange
            Patient patient = patientServices.GetPatientById(1);
            patient.Name = "Test";
            //Action
            var result = patientServices.UpdatePatient(patient);
            //Asert
            Assert.That(result.Name, Is.EqualTo(patient.Name));
        }

        [Test]
        public void UpdateDoctorExceptionTest()
        {
            //Arrange

            //Action
            var exception = Assert.Throws<PatientNotFoundException>(() => patientServices.GetPatientById(2));
            //Asert
            Assert.That(exception.Message, Is.EqualTo("Patient Not Found!"));
        }
    }
}
