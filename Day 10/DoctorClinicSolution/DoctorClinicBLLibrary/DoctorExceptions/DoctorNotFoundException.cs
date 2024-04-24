using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicBLLibrary.DoctorExceptions
{
    public class DoctorNotFoundException: Exception
    {
        string message;
        public DoctorNotFoundException() {
            message = "Doctor Not Found!";
        }

        public override string Message => message;
    }
}
