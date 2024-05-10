
using DoctorClinicDALLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeClassDALLibrary
{
    public class AppointmentRepository : BaseRepository<int,Appointment>
    {
        protected readonly DoctorClinicContext _context;
       AppointmentRepository(DoctorClinicContext context) : base(context)
        {
            _context = context;
        }
    }
}
