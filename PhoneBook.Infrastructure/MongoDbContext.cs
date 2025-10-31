using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using System;
using System.Threading.Tasks;
using PhoneBook.Domain.Entities;

namespace PhoneBook.Infrastructure.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDb");
            
            // Configurar as opções do cliente MongoDB para o Atlas
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            
            var client = new MongoClient(settings);
            _database = client.GetDatabase(configuration["DatabaseName"]);
            
            // Verificar a conexão
            try
            {
                client.GetDatabase("admin").RunCommand<MongoDB.Bson.BsonDocument>(new MongoDB.Bson.BsonDocument("ping", 1));
                Console.WriteLine("Conexão com MongoDB Atlas estabelecida com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao MongoDB: {ex.Message}");
            }
        }

        public IMongoCollection<Contact> Contacts => _database.GetCollection<Contact>("Contacts");
        
        public IMongoDatabase Database => _database;
    }
}
