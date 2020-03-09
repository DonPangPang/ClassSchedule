using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassSchedule.Entities;

namespace ClassSchedule.Models
{
    public class CourseDto
    {
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }

        public string CourseName { get; set; }
        public WeekDay WeekDay { get; set; }
        public Lesson Lesson { get; set; }
        public int BeginWeek { get; set; }
        public int EndWeek { get; set; }
        public string TeacherName { get; set; }
        public SingleOrDouble SingleOrDouble { get; set; }
    }
}