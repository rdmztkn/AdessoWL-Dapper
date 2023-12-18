using AutoMapper;
using AdessoWL.Application.Interfaces.Repositories;
using AdessoWL.Application.Validations.Common;
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
    public class CreateCountryCommandRequest : IRequest<IResult>
    {
        public string Name { get; set; }
    }

    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommandRequest, IResult>
    {
        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;
        private readonly CreateCountryValidator validator;
        public CreateCountryCommandHandler(
            ICountryRepository countryRepository,
            CreateCountryValidator validator,
            IMapper mapper)
        {
            this.countryRepository = countryRepository;
            this.validator = validator;
            this.mapper = mapper;
        }
        public Task<IResult> Handle(CreateCountryCommandRequest request, CancellationToken cancellationToken)
        {
            var country = mapper.Map<Country>(request);
            var result = validator.Validate(country);
            if (result.Errors.Any())
                return Task.FromResult<IResult>(new ErrorResult(result.Errors.First().ErrorMessage));

            var countries = countryRepository.GetCountryByName(country.Name);

            if (countries.Any())
                return Task.FromResult<IResult>(new ErrorResult(ResultMessages.Country_Already_Added));

            countryRepository.Add(country);
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.Country_Added));
        }
    }
}
