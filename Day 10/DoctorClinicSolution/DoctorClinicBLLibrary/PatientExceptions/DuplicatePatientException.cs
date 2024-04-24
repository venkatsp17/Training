using System.Runtime.Serialization;

namespace DoctorClinicBLLibrary.PatientExceptions
{
    public class DuplicatePatientException : Exception
    {
        string message;
        public DuplicatePatientException()
        {
            message = "Patient Already Exists!";
        }
        public override string Message => message;
    }
}