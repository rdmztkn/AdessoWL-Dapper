using AdessoWL.Application.Interfaces.Repositories;
using AdessoWL.Domain.Common.Result;
using AdessoWL.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AdessoWL.Application.Features.Queries.GetAllEvent
{
    public class GetAllCountryQueryRequest : IRequest<IDataResult<List<Country>>> { }
    public class GetAllCountryQueryHandler : IRequestHandler<GetAllCountryQueryRequest, IDataResult<List<Country>>>
    {
        private readonly ICountryRepository countryRepository;
        public GetAllCountryQueryHandler(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }
        public Task<IDataResult<List<Country>>> Handle(GetAllCountryQueryRequest request, CancellationToken cancellationToken)
        {
            var result = countryRepository.GetAll();
            return Task.FromResult<IDataResult<List<Country>>>(new SuccessDataResult<List<Country>>(result));
        }
    }
    
}
