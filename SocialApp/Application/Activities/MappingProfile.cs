using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Activity, ActivityDto>();
            CreateMap<UserActivity, AttendeeDto>()
                .ForMember(x => x.Username, o => o.MapFrom(s => s.AppUser.UserName))
                .ForMember(x => x.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName));

        }
    }
}
