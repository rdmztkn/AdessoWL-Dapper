using AdessoWL.Application.Interfaces.Repositories;
using AdessoWL.Domain.Common.Result;
using AdessoWL.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AdessoWL.Application.Features.Queries.GetEvent
{
    public class GetTeamsByCountryIdQueryRequest : IRequest<IDataResult<List<Team>>>
    {
        public int Id { get; set; }
    }
    public class GetTeamByCountryQueryHandler : IRequestHandler<GetTeamsByCountryIdQueryRequest, IDataResult<List<Team>>>
    {
        private readonly ITeamRepository teamRepository;
        public GetTeamByCountryQueryHandler(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }
        public Task<IDataResult<List<Team>>> Handle(GetTeamsByCountryIdQueryRequest request, CancellationToken cancellationToken)
        {
            var result = teamRepository.GetTeamsByCountryId(request.Id);
            return Task.FromResult<IDataResult<List<Team>>>(new SuccessDataResult<List<Team>>(result));
        }
    }
}
