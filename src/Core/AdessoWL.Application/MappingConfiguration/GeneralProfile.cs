using AutoMapper;
using AdessoWL.Application.Features.Commands.CreateEvent;
using AdessoWL.Application.Features.Commands.DeleteEvent;
using AdessoWL.Application.Features.Commands.UpdateEvent;
using AdessoWL.Application.Features.Queries.GetAllEvent;
using AdessoWL.Application.Features.Queries.GetEvent;
using AdessoWL.Domain.Entities;

namespace AdessoWL.Application.MappingConfiguration
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            //Commands
            CreateMap<Team, CreateTeamCommandRequest>().ReverseMap();
            CreateMap<Team, DeleteTeamCommandRequest>().ReverseMap();
            CreateMap<Team, UpdateTeamCommandRequest>().ReverseMap();
            CreateMap<Country, CreateCountryCommandRequest>().ReverseMap();
            CreateMap<Country, DeleteCountryCommandRequest>().ReverseMap();
            CreateMap<Country, UpdateCountryCommandRequest>().ReverseMap();

            //Queries
            CreateMap<Team, GetTeamQueryRequest>().ReverseMap();
            CreateMap<Team, GetAllTeamQueryRequest>().ReverseMap();
            CreateMap<Team, GetTeamsByCountryIdQueryRequest>().ReverseMap();
            CreateMap<Team, GetTeamByNameQueryRequest>().ReverseMap();
            CreateMap<Country, GetCountryByNameQueryRequest>().ReverseMap();
            CreateMap<Country, GetCountryQueryRequest>().ReverseMap();
            CreateMap<Country, GetAllCountryQueryRequest>().ReverseMap();
        }
    }
}
