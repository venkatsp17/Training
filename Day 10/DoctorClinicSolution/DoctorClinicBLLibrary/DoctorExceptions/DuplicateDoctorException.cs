using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicBLLibrary.DoctorExceptions
{
    public class DuplicateDoctorException : Exception
    {
        string message;

        public DuplicateDoctorException() {
            message = "Doctor Already exists!";
        }
        public override string Message => message;
    }
}
