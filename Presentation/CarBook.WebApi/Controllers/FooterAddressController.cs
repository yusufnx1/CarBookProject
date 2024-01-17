using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> FooterAddressList()
        {
            var values = await _mediator.Send(new GetFooterQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> FooterAddressGet(int id)
        {
            var values = await _mediator.Send(new GetFooterByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterCommand command)
        {
            await _mediator.Send(command);
            return Ok("Alt Adres Eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFooterAddress(int id)
        {
            await _mediator.Send(new RemoveFooterCommand(id));
            return Ok("Alt Bilgi Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddres(UpdateFooterCommand command)
        {
            await _mediator.Send(command);
            return Ok("Alt Bilgi Güncellendi.");
        }
    }
}
