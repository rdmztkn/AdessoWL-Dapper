using AdessoWL.Application.Features.Commands.CreateEvent;
using AdessoWL.Application.Features.Commands.DeleteEvent;
using AdessoWL.Application.Features.Commands.UpdateEvent;
using AdessoWL.Application.Features.Queries.GetAllEvent;
using AdessoWL.Application.Features.Queries.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdessoWL.WebApi.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly IMediator mediator;
        public CountriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        /// <summary>
        /// Get all Countries
        /// </summary>
        /// <param name="request">Empty request body</param>
        /// <returns>List of Countries</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCountryQueryRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Get Country by Id
        /// </summary>
        /// <param name="request">Country identifier number</param>
        /// <returns>A Country</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet(":Id")]
        public async Task<IActionResult> Get([FromQuery] GetCountryQueryRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Add Country to System
        /// </summary>
        /// <param name="request">Country body</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCountryCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Delete Country from System
        /// </summary>
        /// <param name="request">Country identifier number</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteCountryCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Update Country in System
        /// </summary>
        /// <param name="request">Country features</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCountryCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
