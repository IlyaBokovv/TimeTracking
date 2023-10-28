using AutoMapper;
using TimeTracking.Data.DTOs;
using TimeTracking.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TimeTracking.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(c => c.FullName,
                    opt => opt.MapFrom(x => string.Join(' ', x.LastName, x.FirstName, x.MiddleName)));

            CreateMap<Report, ReportDTO>();

            CreateMap<UserCreateAndUpdateDTO, UserDTO>();

            CreateMap<ReportCreateAndUpdateDTO, Report>();

            CreateMap<UserCreateAndUpdateDTO, User>();

        }
    }
}
