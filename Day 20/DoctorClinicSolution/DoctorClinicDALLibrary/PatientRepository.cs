
using DoctorClinicDALLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeClassDALLibrary
{
    public class PatientRepository: BaseRepository<int, Patient>
    {
        protected readonly DoctorClinicContext _context;

        PatientRepository(DoctorClinicContext context) : base(context)
        {
            _context = context;
        }
    }
}
