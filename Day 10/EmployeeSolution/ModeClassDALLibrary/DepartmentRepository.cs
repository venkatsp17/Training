﻿using ModelClassLib;

namespace ModeClassDALLibrary
{
    public class DepartmentRepository: IRepository<int, Department>
    {
        readonly Dictionary<int, Department> _departments;
        public DepartmentRepository()
        {
            _departments = new Dictionary<int, Department>();
        }
        int GenerateId()
        {
            if (_departments.Count == 0)
                return 1;
            int id = _departments.Keys.Max();
            return ++id;
        }
        public Department Add(Department item)
        {
            if (_departments.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();
            _departments.Add(item.Id, item);
            return item;
        }

        public Department? Delete(int key)
        {
            if (_departments.ContainsKey(key))
            {
                var department = _departments[key];
                _departments.Remove(key);
                return department;
            }
            return null;
        }

        public Department? Get(int key)
        {
            return _departments.ContainsKey(key) ? _departments[key] : null;
        }

        public List<Department>? GetAll()
        {
            if (_departments.Count == 0)
                return null;
            return _departments.Values.ToList();
        }

        public Department? Update(Department item)
        {
            if (_departments.ContainsKey(item.Id))
            {
                _departments[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
