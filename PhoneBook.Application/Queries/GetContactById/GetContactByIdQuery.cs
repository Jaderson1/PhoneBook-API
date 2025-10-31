using MediatR;
using PhoneBook.Application.DTOs;

namespace PhoneBook.Application.Queries.GetContactById
{
    public class GetContactByIdQuery : IRequest<ContactDto>
    {
        public string Id { get; set; }
    }
}