using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.CategoryResult;
using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery result)
        {
            var values = await _repository.GetByIdAsync(result.Id);
            return new GetContactByIdQueryResult
            {
                ContactId = values.ContactId,
                Email = values.Email,
                Subject = values.Subject,
                Message = values.Message,
                SendDate = values.SendDate,
                Name = values.Name,
            };
        }
    }
}
