using System.Runtime.Serialization;

namespace DoctorClinicBLLibrary.AppointmentExceptions
{
    [Serializable]
    public class AppointmentNotFoundException : Exception
    {
        string message;
        public AppointmentNotFoundException()
        {
            message = "Appointment Not Found!";
        }

        public override string Message => message;
    }
}