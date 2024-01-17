using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;

        public BannerController(GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler, CreateBannerCommandHandler createBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler)
        {
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
            _createBannerCommandHandler = createBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _getBannerQueryHandler.Handler();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var values = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand createBanner)
        {
            await _createBannerCommandHandler.Handler(createBanner);
            return Ok("Banner Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Banner Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand updateBanner)
        {
            await _updateBannerCommandHandler.Handle(updateBanner);
            return Ok("Banner Güncellendi");
        }
    }
}
