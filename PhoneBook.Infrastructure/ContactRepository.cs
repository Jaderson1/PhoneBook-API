using MongoDB.Driver;
using PhoneBook.Domain.Entities;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository 
    {
        private readonly IMongoCollection<Contact> _contacts;

        public ContactRepository(MongoDbContext context) 
        {
            _contacts = context.Contacts;
        }

        public async Task<List<Contact>> GetAllAsync() =>
            await _contacts.Find(_ => true).ToListAsync();

        public async Task<Contact> GetByIdAsync(string id) =>
            await _contacts.Find(contact => contact.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Contact contact) =>
            await _contacts.InsertOneAsync(contact);

        public async Task<bool> UpdateAsync(string id, Contact contactIn)
        {
            contactIn.Id = id; // Garantir que o ID está correto
            var result = await _contacts.ReplaceOneAsync(contact => contact.Id == id, contactIn);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var result = await _contacts.DeleteOneAsync(contact => contact.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}