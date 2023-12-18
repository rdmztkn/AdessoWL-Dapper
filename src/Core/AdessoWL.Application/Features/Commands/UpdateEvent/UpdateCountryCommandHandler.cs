using AutoMapper;
using AdessoWL.Application.Interfaces.Repositories;
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
    public class UpdateCountryCommandRequest : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommandRequest, IResult>
    {
        private readonly ICountryRepository countryRepository;
        private readonly UpdateCountryValidator validator;
        private readonly IMapper mapper;
        public UpdateCountryCommandHandler(ICountryRepository countryRepository, IMapper mapper, UpdateCountryValidator validator)
        {
            this.countryRepository = countryRepository;
            this.mapper = mapper;
            this.validator = validator;
        }
        public Task<IResult> Handle(UpdateCountryCommandRequest request, CancellationToken cancellationToken)
        {
            var country = mapper.Map<Country>(request);
            var result = validator.Validate(country);
            if (result.Errors.Any())
                return Task.FromResult<IResult>(new ErrorResult(result.Errors.First().ErrorMessage));
            countryRepository.Update(country);
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.Country_Updated));
        }
    }
}
