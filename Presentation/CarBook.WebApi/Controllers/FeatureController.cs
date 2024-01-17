using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _mediator.Send(new GetFeatureQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            var values = await _mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand create)
        {
            await _mediator.Send(create);
            return Ok("Özellik Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            await _mediator.Send(new RemoveFeatureCommand(id));
            return Ok("Özellik silindi.");   
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand update)
        {
            await _mediator.Send(update);
            return Ok("Özellik Güncellendi");
        }
    }
}
