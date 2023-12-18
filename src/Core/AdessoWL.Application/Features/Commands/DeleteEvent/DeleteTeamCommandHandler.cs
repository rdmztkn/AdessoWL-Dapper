using AutoMapper;
using AdessoWL.Application.Interfaces.Repositories;
using AdessoWL.Application.Validations.Delete;
using AdessoWL.Domain.Common.Result;
using AdessoWL.Domain.Constants;
using AdessoWL.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdessoWL.Application.Features.Commands.DeleteEvent
{
    public class DeleteTeamCommandRequest : IRequest<IResult>
    {
        public int Id { get; set; }
    }

    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommandRequest, IResult>
    {
        private readonly ITeamRepository teamRepository;
        private readonly DeleteTeamValidator validator;
        private readonly IMapper mapper;
        public DeleteTeamCommandHandler(ITeamRepository teamRepository, IMapper mapper, DeleteTeamValidator validator)
        {
            this.teamRepository = teamRepository;
            this.mapper = mapper;
            this.validator = validator;
        }
        public Task<IResult> Handle(DeleteTeamCommandRequest request, CancellationToken cancellationToken)
        {
            Team team = mapper.Map<Team>(request);
            var result = validator.Validate(team);
            if (result.Errors.Any())
                return Task.FromResult<IResult>(new ErrorResult(result.Errors.First().ErrorMessage));
            teamRepository.Delete(team);
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.Team_Deleted));
        }
    }
}
