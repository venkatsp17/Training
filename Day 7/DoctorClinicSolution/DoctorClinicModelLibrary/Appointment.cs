using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClassLibrary
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }

        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }

        public Appointment()
        {
            AppointmentId = 0;
            AppointmentDateTime = DateTime.Now;
            Duration = TimeSpan.MinValue;
            Reason = "";
            Status = "";
            Notes = "";
            Doctor = null;
            Patient = null;
        }

        public Appointment(int appointmentId, DateTime appointmentDateTime, TimeSpan duration, string reason, string status, string notes, Doctor doctor, Patient patient)
        {
            AppointmentId = appointmentId;
            AppointmentDateTime = appointmentDateTime;
            Duration = duration;
            Reason = reason;
            Status = status;
            Notes = notes;
            Doctor = doctor;
            Patient = patient;
        }

        public static bool operator ==(Appointment a, Appointment b)
        {
            return a.AppointmentId == b.AppointmentId;

        }
        public static bool operator !=(Appointment a, Appointment b)
        {
            return a.AppointmentId != b.AppointmentId;
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
