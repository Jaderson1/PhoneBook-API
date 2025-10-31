using MediatR;
using PhoneBook.Application.DTOs;
using System;
using System.Collections.Generic;

namespace PhoneBook.Application.Commands.UpdateContact
{
    public class UpdateContactCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<AddressDto> Addresses { get; set; } = new List<AddressDto>();
    }
}