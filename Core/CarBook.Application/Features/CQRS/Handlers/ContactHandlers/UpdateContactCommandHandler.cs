using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateContactCommand update)
        {
            var value = await _repository.GetByIdAsync(update.ContactId);
            value.SendDate = update.SendDate;
            value.Subject = update.Subject;
            value.Email = update.Email;
            value.Message = update.Message;
            value.Name = update.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
