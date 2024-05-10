

using DoctorClinicDALLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ModeClassDALLibrary
{
    public class DoctorRepository: BaseRepository<int, Doctor>
    {
        protected readonly DoctorClinicContext _context;

        public DoctorRepository(DoctorClinicContext context): base(context)
        {
            _context = context;
        }
        
    }
}
