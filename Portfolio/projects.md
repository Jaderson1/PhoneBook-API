# Projetos

## PhoneBook-API
- Descrição: API REST para gerenciar contatos (CRUD completo), organizada em camadas (Application, Domain, Infrastructure, Api).
- Principais tecnologias: .NET, MongoDB, MediatR, FluentValidation.
- Repositório: https://github.com/Jaderson1/PhoneBook-API

### Endpoints principais
- `GET /api/contacts` — Lista todos os contatos.
- `GET /api/contacts/{id}` — Busca contato por ID.
- `POST /api/contacts` — Cria novo contato.
- `PUT /api/contacts/{id}` — Atualiza contato.
- `DELETE /api/contacts/{id}` — Exclui contato.

### Como executar
1. `git clone https://github.com/Jaderson1/PhoneBook-API`
2. `cd PhoneBook-API/PhoneBook/PhoneBook.Api`
3. Configure `ConnectionStrings:MongoDb` via `dotnet user-secrets` (sem expor credenciais).
4. `dotnet run` e acesse `http://localhost:5218`.

### Observações
- Evitar credenciais em `appsettings.json`; preferir variáveis de ambiente ou `user-secrets`.
- Validações de entrada por FluentValidation; handlers e comandos por MediatR.