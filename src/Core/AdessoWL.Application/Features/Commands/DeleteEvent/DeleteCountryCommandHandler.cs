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
    public class DeleteCountryCommandRequest : IRequest<IResult>
    {
        public int Id { get; set; }
    }

    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommandRequest, IResult>
    {
        private readonly ICountryRepository countryRepository;
        private readonly DeleteCountryValidator validator;
        private readonly IMapper mapper;
        public DeleteCountryCommandHandler(ICountryRepository countryRepository, IMapper mapper, DeleteCountryValidator validator)
        {
            this.countryRepository = countryRepository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public Task<IResult> Handle(DeleteCountryCommandRequest request, CancellationToken cancellationToken)
        {
            Country country = mapper.Map<Country>(request);
            var result = validator.Validate(country);
            if (result.Errors.Any())
                return Task.FromResult<IResult>(new ErrorResult(result.Errors.First().ErrorMessage));
            countryRepository.Delete(country);
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.Country_Deleted));
        }
    }
}
