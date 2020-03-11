using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassSchedule.Entities;
using ClassSchedule.Models;

namespace ClassSchedule.Profiles 
{
    public class CourseProfile : Profile 
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>();
            
            CreateMap<CourseAddDto, Course>();

            CreateMap<CourseUpdateDto, Course>();

            CreateMap<Course, CourseUpdateDto>();
        }
    }
}