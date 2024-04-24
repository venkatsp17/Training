using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClassLibrary
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }

        int age;
        DateTime dob;
        public int Age { 
            get {
                return age;
            } 
        }
        public DateTime DateOfBirth { 
            get { return dob; } 
            
            set { 
                dob = value;
                age = ((DateTime.Today - dob).Days) / 365;
            } 
        }
        public string Gender { get; set; } 
        public string Address { get; set; } 
        public string PhoneNumber { get; set; }

        [ExcludeFromCodeCoverage]
        public Patient()
        {
            PatientId = 0;
            Name = string.Empty;
            DateOfBirth = DateTime.Now;
            Gender = "";
            Address = "";
            PhoneNumber = "";
        }

        public Patient(int patientId, string name, DateTime dateOfBirth, string gender, string address, string phoneNumber)
        {
            PatientId = patientId;
            Name = name;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            PhoneNumber = phoneNumber;
        }
        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return "Patient ID       : " + PatientId
                + "\nPatient Name    : " + Name
                + "\nAge             : " + Age
                + "\nGender          : " + Gender
                + "\nAddress         : " + Address
                + "\nPhone           : " + PhoneNumber;
        }

       // public static bool operator ==(Patient a, Patient b)
        //{
          //  return a.PatientId == b.PatientId;

        //}
        //public static bool operator !=(Patient a, Patient b)
        //{
          //  return a.PatientId != b.PatientId;
        //}

        //public override bool Equals(object obj)
        //{
          //  if (ReferenceEquals(this, obj))
            //{
              //  return true;
            //}

            //if (ReferenceEquals(obj, null))
            //{
              //  return false;
            //}

            //throw new NotImplementedException();
        //}
    }
}
