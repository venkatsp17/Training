using System.ComponentModel.DataAnnotations;

namespace DoctorClinicAPI.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string Qualification { get; set; }
        public int Experience { get; set; }
        public int Age { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
}
