using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class RemoveFooterCommandHandler : IRequestHandler<RemoveFooterCommand>
    {
        private readonly IRepository<FooterAddress> _repo;

        public RemoveFooterCommandHandler(IRepository<FooterAddress> repo)
        {
            _repo = repo;
        }

        public async Task Handle(RemoveFooterCommand request, CancellationToken cancellationToken)
        {
            var values = await _repo.GetByIdAsync(request.Id);
            await _repo.RemoveAsync(values);
        }
    }
}
