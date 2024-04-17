using System.Data;
using System.Xml.Linq;

namespace ModelClassLibrary
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string Name { get; set;}
        public string Specialization { get; set;}
        public string Qualification { get; set; }
        public int Experience { get; set;}
        public int Age { get; set;}
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public Doctor()
        {
            DoctorID = 0;
            Name = string.Empty;
            Specialization = string.Empty;
            Qualification = string.Empty;
            Experience = 0;
            Age = 0;
            LicenseNumber = string.Empty;
            PhoneNumber = string.Empty;
        }

        public Doctor(int doctorID, string name, string specialization, string qualification, int experience, int age, string licenseNumber, string phoneNumber)
        {
            DoctorID = doctorID;
            Name = name;
            Specialization = specialization;
            Qualification = qualification;
            Experience = experience;
            Age = age;
            LicenseNumber = licenseNumber;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return "Doctor ID       : " + DoctorID
                + "\nDoctor Name    : " + Name
                + "\nSpecialization : " + Specialization
                + "\nQualification  : " + Qualification
                + "\nExperience     : " + Experience
                + "\nAge            : " + Age;
        }

        public static bool operator ==(Doctor a, Doctor b)
        {
            return a.DoctorID == b.DoctorID;

        }
        public static bool operator !=(Doctor a, Doctor b)
        {
            return a.DoctorID != b.DoctorID;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }
    }
}
