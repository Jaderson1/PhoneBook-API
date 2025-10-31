using MediatR;
using PhoneBook.Application.DTOs;
using System.Collections.Generic;

namespace PhoneBook.Application.Queries.GetAllContacts
{
    public class GetAllContactsQuery : IRequest<List<ContactDto>>
    {
    }
}