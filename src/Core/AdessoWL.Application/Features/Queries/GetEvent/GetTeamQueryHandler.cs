using AdessoWL.Application.Interfaces.Repositories;
using AdessoWL.Domain.Common.Result;
using AdessoWL.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AdessoWL.Application.Features.Queries.GetEvent
{
    public class GetTeamQueryRequest : IRequest<IDataResult<Team>>
    {
        public int Id { get; set; }
    }

    public class GetTeamQueryHandler : IRequestHandler<GetTeamQueryRequest, IDataResult<Team>>
    {
        private readonly ITeamRepository teamRepository;
        public GetTeamQueryHandler(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }
        public Task<IDataResult<Team>> Handle(GetTeamQueryRequest request, CancellationToken cancellationToken)
        {
            var result = teamRepository.Get(request.Id);
            return Task.FromResult<IDataResult<Team>>(new SuccessDataResult<Team>(result));
        }
    }
}
