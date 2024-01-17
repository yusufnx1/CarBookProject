using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAddressResults;
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
    public class GetFooterQueryHandler : IRequestHandler<GetFooterQuery, List<GetFooterQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repo;

        public GetFooterQueryHandler(IRepository<FooterAddress> repo)
        {
            _repo = repo;
        }

        public async Task<List<GetFooterQueryResult>> Handle(GetFooterQuery request, CancellationToken cancellationToken)
        {
            var values = await _repo.GetAllAsync();
            return values.Select(x => new GetFooterQueryResult
            {
                Address = x.Address,
                Description = x.Description,
                EMail = x.EMail,
                FooterAddressId = x.FooterAddressId,
                Phone = x.Phone
            }).ToList();
        }
    }
}
