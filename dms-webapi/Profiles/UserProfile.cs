using AutoMapper;

namespace dms_webapi.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<Models.UserRegistrationRequestDto, Entities.User>();
        CreateMap<Entities.User, Models.UserRegistrationResponseDto>();
    }
}