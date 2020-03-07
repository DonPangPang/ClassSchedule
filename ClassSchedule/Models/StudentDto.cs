using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassSchedule.Models 
{
    public class StudentDto 
    {
        public Guid StudentId { get; set; }
        public Guid ClassId { get; set; }

        public string StudentName { get; set; }
    }
}