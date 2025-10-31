using MediatR;
using PhoneBook.Application.DTOs;
using PhoneBook.Domain.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Application.Queries.GetContactById
{
    public class GetContactByIdHandler : IRequestHandler<GetContactByIdQuery, ContactDto>
    {
        private readonly IContactRepository _contactRepository;

        public GetContactByIdHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ContactDto> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetByIdAsync(request.Id);
            
            if (contact == null)
                return null;
                
            return new ContactDto
            {
                Id = contact.Id,
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone,
                BirthDate = contact.BirthDate,
                Addresses = contact.Addresses.Select(a => new AddressDto
                {
                    Street = a.Street,
                    City = a.City,
                    State = a.State,
                    ZipCode = a.ZipCode,
                    Country = a.Country
                }).ToList()
            };
        }
    }
}