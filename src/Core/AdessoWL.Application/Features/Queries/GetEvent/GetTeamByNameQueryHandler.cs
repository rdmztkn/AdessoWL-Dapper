using AdessoWL.Application.Interfaces.Repositories;
using AdessoWL.Domain.Common.Result;
using AdessoWL.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AdessoWL.Application.Features.Queries.GetEvent
{
    public class GetTeamByNameQueryRequest : IRequest<IDataResult<List<Team>>>
    {
        public string Name { get; set; }
    }
    public class GetTeamByNameQueryHandler : IRequestHandler<GetTeamByNameQueryRequest, IDataResult<List<Team>>>
    {
        private readonly ITeamRepository teamRepository;
        public GetTeamByNameQueryHandler(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }
        public Task<IDataResult<List<Team>>> Handle(GetTeamByNameQueryRequest request, CancellationToken cancellationToken)
        {
            var result = teamRepository.GetTeamByName(request.Name);
            return Task.FromResult<IDataResult<List<Team>>>(new SuccessDataResult<List<Team>>(result));
        }
    }
}
