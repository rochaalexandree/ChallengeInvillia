using AutoMapper;
using ChallengeInvillia.API.Dtos;
using ChallengeInvillia.Domain;
using ChallengeInvillia.Domain.Identity;

namespace ChallengeInvillia.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Friend, FriendDto>().ReverseMap();
            CreateMap<Game, GameDto>().ReverseMap();
            CreateMap<GameRented, GameRentedDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}