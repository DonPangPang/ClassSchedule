using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassSchedule.Entities
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public Guid ClassId { get; set; }

        public string StudentName { get; set; }
        
        public ICollection<Course> Courses { get; set; }
        public Class Class { get; set; }
    }
}
