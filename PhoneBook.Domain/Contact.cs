// PhoneBook.Domain/Entities/Contact.cs
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace PhoneBook.Domain.Entities
{
    // Classe principal que representa a entidade Contato
    public class Contact
    {
        // Usa ObjectId para o MongoDB
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        // Dados principais (obrigatórios)
        [BsonRequired]
        public string Name { get; set; }
        
        [BsonRequired]
        public string Phone { get; set; }
        
        [BsonRequired]
        public string Email { get; set; }
        
        // Data de nascimento (opcional)
        public DateTime? BirthDate { get; set; }
        
        // Lista de endereços (obrigatório)
        [BsonRequired]
        public IEnumerable<Address> Addresses { get; set; } = new List<Address>();
    }
    
    // Classe para representar o endereço
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}