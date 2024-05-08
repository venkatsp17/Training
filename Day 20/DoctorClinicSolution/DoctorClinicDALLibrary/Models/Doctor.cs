using System;
using System.Collections.Generic;

namespace DoctorClinicDALLibrary.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int DoctorId { get; set; }
        public string? Name { get; set; }
        public string? Specialization { get; set; }
        public string? Qualification { get; set; }
        public int? Experience { get; set; }
        public int? Age { get; set; }
        public string? LicenseNumber { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
