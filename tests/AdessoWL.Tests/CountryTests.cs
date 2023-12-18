using AutoMapper;
using AdessoWL.Application.Features.Commands.CreateEvent;
using AdessoWL.Application.Features.Commands.DeleteEvent;
using AdessoWL.Application.Features.Commands.UpdateEvent;
using AdessoWL.Application.Interfaces.Repositories;
using AdessoWL.Application.MappingConfiguration;
using AdessoWL.Application.Validations.Create;
using AdessoWL.Application.Validations.Delete;
using AdessoWL.Application.Validations.Update;
using AdessoWL.Domain.Common.Result;
using AdessoWL.Domain.Constants;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace AdessoWL.Tests
{
    public class CountryTests
    {
        private Mock<ICountryRepository> MockCountryRepository;
        private CreateCountryValidator createCountryValidator;
        private IMapper mapper;

        [SetUp]
        public void Setup()
        {
            MockCountryRepository = new Mock<ICountryRepository>();
            createCountryValidator = new CreateCountryValidator();

            var mapperConfig = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new GeneralProfile());
            });

            mapper = mapperConfig.CreateMapper();
        }

        [Test]
        public async Task AddCountry_IfInvalidName_MustThrownErrorResult()
        {
            //Country instance without name property
            CreateCountryCommandRequest request = new CreateCountryCommandRequest
            {

            };

            CreateCountryCommandHandler handler = new CreateCountryCommandHandler(
                MockCountryRepository.Object,
                createCountryValidator,
                mapper);

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Country_Name_Length_Error, result.Message);
        }

        [Test]
        public async Task DeleteCountry_IfInvalidIdentifierNumber_MustThrownErrorResult()
        {
            //Country instance without name property
            DeleteCountryCommandRequest request = new DeleteCountryCommandRequest { };

            DeleteCountryCommandHandler handler = new DeleteCountryCommandHandler(
                MockCountryRepository.Object,
                mapper,
                new DeleteCountryValidator());

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Id_Cannot_Be_Empty, result.Message);
        }

        [Test]
        public async Task UpdateCountry_IfInvalidIdentifierNumber_MustThrownErrorResult()
        {
            //Country instance without name property
            UpdateCountryCommandRequest request = new UpdateCountryCommandRequest { };

            UpdateCountryCommandHandler handler = new UpdateCountryCommandHandler(
                MockCountryRepository.Object,
                mapper,
                new UpdateCountryValidator());

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Id_Cannot_Be_Empty, result.Message);
        }
    }
}
