using MediatR;
using PhoneBook.Domain.Entities;
using System.Collections.Generic;

namespace PhoneBook.Application.Contacts.Queries
{
    // Esta Query não precisa de parâmetros, mas espera retornar uma lista de Contatos
    public class GetAllContactsQuery : IRequest<List<Contact>>
    {
        // Vazio: Apenas um marcador de que queremos todos os contatos
    }
}
