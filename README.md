# TarefaCRUD - Contexto de Banco de Dados (.NET EF Core)

Este repositório contém o `DbContext` e as entidades de modelo para uma aplicação de Gerenciamento de Tarefas (CRUD) desenvolvida com .NET e Entity Framework Core. Ele define a estrutura do banco de dados para armazenar informações sobre Pessoas e suas Tarefas associadas.

## Sobre o Projeto

O `TarefaDBContext` é o núcleo da camada de persistência de dados para um sistema de gerenciamento de tarefas. Ele utiliza o Entity Framework Core para facilitar as operações de banco de dados, abstraindo o acesso direto ao SQL. O modelo inclui:

* **Pessoa:** Representa um usuário ou responsável, com nome e e-mail.
* **Tarefa:** Representa uma tarefa a ser realizada, com descrição, datas, prioridade e associação a uma Pessoa.

Este projeto é ideal para servir como base para uma API RESTful ou uma aplicação MVC que necessite gerenciar tarefas.

## Entidades e Relacionamentos

* **`Pessoa`**:
    * `IdPessoa` (Chave Primária)
    * `NomePessoa` (string, max 100)
    * `Email` (string, max 50, único)
* **`Tarefa`**:
    * `IdTarefa` (Chave Primária)
    * `Descricao` (string, max 250, obrigatório)
    * `DataInicio` (date, obrigatório)
    * `Prazo` (date, obrigatório)
    * `IdPessoa` (Chave Estrangeira para `Pessoa`)
    * `Prioridade` (enum: Baixa, Media, Alta - armazenada como string)
    * Relacionamento: Uma `Tarefa` está associada a uma `Pessoa`. Uma `Pessoa` pode ter múltiplas `Tarefas`.

## Tecnologias Utilizadas

* **C#** (com .NET Core / .NET 5+)
* **Entity Framework Core**: Para mapeamento objeto-relacional (ORM) e interação com o banco de dados.

## Como Usar (Em uma Aplicação .NET)

1.  **Integração:**
    * Adicione este projeto (ou os arquivos de modelo e DbContext) à sua solução .NET.
    * Certifique-se de ter os pacotes NuGet necessários do Entity Framework Core instalados (ex: `Microsoft.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.SqlServer`, `Microsoft.EntityFrameworkCore.Tools`).

2.  **Configuração do DbContext:**
    * No arquivo `Startup.cs` (ou `Program.cs` em .NET 6+) da sua aplicação principal, configure o serviço do DbContext, por exemplo:
      ```csharp
      services.AddDbContext<TarefaDBContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("SuaConnectionString")));
      ```
    * Defina a `SuaConnectionString` no seu arquivo `appsettings.json`.

3.  **Migrations:**
    * Utilize o Package Manager Console ou a CLI do .NET para criar e aplicar as migrações:
      ```bash
      dotnet ef migrations add InitialCreate
      dotnet ef database update
      ```

## Licença

Este projeto é licenciado sob a **GNU Affero General Public License v3.0**.
