using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Commands.CreateContact;
using PhoneBook.Application.Commands.DeleteContact;
using PhoneBook.Application.Commands.UpdateContact;
using PhoneBook.Application.Queries.GetAllContacts;
using PhoneBook.Application.Queries.GetContactById;
using System.Threading.Tasks;

namespace PhoneBook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/contacts
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllContactsQuery());
            return Ok(result);
        }

        // GET: api/contacts/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _mediator.Send(new GetContactByIdQuery { Id = id });
            
            if (result == null)
                return NotFound();
                
            return Ok(result);
        }

        // POST: api/contacts
        [HttpPost]
        public async Task<IActionResult> Create(CreateContactCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        // PUT: api/contacts/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, UpdateContactCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            
            if (!result)
                return NotFound();
                
            return NoContent();
        }

        // DELETE: api/contacts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _mediator.Send(new DeleteContactCommand { Id = id });
            
            if (!result)
                return NotFound();
                
            return NoContent();
        }
    }
}