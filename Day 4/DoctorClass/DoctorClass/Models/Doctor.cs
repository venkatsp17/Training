using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClass.Models
{
    class Doctor
    {
        int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Qualification { get; set; }
        public string Specialization { get; set; }

        /// <summary>
        /// Constructor for Intialization of Object
        /// </summary>
        /// <param name="id">Id for Doctor as (int)</param>
        public Doctor(int id) => Id = id;

        /// <summary>
        /// Function that prints all Details of particular Doctor
        /// </summary>
        public void PrintDetails()
        {
            Console.WriteLine($"Doctor Id\t:\t {Id}");
            Console.WriteLine($"Doctor Name\t:\t {Name}");
            Console.WriteLine($"Doctor Age\t:\t {Age}");
            Console.WriteLine($"Doctor Experience\t:\t {Experience}");
            Console.WriteLine($"Doctor Qualification\t:\t {Qualification}");
            Console.WriteLine($"Doctor Specialization\t:\t {Specialization}");
        }
    }
}
