using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassSchedule.Entities;
using ClassSchedule.Models;

namespace ClassSchedule.Profiles 
{
    public class StudentProfile : Profile 
    {
        public StudentProfile () 
        {
            CreateMap<Student, StudentDto> ();
        }
    }
}