using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;

        public BrandController(CreateBrandCommandHandler createBrandCommandHandler,
            GetBrandByIdQueryHandler getBrandByIdQueryHandler,
            GetBrandQueryHandler getBrandQueryHandler,
            UpdateBrandCommandHandler updateBrandCommandHandler,
            RemoveBrandCommandHandler removeBrandCommandHandler)
        {
            _createBrandCommandHandler = createBrandCommandHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _getBrandQueryHandler.Handler();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var values = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand createBrand)
        {
            await _createBrandCommandHandler.Handler(createBrand);
            return Ok("Marka bilgisi eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("Marka bilgisi silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand updateBrand)
        {
            await _updateBrandCommandHandler.Handler(updateBrand);
            return Ok("Marka bilgisi güncellendi.");
        }
    }
}
