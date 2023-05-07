using AutoMapper;
using LearningApp.Core.Classifiers;
using LearningApp.Models.DataTransferObjects;
using LearningApp.Models.Entities;

namespace LearningApp.Services.Mapping;

public class UsersMappingProfile : Profile
{
    public UsersMappingProfile()
    {
        CreateMap<User, UserDto>()
            .ForMember(x => x.Role, x => x.MapFrom(x => (RoleType)x.UserRoles.FirstOrDefault().RoleId));
        CreateMap<UserDto, User>();
        CreateMap<UserRegistrationDto, User>();
    }
}
