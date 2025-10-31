using MediatR;

namespace PhoneBook.Application.Commands.DeleteContact
{
    public class DeleteContactCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }
}