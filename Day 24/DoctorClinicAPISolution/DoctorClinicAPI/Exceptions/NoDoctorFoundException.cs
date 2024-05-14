namespace DoctorClinicAPI.Exceptions
{
    public class NoDoctorFoundException : Exception
    {
        string message;
        public NoDoctorFoundException() {
            message = "Doctor Not Found!";
        }
        public override string Message => message;
    }
}
