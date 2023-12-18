using AdessoWL.Application.Features.Commands.CreateEvent;
using AdessoWL.Application.Features.Commands.DeleteEvent;
using AdessoWL.Application.Features.Commands.UpdateEvent;
using AdessoWL.Application.Features.Queries.GetAllEvent;
using AdessoWL.Application.Features.Queries.GetEvent;
using AdessoWL.Domain.Common.Result;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdessoWL.WebApi.Controllers
{
    [ApiController]
    [Route("api/teams")]
    public class TeamsController : ControllerBase
    {
        private readonly IMediator mediator;
        public TeamsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        /// <summary>
        /// Get all Teams
        /// </summary>
        /// <param name="request">Empty request body</param>
        /// <returns>List of Teams</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTeamQueryRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Get all Teams by Country Id
        /// </summary>
        /// <param name="request">Country identifier number</param>
        /// <returns>List of Teams</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[HttpGet("get-all-by-country-id")]
        [HttpGet(":CountryId")]
        public async Task<IActionResult> GetAllByCountry([FromQuery] GetTeamsByCountryIdQueryRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Get Team by Id
        /// </summary>
        /// <param name="request">Team identifier number</param>
        /// <returns>A Team</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet(":Id")]
        public async Task<IActionResult> Get([FromQuery] GetTeamQueryRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Add Team to System
        /// </summary>
        /// <param name="request">Team body</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTeamCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Delete Team from System
        /// </summary>
        /// <param name="request">Team identifier number</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteTeamCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Update Team in System
        /// </summary>
        /// <param name="request">Team features</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTeamCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
