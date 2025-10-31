using MediatR;
using PhoneBook.Domain.Entities;
using PhoneBook.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Application.Commands.CreateContact
{
    public class CreateContactHandler : IRequestHandler<CreateContactCommand, string>
    {
        private readonly IContactRepository _contactRepository;

        public CreateContactHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<string> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                BirthDate = request.BirthDate,
                Addresses = request.Addresses.Select(a => new Address
                {
                    Street = a.Street,
                    City = a.City,
                    State = a.State,
                    ZipCode = a.ZipCode,
                    Country = a.Country
                }).ToList()
            };

            await _contactRepository.CreateAsync(contact);
            return contact.Id;
        }
    }
}