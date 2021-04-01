## 🚀 Tecnologias

- ASP.NET Core 5.0

## ✋🏻 Pré-requisitos

- Banco de dados MySQL
- Entity Framework Core – EF Core

## 🔥 Instalação e execução

1. Faça um clone desse repositório;
2. Rode `dotnet tool install --global dotnet-ef` caso não tenha o EF Core instalado;
3. Rode `dotnet ef migrations add NomeMigration -p .\DocePecado.Persistence\ -s .\DocePecado.API\` para criar uma nova migration ou `dotnet ef database update -s .\DocePecado.API\` para criar o banco de dados com a migration já existente;
4. Execute o projeto.

## Dependencies

1. Microsoft.EntityFrameworkCore;
2. Microsoft.EntityFrameworkCore.Design;
3. Microsoft.EntityFrameworkCore.Tools;
4. Pomelo.EntityFrameworkCore.MySql;
5. Microsoft.AspNetCore.Mvc.NewtonsoftJson.