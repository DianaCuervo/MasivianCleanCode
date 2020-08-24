using AutoMapper;
using RouletteApi.DTOs;
using RouletteApi.Models;

namespace RouletteApi.Profiles
{
    public class RoulettesProfile : Profile
    {
        public RoulettesProfile()
        {
            CreateMap<Roulette, RouletteReadDTO>();
            CreateMap<Roulette, RouletteCreateDTO>();
            CreateMap<RouletteUpdateDTO, Roulette>();
            CreateMap<Roulette, RouletteUpdateDTO>();
        }
    }
}