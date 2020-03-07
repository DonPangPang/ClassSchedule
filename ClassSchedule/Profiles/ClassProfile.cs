using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassSchedule.Entities;
using ClassSchedule.Models;

namespace ClassSchedule.Profiles
{
    public class ClassProfile: Profile
    {
        public ClassProfile()
        {
            CreateMap<Class, ClassDto>();

            CreateMap<ClassAddDto, Class>();

            CreateMap<ClassUpdateDto, Class>();

            CreateMap<Class, ClassUpdateDto>();
        }
    }
}
