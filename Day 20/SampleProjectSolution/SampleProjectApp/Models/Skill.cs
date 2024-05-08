using System;
using System.Collections.Generic;

namespace SampleProjectApp.Models
{
    public partial class Skill
    {
        public Skill()
        {
            EmployeeSkills = new HashSet<EmployeeSkill>();
        }

        public string? Skill1 { get; set; }
        public string? SkillDescription { get; set; }
        public int SkillId { get; set; }

        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
