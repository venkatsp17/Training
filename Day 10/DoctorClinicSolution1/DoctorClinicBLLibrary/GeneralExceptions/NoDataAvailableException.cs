using System.Globalization;
using System.Runtime.Serialization;

namespace DoctorClinicBLLibrary.GeneralExceptions
{
    public class NoDataAvailableException : Exception
    {
        string message;
        public NoDataAvailableException()
        {
            message = "No Data Available";
        }
        public override string Message => message;
    }
}