using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;

        public CarController(CreateCarCommandHandler createCarCommandHandler,
            GetCarByIdQueryHandler getCarByIdQueryHandler,
            GetCarQueryHandler getCarQueryHandler,
            UpdateCarCommandHandler updateCarCommandHandler,
            RemoveCarCommandHandler removeCarCommandHandler,
            GetCarWithBrandQueryHandler getCarWithBrandQueryHandler)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHandler.Handler();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var values = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand createCar)
        {
            await _createCarCommandHandler.Handle(createCar);
            return Ok("Araba bilgisi eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Araba bilgisi silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand updateCar)
        {
            await _updateCarCommandHandler.Handle(updateCar);
            return Ok("Araba bilgisi güncellendi.");
        }
        [HttpGet("GetCarWithBrand")]
        public async Task<IActionResult> GetCarWithBrand()
        {
            var values = _getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }
    }
}
