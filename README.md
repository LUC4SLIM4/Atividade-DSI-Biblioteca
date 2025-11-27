# Sistema de Biblioteca - Clean Architecture & DDD

Sistema de gerenciamento de biblioteca desenvolvido com ASP.NET Core seguindo os princípios de Clean Architecture e Domain-Driven Design (DDD).

## 📋 Descrição do Projeto

Este projeto foi desenvolvido como trabalho final da disciplina de Desenvolvimento de Sistemas de Informação Avançados I, implementando um sistema CRUD completo para gestão de autores e livros, com relacionamento 1:N.

## 🏗️ Arquitetura

O projeto está organizado em 4 camadas seguindo Clean Architecture:

### 1. **BibliotecaApp.Domain** (Camada de Domínio)
- Entidades: `Autor` e `Livro`
- Interfaces de repositórios
- Regras de negócio centrais

### 2. **BibliotecaApp.Application** (Camada de Aplicação)
- ViewModels: `AutorViewModel` e `LivroViewModel`
- Serviços de aplicação
- **Validações personalizadas:**
  - `DataNascimentoValidaAttribute`: Valida se o autor tem pelo menos 18 anos
  - `ISBNValidoAttribute`: Valida o formato ISBN-10 ou ISBN-13 com verificação de checksum
- Mapeamento com Mapster

### 3. **BibliotecaApp.Infrastructure** (Camada de Infraestrutura)
- Entity Framework Core
- SQL Server
- Repositórios concretos
- Configurações de entidades
- DbContext Factory
- Migrations

### 4. **BibliotecaApp.Web** (Camada de Apresentação)
- Controllers MVC
- Views Razor
- Interface responsiva com Bootstrap 5
- Busca dinâmica com AJAX

## ✨ Funcionalidades Implementadas

### ✅ Requisitos Obrigatórios Atendidos

1. **Clean Architecture com 4 camadas** ✔️
   - Domínio, Aplicação, Infraestrutura e Apresentação

2. **Relacionamento 1:N** ✔️
   - Um Autor pode ter vários Livros
   - Chave estrangeira explícita (`AutorId`) configurada no EF Core

3. **Mapeamento com Mapster** ✔️
   - Conversão entre Entidades e ViewModels

4. **Entity Framework Core com SQL Server** ✔️
   - Migrations implementadas
   - LocalDB configurado

5. **CRUD Completo** ✔️
   - Criar, Listar, Editar e Excluir para Autores e Livros

6. **Validações Personalizadas** ✔️
   - **Custom Validation 1:** `DataNascimentoValidaAttribute` - Verifica idade mínima de 18 anos
   - **Custom Validation 2:** `ISBNValidoAttribute` - Valida formato e checksum de ISBN-10/13
   - Data Annotations em todos os campos

7. **Busca Dinâmica com AJAX** ✔️
   - Busca em tempo real sem reload da página
   - Implementada para Autores e Livros
   - Debounce de 300ms para otimização

8. **Injeção de Dependências (DI/IoC)** ✔️
   - Todos os serviços e repositórios registrados
   - Inversão de controle aplicada

9. **Organização e Boas Práticas** ✔️
   - Código limpo e bem estruturado
   - Separação clara de responsabilidades
   - Nomenclatura consistente

## 🛠️ Tecnologias Utilizadas

- **.NET 8.0**
- **ASP.NET Core MVC**
- **Entity Framework Core 8.0**
- **SQL Server (LocalDB)**
- **Mapster** (mapeamento objeto-objeto)
- **Bootstrap 5** (interface responsiva)
- **jQuery** (AJAX)
- **Bootstrap Icons**

## 📦 Estrutura do Projeto

