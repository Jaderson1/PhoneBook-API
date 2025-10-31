using MediatR;
using PhoneBook.Domain.Entities;
using PhoneBook.Domain.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Application.Commands.UpdateContact
{
    public class UpdateContactHandler : IRequestHandler<UpdateContactCommand, bool>
    {
        private readonly IContactRepository _contactRepository;

        public UpdateContactHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<bool> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact
            {
                Id = request.Id,
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

            return await _contactRepository.UpdateAsync(request.Id, contact);
        }
    }
}