# 📚 BookHubAPI

Uma API REST desenvolvida em ASP.NET Core para gerenciamento de livros, autores e categorias.

O objetivo do projeto foi praticar conceitos fundamentais do desenvolvimento backend utilizando C#, Entity Framework Core e MySQL, aplicando uma arquitetura em camadas com Controllers, Services e DTOs.

---

## 🚀 Tecnologias

- C#
- ASP.NET Core Web API
- Entity Framework Core
- MySQL
- Swagger/OpenAPI

---

## 📁 Estrutura do Projeto

```
BookHubAPI
│
├── Controllers
├── DataBase
├── DTOs
│   ├── Autor
│   ├── Categoria
│   └── Livro
├── Models
├── Services
├── Program.cs
└── appsettings.json
```

---

## 📌 Funcionalidades

### Livros

- Listar todos os livros
- Buscar livro por ID
- Buscar livros por autor
- Buscar livros por categoria
- Buscar livros por título
- Cadastrar livro
- Atualizar livro
- Remover livro

### Autores

- Listar todos os autores
- Buscar autor por ID
- Cadastrar autor
- Atualizar autor
- Remover autor

### Categorias

- Listar todas as categorias
- Buscar categoria por ID
- Cadastrar categoria
- Atualizar categoria
- Remover categoria

---

## 🏗️ Arquitetura

O projeto foi organizado seguindo uma arquitetura em camadas:

- **Controllers** → Recebem as requisições HTTP.
- **Services** → Contêm as regras de negócio.
- **DTOs** → Responsáveis pela comunicação entre a API e o cliente.
- **Models** → Representam as entidades do banco de dados.
- **DataBase** → Contexto do Entity Framework.

---

## 📚 Conceitos praticados

- CRUD completo
- Relacionamentos 1:N
- Chaves primárias e estrangeiras
- Entity Framework Core
- LINQ
- DTOs
- Separação de responsabilidades
- Injeção de Dependência
- Consultas com filtros
- Mapeamento entre entidades e DTOs
- Tratamento básico de erros

---

## ▶️ Como executar

### Clone o repositório

```bash
git clone https://github.com/seu-usuario/BookHubAPI.git
```

### Entre na pasta

```bash
cd BookHubAPI
```

### Configure a conexão com o MySQL

Edite o arquivo:

```
appsettings.json
```

informando sua Connection String.

### Execute

```bash
dotnet restore

dotnet run
```

A documentação da API estará disponível pelo Swagger.

---

## 🎯 Objetivo

Este projeto foi desenvolvido com fins de estudo para consolidar conhecimentos em desenvolvimento de APIs REST utilizando ASP.NET Core e Entity Framework Core, servindo também como projeto de portfólio.

---

## 👨‍💻 Autor

Desenvolvido por **Wallace Falque**.
