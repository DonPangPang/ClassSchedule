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

            CreateMap<UserUpdateDto, User>()
                .ForMember(dest => dest.Password,
                    opt => opt.MapFrom(src => src.NewPassword));

            CreateMap<User, UserUpdateDto>()
                .ForMember(dest => dest.OldPassword,
                    opt => opt.MapFrom(src => src.Password));
        }
    }
}
