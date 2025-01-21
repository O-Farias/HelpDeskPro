# HelpDeskPro

HelpDeskPro é um sistema de gerenciamento de help desk desenvolvido em C# com o framework .NET. O objetivo deste projeto é fornecer um ambiente para gerenciar solicitações de suporte, usuários e equipes, promovendo eficiência e organização no atendimento ao cliente.

## Funcionalidades Principais

- **Gerenciamento de Tickets**: Criação, edição e exclusão de tickets de suporte.
- **Controle de Usuários**: Cadastro, atualização e remoção de usuários.
- **Autenticação**: Controle de acesso por autenticação de usuários.
- **Organização de Equipes**: Atribuição de tickets a técnicos ou equipes específicas.

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework**: .NET 8
- **Banco de Dados**: SQL Server e SQLite (opcional para testes)
- **ORM**: Entity Framework Core
- **Ferramentas de Teste**: xUnit, Moq

## Estrutura do Projeto

```
HelpDeskPro/
├── Controllers/
│   ├── TicketController.cs
│   ├── UserController.cs
├── Models/
│   ├── Ticket.cs
│   ├── User.cs
├── Repositories/
│   ├── IRepository.cs
│   ├── IUserRepository.cs
│   ├── ITicketRepository.cs
│   ├── UserRepository.cs
│   ├── TicketRepository.cs
├── Services/
│   ├── IUserService.cs
│   ├── ITicketService.cs
│   ├── UserService.cs
│   ├── TicketService.cs
├── Data/
│   ├── AppDbContext.cs
├── HelpDeskPro.csproj
├── HelpDeskPro.sln
└── README.md
```

## Configuração do Projeto

### Pré-requisitos

- [.NET SDK 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server ou SQLite configurado

### Passo a Passo

1. Clone o repositório:
   ```bash
   git clone https://github.com/O-Farias/HelpDeskPro.git
   cd HelpDeskPro
   ```

2. Restaure as dependências:
   ```bash
   dotnet restore
   ```

3. Configure a string de conexão no arquivo `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=HelpDeskPro;User Id=seu_usuario;Password=sua_senha;"
     }
   }
   ```

4. Execute as migrações para criar o banco de dados:
   ```bash
   dotnet ef database update
   ```

5. Inicie a aplicação:
   ```bash
   dotnet run
   ```

6. Acesse o sistema em `http://localhost:5000`.


## Contribuição

Contribuições são bem-vindas! Siga os passos abaixo:

1. Faça um fork do repositório.
2. Crie uma nova branch:
   ```bash
   git checkout -b minha-feature
   ```
3. Faça as alterações desejadas.
4. Commit suas mudanças:
   ```bash
   git commit -m "Minha feature incrível"
   ```
5. Envie para o seu fork:
   ```bash
   git push origin minha-feature
   ```
6. Abra um Pull Request.

## Licença

Este projeto está licenciado sob a licença MIT. Consulte o arquivo [LICENSE](LICENSE) para obter mais informações.


