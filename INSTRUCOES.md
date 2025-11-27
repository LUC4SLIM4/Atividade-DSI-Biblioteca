# 📋 Instruções para Configuração e Execução

## ⚠️ Importante

Este projeto requer o **.NET SDK 8.0** instalado em seu computador.

## 🔧 Instalação do .NET SDK

Se você ainda não tem o .NET instalado, siga estas etapas:

### Windows

1. Acesse: https://dotnet.microsoft.com/download/dotnet/8.0
2. Baixe o instalador do **.NET SDK 8.0** (não o Runtime)
3. Execute o instalador
4. Reinicie o terminal/prompt de comando

### Verificar Instalação

Após instalar, abra um terminal e execute:

```bash
dotnet --version
```

Deve retornar algo como `8.0.xxx`

## 🗄️ Configuração do Banco de Dados

O projeto está configurado para usar **SQL Server LocalDB**, que vem com o Visual Studio.

### Se você não tem o LocalDB instalado:

**Opção 1 - Instalar LocalDB:**
1. Baixe o SQL Server Express: https://www.microsoft.com/sql-server/sql-server-downloads
2. Durante a instalação, selecione "LocalDB"

**Opção 2 - Usar SQL Server completo:**
1. Edite o arquivo `src/BibliotecaApp.Web/appsettings.json`
2. Altere a connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=BibliotecaDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

3. Também edite `src/BibliotecaApp.Infrastructure/Factories/BibliotecaDbContextFactory.cs` com a mesma connection string.

## 🚀 Passos para Executar

### 1. Restaurar Pacotes

Abra o terminal na pasta raiz do projeto (`D:\Atividade_DSI`) e execute:

```bash
dotnet restore
```

### 2. Criar o Banco de Dados

Execute a migration para criar o banco:

```bash
cd src\BibliotecaApp.Web
dotnet ef database update --project ..\BibliotecaApp.Infrastructure
```

### 3. Executar a Aplicação

```bash
dotnet run
```

### 4. Acessar no Navegador

Após executar, abra seu navegador em:
- https://localhost:5001
- ou http://localhost:5000

## 🔍 Comandos Úteis

### Criar uma nova Migration

```bash
cd src\BibliotecaApp.Web
dotnet ef migrations add NomeDaMigracao --project ..\BibliotecaApp.Infrastructure
```

### Remover a última Migration

```bash
cd src\BibliotecaApp.Web
dotnet ef migrations remove --project ..\BibliotecaApp.Infrastructure
```

### Ver o histórico de Migrations

```bash
cd src\BibliotecaApp.Web
dotnet ef migrations list --project ..\BibliotecaApp.Infrastructure
```

### Resetar o Banco de Dados

```bash
cd src\BibliotecaApp.Web
dotnet ef database drop --project ..\BibliotecaApp.Infrastructure
dotnet ef database update --project ..\BibliotecaApp.Infrastructure
```

## 📝 Testando o Sistema

### Exemplos de Dados para Cadastro

**Autor:**
- Nome: Machado de Assis
- Email: machado@literatura.com.br
- Data de Nascimento: 21/06/1839
- Nacionalidade: Brasileiro

**Livro:**
- Título: Dom Casmurro
- ISBN: 978-85-359-0277-1 (ou 9788535902778)
- Ano de Publicação: 1899
- Gênero: Romance
- Número de Páginas: 256
- Preço: 45.90

### Testando Validações Personalizadas

**Teste 1 - Data de Nascimento:**
- Tente cadastrar um autor com menos de 18 anos
- Tente cadastrar com uma data futura
- ✅ Deve exibir mensagem de erro

**Teste 2 - ISBN:**
- ISBN válido (10 dígitos): 0-306-40615-2
- ISBN válido (13 dígitos): 978-3-16-148410-0
- ISBN inválido: 123456789 (apenas 9 dígitos)
- ✅ Deve validar corretamente

### Testando Busca AJAX

1. Acesse a página de Autores ou Livros
2. Digite no campo de busca
3. ✅ Os resultados devem aparecer sem recarregar a página

## 🐛 Solução de Problemas

### Erro: "dotnet não é reconhecido"
**Solução:** Instale o .NET SDK e reinicie o terminal

### Erro ao criar banco: "Cannot attach the file as database"
**Solução:** 
1. Feche o Visual Studio
2. Delete a pasta `bin` e `obj`
3. Execute novamente: `dotnet ef database update`

### Erro: "The Entity Framework tools version is older"
**Solução:**
```bash
dotnet tool update --global dotnet-ef
```

### Porta já em uso
**Solução:** Edite `src/BibliotecaApp.Web/Properties/launchSettings.json` e altere as portas

## 📧 Suporte

Em caso de dúvidas, verifique:
1. A documentação oficial do .NET: https://docs.microsoft.com/dotnet
2. A documentação do Entity Framework Core: https://docs.microsoft.com/ef/core

