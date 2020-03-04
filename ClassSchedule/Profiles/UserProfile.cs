using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassSchedule.DtoParameters;
using ClassSchedule.Entities;
using ClassSchedule.Models;

namespace ClassSchedule.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<UserAddDto, User>();
        }
    }
}
