using AdessoWL.Application.Interfaces.Repositories;
using AdessoWL.Domain.Common.Result;
using AdessoWL.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AdessoWL.Application.Features.Queries.GetEvent
{
    public class GetCountryByNameQueryRequest : IRequest<IDataResult<List<Country>>>
    {
        public string Name { get; set; }
    }
    public class GetCountryByNameQueryHandler : IRequestHandler<GetCountryByNameQueryRequest, IDataResult<List<Country>>>
    {
        private readonly ICountryRepository countryRepository;
        public GetCountryByNameQueryHandler(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }
        public Task<IDataResult<List<Country>>> Handle(GetCountryByNameQueryRequest request, CancellationToken cancellationToken)
        {
            var result = countryRepository.GetCountryByName(request.Name);
            return Task.FromResult<IDataResult<List<Country>>>(new SuccessDataResult<List<Country>>(result));
        }
    }
}
