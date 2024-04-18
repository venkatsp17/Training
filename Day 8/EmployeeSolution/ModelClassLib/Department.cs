using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClassLib
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Department_Head { get; set; }
        public override bool Equals(object? obj)
        {
            return this.Id.Equals((obj as Department).Id);
        }
        public override string ToString()
        {
            return Id + " " + Name + " " + Department_Head;
        }
    }
}
