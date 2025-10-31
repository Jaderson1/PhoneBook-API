using System;
using System.Collections.Generic;

namespace PhoneBook.Application.DTOs
{
    public class ContactDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<AddressDto> Addresses { get; set; } = new List<AddressDto>();
    }

    public class AddressDto
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}