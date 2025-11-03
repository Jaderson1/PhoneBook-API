# Portfólio — Jaderson

Bem-vindo ao meu portfólio técnico. Aqui você encontra um resumo das minhas habilidades, projetos e instruções para executar alguns deles localmente.

## Sobre mim
- Desenvolvedor backend com foco em .NET e APIs REST.
- Experiência com MongoDB, arquitetura em camadas e boas práticas de código.

## Habilidades
- Linguagens: C#, .NET
- Banco de dados: MongoDB
- Padrões: CQRS, Repository, Validações
- Ferramentas: Git, GitHub, GitHub Desktop

## Projetos
- PhoneBook-API: API de agenda telefônica com CRUD de contatos.
  - Repositório: https://github.com/Jaderson1/PhoneBook-API
  - Tecnologias: .NET, MongoDB, MediatR, FluentValidation
  - Camadas: Application, Domain, Infrastructure, Api

## Como executar o PhoneBook-API
1. Pré-requisitos: .NET instalado e MongoDB acessível.
2. Clone o repositório: `git clone https://github.com/Jaderson1/PhoneBook-API`
3. Acesse a API: `cd PhoneBook-API/PhoneBook/PhoneBook.Api`
4. Configure a conexão do MongoDB sem expor credenciais usando user-secrets:
   - `dotnet user-secrets init`
   - `dotnet user-secrets set "ConnectionStrings:MongoDb" "<sua_string_de_conexão>"`
5. Rode a API: `dotnet run` e acesse `http://localhost:5218`.

## Contato
- Email: jadersongaray@gmail.com
