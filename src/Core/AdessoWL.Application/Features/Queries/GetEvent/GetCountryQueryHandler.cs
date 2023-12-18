using AdessoWL.Application.Interfaces.Repositories;
using AdessoWL.Domain.Common.Result;
using AdessoWL.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AdessoWL.Application.Features.Queries.GetEvent
{
    public class GetCountryQueryRequest : IRequest<IDataResult<Country>>
    {
        public int Id { get; set; }
    }

    public class GetCountryQueryHandler : IRequestHandler<GetCountryQueryRequest, IDataResult<Country>>
    {
        private readonly ICountryRepository countryRepository;
        public GetCountryQueryHandler(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }
        public Task<IDataResult<Country>> Handle(GetCountryQueryRequest request, CancellationToken cancellationToken)
        {
            //var result = countryRepository.Get(request.Id);
            var result = countryRepository.GetCountryWithTeamsById(request.Id);
            return Task.FromResult<IDataResult<Country>>(new SuccessDataResult<Country>(result));
        }
    }
}
