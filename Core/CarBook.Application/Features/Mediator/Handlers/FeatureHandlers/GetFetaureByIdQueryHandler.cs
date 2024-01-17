using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFetaureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<Feature> _repository;

        public GetFetaureByIdQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        async Task<GetFeatureByIdQueryResult> IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>.Handle(GetFeatureByIdQuery request,
            CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetFeatureByIdQueryResult
            {
                FeatureId = values.FeatureId,
                Name = values.Name
            };
        }
    }
}
