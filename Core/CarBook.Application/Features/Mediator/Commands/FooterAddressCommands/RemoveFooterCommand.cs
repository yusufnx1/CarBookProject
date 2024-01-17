using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.FooterAddressCommands
{
    public class RemoveFooterCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveFooterCommand(int id)
        {
            Id = id;
        }
    }
}
