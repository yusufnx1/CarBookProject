using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBannerCommand update)
        {
            var values = await _repository.GetByIdAsync(update.BannerId);
            values.VideoUrl = update.VideoUrl;
            values.Title = update.Title;
            values.Description = update.Description;
            values.VideoDescription = update.VideoDescription;
            await _repository.UpdateAsync(values);
        }
    }
}
