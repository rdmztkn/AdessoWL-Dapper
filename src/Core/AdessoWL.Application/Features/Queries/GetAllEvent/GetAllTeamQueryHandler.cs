using AdessoWL.Application.Interfaces.Repositories;
using AdessoWL.Domain.Common.Result;
using AdessoWL.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AdessoWL.Application.Features.Queries.GetAllEvent
{
    public class GetAllTeamQueryRequest : IRequest<IDataResult<List<Team>>> { }
    public class GetAllTeamQueryHandler : IRequestHandler<GetAllTeamQueryRequest, IDataResult<List<Team>>>
    {
        private readonly ITeamRepository teamRepository;
        public GetAllTeamQueryHandler(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }
        public Task<IDataResult<List<Team>>> Handle(GetAllTeamQueryRequest request, CancellationToken cancellationToken)
        {
            var result = teamRepository.GetAll();
            return Task.FromResult<IDataResult<List<Team>>>(new SuccessDataResult<List<Team>>(result));
        }
    }
}
