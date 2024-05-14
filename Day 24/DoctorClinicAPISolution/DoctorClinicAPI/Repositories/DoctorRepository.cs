using DoctorClinicAPI.Context;
using DoctorClinicAPI.Exceptions;
using DoctorClinicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorClinicAPI.Repositories
{
    public class DoctorRepository:IRepository<int,Doctor>
    {
        private readonly DoctorClinicContext _context;
        public DoctorRepository(DoctorClinicContext context)
        {
            _context = context;
        }
        public async Task<Doctor> Add(Doctor item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Doctor> Delete(int key)
        {
            var employee = await Get(key);
            if (employee != null)
            {
                _context.Remove(employee);
                await _context.SaveChangesAsync(true);
                return employee;
            }
            throw new NoDoctorFoundException();
        }

        public async Task<Doctor> Get(int key)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.DoctorID == key);
            return doctor;
        }

        public async Task<IEnumerable<Doctor>> Get()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors;

        }

        public async Task<Doctor> Update(Doctor item)
        {
            var employee = await Get(item.DoctorID);
            if (employee != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return employee;
            }
            throw new NoDoctorFoundException();
        }
    }
}
