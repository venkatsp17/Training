
using DoctorClinicDALLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeClassDALLibrary
{
    public class PatientRepository: IRepository<int, Patient>
    {
        readonly Dictionary<int, Patient> _patients;
        int GenerateId()
        {
            if (_patients.Count == 0)
                return 1;
            int id = _patients.Keys.Max();
            return ++id;
        }
        public Patient? Add(Patient item)
        {
            if (_patients.ContainsValue(item))
            {
                return null;
            }
            item.PatientId = GenerateId();
            _patients.Add(item.PatientId, item);
            return item;
        }

        public Patient? Delete(int key)
        {
            if (_patients.ContainsKey(key))
            {
                var department = _patients[key];
                _patients.Remove(key);
                return department;
            }
            return null;
        }

        public Patient? Get(int key)
        {
            return _patients.ContainsKey(key) ? _patients[key] : null;
        }

        public List<Patient>? GetAll()
        {
            if (_patients.Count == 0)
                return null;
            return _patients.Values.ToList();
        }

        public Patient? Update(Patient item)
        {
            if (_patients.ContainsKey(item.PatientId))
            {
                _patients[item.PatientId] = item;
                return item;
            }
            return null;
        }
    }
}
