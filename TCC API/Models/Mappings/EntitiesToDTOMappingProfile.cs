using AutoMapper;
using TCC_API.Models.DTOs;
using TCC_API.Models.Entities;

namespace TCC_API.Models.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<User, UserDetailedDTO>().ReverseMap();
            CreateMap<Parking, ParkingDetailedDTO>().ReverseMap();
        }
    }
}
