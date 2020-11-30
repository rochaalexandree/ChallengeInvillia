using AutoMapper;
using ChallengeInvillia.API.Dtos;
using ChallengeInvillia.Domain;

namespace ChallengeInvillia.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Friend, FriendDto>().ReverseMap();
            CreateMap<Game, GameDto>().ReverseMap();
            CreateMap<GameRented, GameRentedDto>().ReverseMap();
        }
    }
}