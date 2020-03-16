using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassSchedule.Models
{
    public class CourseUpdateDto
    {
        public string CourseName { get; set; }
        public int  WeekDay { get; set; }
        public int Lesson { get; set; }
        public int BeginWeek { get; set; }
        public int EndWeek { get; set; }
        public string TeacherName { get; set; }
        public int SingleOrDouble { get; set; }
    }
}