using AutoMapper;
using AdessoWL.Application.Interfaces.Repositories;
using AdessoWL.Application.Validations.Common;
using AdessoWL.Application.Validations.Update;
using AdessoWL.Domain.Common.Result;
using AdessoWL.Domain.Constants;
using AdessoWL.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdessoWL.Application.Features.Commands.UpdateEvent
{
    public class UpdateTeamCommandRequest : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommandRequest,IResult>
    {
        private readonly ITeamRepository teamRepository;
        private readonly UpdateTeamValidator validator;
        private readonly IMapper mapper;
        public UpdateTeamCommandHandler(ITeamRepository teamRepository, IMapper mapper, UpdateTeamValidator validator)
        {
            this.teamRepository = teamRepository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public Task<IResult> Handle(UpdateTeamCommandRequest request, CancellationToken cancellationToken)
        {
            var team = mapper.Map<Team>(request);
            var result = validator.Validate(team);
            if (result.Errors.Any())
                return Task.FromResult<IResult>(new ErrorResult(result.Errors.First().ErrorMessage));
            teamRepository.Update(team);
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.Team_Updated));
        }
    }
}
