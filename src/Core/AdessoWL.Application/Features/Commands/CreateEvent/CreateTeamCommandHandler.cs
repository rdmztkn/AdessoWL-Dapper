using AutoMapper;
using AdessoWL.Application.Interfaces.Repositories;
using AdessoWL.Application.Validations.Create;
using AdessoWL.Domain.Common.Result;
using AdessoWL.Domain.Constants;
using AdessoWL.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdessoWL.Application.Features.Commands.CreateEvent
{
    public class CreateTeamCommandRequest : IRequest<IResult>
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }

    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommandRequest, IResult>
    {
        private readonly ITeamRepository teamRepository;
        private readonly IMapper mapper;
        private readonly CreateTeamValidator validator;
        public CreateTeamCommandHandler(
            ITeamRepository teamRepository,
            CreateTeamValidator validator,
            IMapper mapper)
        {
            this.teamRepository = teamRepository;
            this.validator = validator;
            this.mapper = mapper;
        }
        public Task<IResult> Handle(CreateTeamCommandRequest request, CancellationToken cancellationToken) 
        {
            Team team = mapper.Map<Team>(request);
            var result = validator.Validate(team);
            if (result.Errors.Any())
                return Task.FromResult<IResult>(new ErrorResult(result.Errors.First().ErrorMessage));

            var teams = teamRepository.GetTeamByName(team.Name);

            if (teams.Any())
                return Task.FromResult<IResult>(new ErrorResult(ResultMessages.Team_Already_Added));

            teamRepository.Add(team);
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.Team_Added));
        }
    }
}
