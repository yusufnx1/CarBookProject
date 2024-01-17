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
    public class CreateFooterCommandHandler : IRequestHandler<CreateFooterCommand>
    {
        private readonly IRepository<FooterAddress> _repo;

        public CreateFooterCommandHandler(IRepository<FooterAddress> repo)
        {
            _repo = repo;
        }

        public async Task Handle(CreateFooterCommand request, CancellationToken cancellationToken)
        {
            await _repo.CreateAsync(new FooterAddress
            {
                Address = request.Address,
                Description = request.Description,
                EMail = request.EMail,
                Phone = request.Phone,
            });
        }
    }
}
