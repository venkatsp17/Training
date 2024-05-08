using System;
using System.Collections.Generic;

namespace DoctorClinicDALLibrary.Models
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime? AppointmentDateTime { get; set; }
        public TimeSpan? Duration { get; set; }
        public string? Reason { get; set; }
        public string? Status { get; set; }
        public string? Notes { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
