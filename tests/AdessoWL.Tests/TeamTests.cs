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
using System.Drawing;
using System.Threading.Tasks;

namespace AdessoWL.Tests
{
    /// <summary>
    /// This class contains all Team validations
    /// </summary>
    public class TeamTests
    {
        private Mock<ITeamRepository> MockTeamRepository;
        private CreateTeamValidator createValidator;
        private IMapper mapper;

        [SetUp]
        public void Setup()
        {
            MockTeamRepository = new Mock<ITeamRepository>();
            createValidator = new CreateTeamValidator();

            var mapperConfig = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new GeneralProfile());
            });

            mapper = mapperConfig.CreateMapper();
        }

        [Test]
        public async Task AddTeam_IfInvalidName_MustThrownErrorResult()
        {
            //Team instance without name property
            CreateTeamCommandRequest request = new CreateTeamCommandRequest 
            {

            };

            CreateTeamCommandHandler handler = new CreateTeamCommandHandler(
                MockTeamRepository.Object,
                createValidator,
                mapper);

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Team_Name_Length_Error, result.Message);
        }

        [Test]
        public async Task DeleteTeam_IfInvalidIdentifierNumber_MustThrownErrorResult()
        {
            //Delete request without identifier number property
            DeleteTeamCommandRequest request = new DeleteTeamCommandRequest { };

            DeleteTeamCommandHandler handler = new DeleteTeamCommandHandler(
                MockTeamRepository.Object,
                mapper,
                new DeleteTeamValidator());

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Id_Cannot_Be_Empty, result.Message);
        }

        [Test]
        public async Task UpdateTeam_IfInvalidIdentifierNumber_MustThrownErrorResult()
        {
            //Delete request without identifier number property
            UpdateTeamCommandRequest request = new UpdateTeamCommandRequest 
            {
                Name = "Test Team"
            };

            UpdateTeamCommandHandler handler = new UpdateTeamCommandHandler(
                MockTeamRepository.Object,
                mapper,
                new UpdateTeamValidator());

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Id_Cannot_Be_Empty, result.Message);
        }
    }
}