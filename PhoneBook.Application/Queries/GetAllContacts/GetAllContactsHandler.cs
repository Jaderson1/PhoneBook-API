using MediatR;
using PhoneBook.Application.DTOs;
using PhoneBook.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Application.Queries.GetAllContacts
{
    public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, List<ContactDto>>
    {
        private readonly IContactRepository _contactRepository;

        public GetAllContactsHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<List<ContactDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _contactRepository.GetAllAsync();
            
            return contacts.Select(c => new ContactDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                BirthDate = c.BirthDate,
                Addresses = c.Addresses.Select(a => new AddressDto
                {
                    Street = a.Street,
                    City = a.City,
                    State = a.State,
                    ZipCode = a.ZipCode,
                    Country = a.Country
                }).ToList()
            }).ToList();
        }
    }
}