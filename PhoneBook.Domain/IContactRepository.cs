// PhoneBook.Domain/Interfaces/IContactRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBook.Domain.Entities; // Certifique-se de que este using está correto

namespace PhoneBook.Domain.Interfaces
{
    public interface IContactRepository
    {
        // Requisito: Listar todos
        Task<List<Contact>> GetAllAsync();
        
        // Requisito: Obter por ID
        Task<Contact> GetByIdAsync(string id);
        
        // Requisito: Criar um novo contato
        Task CreateAsync(Contact contact);
        
        // Requisito: Atualizar (retorna bool para indicar sucesso)
        Task<bool> UpdateAsync(string id, Contact contactIn);
        
        // Requisito: Remover (retorna bool para indicar sucesso)
        Task<bool> RemoveAsync(string id);
    }
}