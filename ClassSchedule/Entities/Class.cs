using System.IO;
using System;
using System.Collections.Generic;
using ClassSchedule.Models;

namespace ClassSchedule.Entities
{
    public class Class
    {
        public Guid ClassId { get; set; }
        public string ClassName { get; set; }
        public string Introduction { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}