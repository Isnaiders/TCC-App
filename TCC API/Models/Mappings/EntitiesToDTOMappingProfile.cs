using AutoMapper;
using TCC_API.Models.DTOs.Authentication;
using TCC_API.Models.DTOs.Parking;
using TCC_API.Models.DTOs.User;
using TCC_API.Models.Entities.Authentication;
using TCC_API.Models.Entities.Parking;
using TCC_API.Models.Entities.User;

namespace TCC_API.Models.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Authentication, AuthenticationDetailedDTO>().ReverseMap();
            CreateMap<User, UserDetailedDTO>().ReverseMap();
            CreateMap<Parking, ParkingDetailedDTO>().ReverseMap();
        }
    }
}
