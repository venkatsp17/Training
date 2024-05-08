
using DoctorClinicDALLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeClassDALLibrary
{
    public class AppointmentRepository: IRepository<int, Appointment>
    {
        readonly Dictionary<int, Appointment> _appointments;
        int GenerateId()
        {
            if (_appointments.Count == 0)
                return 1;
            int id = _appointments.Keys.Max();
            return ++id;
        }
        public Appointment? Add(Appointment item)
        {
            if (_appointments.ContainsValue(item))
            {
                return null;
            }
            item.AppointmentId = GenerateId();
            _appointments.Add(item.AppointmentId, item);
            return item;
        }

        public Appointment? Delete(int key)
        {
            if (_appointments.ContainsKey(key))
            {
                var department = _appointments[key];
                _appointments.Remove(key);
                return department;
            }
            return null;
        }

        public Appointment? Get(int key)
        {
            return _appointments.ContainsKey(key) ? _appointments[key] : null;
        }

        public List<Appointment>? GetAll()
        {
            if (_appointments.Count == 0)
                return null;
            return _appointments.Values.ToList();
        }

        public Appointment? Update(Appointment item)
        {
            if (_appointments.ContainsKey(item.AppointmentId))
            {
                _appointments[item.AppointmentId] = item;
                return item;
            }
            return null;
        }
    }
}
