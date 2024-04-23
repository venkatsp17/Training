using System.Runtime.Serialization;

namespace DoctorClinicBLLibrary.PatientExceptions
{
    public class PatientNotFoundException : Exception
    {
        string message;
       
        public PatientNotFoundException()
        {
            message = "Patient Not Found!";
        }

        public override string Message => message;
    }
}