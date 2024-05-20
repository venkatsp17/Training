﻿using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Contexts
{
    public class RequestTrackerContext:DbContext
    {
        public RequestTrackerContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Employee>  Employees { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Request> Requests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee() { Id = 101, Name = "Ramu", DateOfBirth = new DateTime(2000,2,12), Phone = "9876543321", Image = "" },
            //    new Employee() { Id = 102, Name = "Somu", DateOfBirth = new DateTime(2002,3,24), Phone = "9988776655", Image = "" }
            //    );

            modelBuilder.Entity<Request>()
       .HasOne(r => r.RaisedByEmployee)
       .WithMany(e => e.RequestsRaised)
       .HasForeignKey(r => r.RequestRaisedById)
       .IsRequired()
       .OnDelete(DeleteBehavior.Restrict); // Specify delete behavior as Restrict

            modelBuilder.Entity<Request>()
               .HasOne(r => r.RequestClosedByEmployee)
               .WithMany(e => e.RequestsClosed)
               .HasForeignKey(r => r.RequestClosedById)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict); // Specify delete behavior as Restrict

        }
    }
}
