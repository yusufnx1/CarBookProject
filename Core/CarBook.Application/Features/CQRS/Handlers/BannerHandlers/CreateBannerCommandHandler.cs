using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handler(CreateBannerCommand create)
        {
            await _repository.CreateAsync(new Banner
            {
                Description = create.Description,
                Title = create.Title,
                VideoDescription = create.VideoDescription,
                VideoUrl = create.VideoUrl,
            });
        }
    }
}
