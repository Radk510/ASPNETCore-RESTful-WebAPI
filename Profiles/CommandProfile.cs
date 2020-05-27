using AutoMapper;
using CommandWebApi.DTOs;
using CommandWebApi.Models;

namespace CommandWebApi.Profiles
{
    public class CommandProfile : Profile
    {
        public CommandProfile()
        {
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
        
    }
}