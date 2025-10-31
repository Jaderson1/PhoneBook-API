using MediatR;
using PhoneBook.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Application.Commands.DeleteContact
{
    public class DeleteContactHandler : IRequestHandler<DeleteContactCommand, bool>
    {
        private readonly IContactRepository _contactRepository;

        public DeleteContactHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<bool> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            return await _contactRepository.RemoveAsync(request.Id);
        }
    }
}