```
BibliotecaApp/
├── src/
│   ├── BibliotecaApp.Domain/
│   │   ├── Entities/
│   │   │   ├── Autor.cs
│   │   │   └── Livro.cs
│   │   └── Interfaces/
│   │       ├── IAutorRepository.cs
│   │       └── ILivroRepository.cs
│   ├── BibliotecaApp.Application/
│   │   ├── ViewModels/
│   │   │   ├── AutorViewModel.cs
│   │   │   └── LivroViewModel.cs
│   │   ├── Interfaces/
│   │   │   ├── IAutorService.cs
│   │   │   └── ILivroService.cs
│   │   ├── Services/
│   │   │   ├── AutorService.cs
│   │   │   └── LivroService.cs
│   │   └── Validations/
│   │       ├── DataNascimentoValidaAttribute.cs
│   │       └── ISBNValidoAttribute.cs
│   ├── BibliotecaApp.Infrastructure/
│   │   ├── Data/
│   │   │   ├── BibliotecaDbContext.cs
│   │   │   └── Configurations/
│   │   │       ├── AutorConfiguration.cs
│   │   │       └── LivroConfiguration.cs
│   │   ├── Repositories/
│   │   │   ├── AutorRepository.cs
│   │   │   └── LivroRepository.cs
│   │   └── Factories/
│   │       └── BibliotecaDbContextFactory.cs
│   └── BibliotecaApp.Web/
│       ├── Controllers/
│       │   ├── HomeController.cs
│       │   ├── AutoresController.cs
│       │   └── LivrosController.cs
│       ├── Views/
│       │   ├── Home/
│       │   ├── Autores/
│       │   ├── Livros/
│       │   └── Shared/
│       ├── wwwroot/
│       │   ├── css/
│       │   └── js/
│       └── Program.cs
└── BibliotecaApp.sln
```

## 🚀 Como Executar o Projeto

### Pré-requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [SQL Server LocalDB](https://learn.microsoft.com/sql/database-engine/configure-windows/sql-server-express-localdb) ou SQL Server
- Visual Studio 2022 / Visual Studio Code / Rider

### Passos para Execução

1. **Clone o repositório:**
```bash
git clone <URL_DO_REPOSITORIO>
cd Atividade_DSI
```

2. **Restaurar pacotes NuGet:**
```bash
dotnet restore
```

3. **Aplicar as Migrations (criar o banco de dados):**
```bash
cd src/BibliotecaApp.Web
dotnet ef database update --project ../BibliotecaApp.Infrastructure
```

4. **Executar a aplicação:**
```bash
dotnet run --project src/BibliotecaApp.Web
```

5. **Acessar no navegador:**
```
https://localhost:5001
ou
http://localhost:5000
```

## 📊 Modelo de Dados

### Autor (1) → Livros (N)

**Autor:**
- Id (PK)
- Nome
- Email
- DataNascimento
- Nacionalidade
- DataCriacao

**Livro:**
- Id (PK)
- Titulo
- ISBN
- AnoPublicacao
- Genero
- NumeroPaginas
- Preco
- AutorId (FK)
- DataCriacao

## 🎯 Validações Implementadas

### 1. DataNascimentoValidaAttribute (Custom)
- Verifica se o autor tem pelo menos 18 anos
- Impede datas futuras
- Cálculo preciso considerando dia e mês do aniversário

### 2. ISBNValidoAttribute (Custom)
- Aceita ISBN-10 e ISBN-13
- Remove hífens e espaços automaticamente
- Valida checksum usando algoritmos oficiais:
  - ISBN-10: Módulo 11
  - ISBN-13: Módulo 10 com peso alternado (1 e 3)
- Aceita 'X' como dígito verificador no ISBN-10

### Outras Validações
- Required, StringLength, Range, EmailAddress
- Data Annotations em todos os campos

## 🔍 Busca AJAX

A busca dinâmica foi implementada nas páginas de listagem:

- **Autores:** Busca por nome, email ou nacionalidade
- **Livros:** Busca por título, ISBN, gênero ou nome do autor

**Características:**
- Busca em tempo real (debounce de 300ms)
- Sem reload da página
- Feedback visual imediato
- Retorna à listagem completa quando o campo está vazio

## 🎨 Interface

- Design moderno e responsivo com Bootstrap 5
- Ícones do Bootstrap Icons
- Mensagens de feedback (success/error) com auto-hide
- Tabelas responsivas
- Formulários validados client-side e server-side

## 👨‍💻 Autor

Desenvolvido para o curso de Desenvolvimento de Sistemas de Informação Avançados I - 2025/02

## 📄 Licença

Este projeto é de uso acadêmico.

