using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;

        public AboutController(CreateAboutCommandHandler createAboutCommandHandler, 
            GetAboutByIdQueryHandler getAboutByIdQueryHandler, 
            GetAboutQueryHandler getAboutQueryHandler, 
            UpdateAboutCommandHandler updateAboutCommandHandler, 
            RemoveAboutCommandHandler removeAboutCommandHandler)
        {
            _createAboutCommandHandler = createAboutCommandHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _removeAboutCommandHandler = removeAboutCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _getAboutQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var values = await _getAboutByIdQueryHandler.Handler(new GetAboutByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand createAbout)
        {
            await _createAboutCommandHandler.Handle(createAbout);
            return Ok("Hakkımızda bilgisi eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("Hakkımda bilgisi silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand updateAbout)
        {
            await _updateAboutCommandHandler.Handle(updateAbout);
            return Ok("Hakkımda bilgisi güncellendi.");
        }
    }
}
