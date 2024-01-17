using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAddressResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterByIdQuery, GetFooterByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;
        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }
        public async Task<GetFooterByIdQueryResult> Handle(GetFooterByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetFooterByIdQueryResult
            {
                Address = value.Address,
                Description = value.Description,
                EMail = value.EMail,
                FooterAddressId = value.FooterAddressId,
                Phone = value.Phone
            };
        }
    }
}
