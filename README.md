# API de Lista Telefônica

API REST para gerenciamento de uma lista telefônica, desenvolvida com ASP.NET Core e MongoDB.

## Tecnologias Utilizadas

- ASP.NET Core 6.0
- MongoDB
- MediatR (para implementação do padrão CQRS)
- FluentValidation (para validações)
- Swagger (para documentação da API)

## Estrutura do Projeto

O projeto segue os princípios da Clean Architecture:

- **PhoneBook.Domain**: Contém as entidades e interfaces de repositório
- **PhoneBook.Application**: Contém os casos de uso (Commands/Queries) e validações
- **PhoneBook.Infrastructure**: Implementação do repositório e acesso ao MongoDB
- **PhoneBook.Api**: Controllers e configuração da API

## Funcionalidades

- Criar contatos
- Listar todos os contatos
- Buscar contato por ID
- Atualizar contato
- Excluir contato

## Pré-requisitos

- .NET 6.0 SDK
- MongoDB (local, Docker ou MongoDB Atlas)

## Configuração

1. Clone o repositório
2. Configure a string de conexão do MongoDB no arquivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "MongoDb": "mongodb://localhost:27017"
  },
  "DatabaseName": "PhoneBookDb",
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## Executando o Projeto

1. Navegue até a pasta do projeto API:

```
cd PhoneBook/PhoneBook.Api
```

2. Execute o projeto:

```
dotnet run
```

3. Acesse a documentação Swagger:

```
https://localhost:7001/swagger
```

## Endpoints da API

- **GET /api/contacts**: Lista todos os contatos
- **GET /api/contacts/{id}**: Busca um contato pelo ID
- **POST /api/contacts**: Cria um novo contato
- **PUT /api/contacts/{id}**: Atualiza um contato existente
- **DELETE /api/contacts/{id}**: Remove um contato

## Modelo de Dados

### Contato

```json
{
  "id": "string",
  "name": "string",
  "phone": "string",
  "email": "string",
  "birthDate": "2023-05-20T00:00:00Z",
  "addresses": [
    {
      "street": "string",
      "city": "string",
      "state": "string",
      "zipCode": "string",
      "country": "string"
    }
  ]
}
```

## Implementação do MediatR

O projeto utiliza o padrão CQRS através do MediatR:

- **Commands**: Responsáveis por operações que modificam dados (Create, Update, Delete)
- **Queries**: Responsáveis por operações de leitura (Get, GetAll)
- **Handlers**: Processam os Commands e Queries

## Validações

As validações são implementadas com FluentValidation:

- Nome, telefone e email são obrigatórios
- Email deve ser um endereço válido
- Telefone deve seguir um formato específico
- Pelo menos um endereço é obrigatório