using DoctorClinicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorClinicAPI.Context
{
    public class DoctorClinicContext : DbContext
    {
        public DoctorClinicContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Doctor> Doctors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
               new Doctor() {DoctorID = 1, Age=45, Experience=12, LicenseNumber="ABC123", Name="John", PhoneNumber="3322445566", Qualification="MD", Specialization="ORTHO"},
               new Doctor() { DoctorID = 2, Age = 40, Experience = 7, LicenseNumber = "DEF456", Name = "WicK", PhoneNumber = "1234567890", Qualification = "MBBS", Specialization = "" }
               );
        }
    }
}
