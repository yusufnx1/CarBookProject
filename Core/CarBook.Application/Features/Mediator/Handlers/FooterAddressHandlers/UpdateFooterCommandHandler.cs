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
    public class UpdateFooterCommandHandler : IRequestHandler<UpdateFooterCommand>
    {
        private readonly IRepository<FooterAddress> _repo;

        public UpdateFooterCommandHandler(IRepository<FooterAddress> repo)
        {
            _repo = repo;
        }

        public async Task Handle(UpdateFooterCommand request, CancellationToken cancellationToken)
        {
            var values = await _repo.GetByIdAsync(request.FooterAddressId);
            values.Address = request.Address;
            values.Phone = request.Phone;
            values.Description = request.Description;
            values.EMail = request.EMail;
            await _repo.UpdateAsync(values);
        }
    }
}
