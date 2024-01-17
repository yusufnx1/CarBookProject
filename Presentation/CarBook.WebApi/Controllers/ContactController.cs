using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly GetContactByIdCommandHandler _getContactByIdQueryHandler;
        private readonly GetContactCommandHandler _getContactQueryHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;

        public ContactController(CreateContactCommandHandler createContactCommandHandler,
            GetContactByIdCommandHandler getContactByIdQueryHandler,
            GetContactCommandHandler getContactQueryHandler,
            UpdateContactCommandHandler updateContactCommandHandler,
            RemoveContactCommandHandler removeContactCommandHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactQueryHandler = getContactQueryHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _getContactQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var values = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand createContact)
        {
            await _createContactCommandHandler.Handle(createContact);
            return Ok("İletişim bilgisi eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("İletişim bilgisi silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand updateContact)
        {
            await _updateContactCommandHandler.Handle(updateContact);
            return Ok("İletişim bilgisi güncellendi.");
        }
    }
}
