using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.FooterAddressCommands
{
    public class CreateFooterCommand : IRequest
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
    }
}
