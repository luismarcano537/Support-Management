# Support Management - Desafio Técnico

Uma aplicação web essencial para gestão do ciclo de vida de chamados de suporte técnico, desenvolvida com foco em entrega rápida, código limpo e arquitetura MVC.

## 🎯 O Objetivo

Este projeto foi construído como um Produto Mínimo Viável (MVP) para demonstrar proficiência na stack principal em uma entrevista de emprego. A escolha do domínio de "Gestão de Incidentes" reflete minha vivência prática em ambientes de produção e suporte, traduzindo regras de negócio reais (abertura, categorização e resolução de tickets) em software funcional.

## 🛠️ Stack Tecnológica

* **Back-end:** C# / ASP.NET Core MVC (.NET 10)
* **Banco de Dados:** PostgreSQL (Relacional)
* **ORM:** Entity Framework Core
* **Front-end:** HTML5, Razor Views e Bootstrap 5

## 🧠 Decisões Arquiteturais e Boas Práticas

Durante o desenvolvimento deste MVP, priorizei a viabilidade técnica e a segurança em detrimento do *overengineering*:

1. **Abstração Criteriosa (Sem Repositórios Genéricos):** Optei por não implementar o *Repository Pattern* genérico. O próprio Entity Framework Core (`DbContext` e `DbSet`) já atua nativamente como *Unit of Work* e *Repository*. Adicionar uma camada genérica extra para um CRUD simples apenas geraria complexidade desnecessária. O acesso a dados foi feito via injeção de dependência diretamente nos Controllers.
2. **Prevenção contra Overposting (Mass Assignment):** No fluxo de atualização (Update) dos tickets, a data de criação (`CreationDate`) e os dados de auditoria foram intencionalmente removidos da View. O Controller busca a entidade original no banco de dados e atualiza estritamente os campos permitidos, bloqueando qualquer tentativa de injeção de dados via manipulação do HTML/Requisição HTTP pelo lado do cliente.
3. **Seed de Dados Nativos:** O banco de dados é populado automaticamente com as Categorias essenciais (Hardware, Software, Redes, acessos e dúvidas) via `OnModelCreating`, garantindo que a aplicação já nasça pronta para uso no primeiro *build*, sem necessidade de scripts SQL externos.

## 🚀 Como Executar o Projeto Localmente

**Pré-requisitos:**
* SDK do .NET instalado.
* Instância do PostgreSQL rodando (local ou via Docker).

**Passo a passo:**

1. Clone o repositório:
   ```bash
   git clone [https://github.com/luismarcano537/Support-Management.git]
   cd [SupportManagement]
   ```

2. Configure o Banco de Dados:
* Abra o arquivo appsettings.json.
* Altere a DefaultConnection com as suas credenciais do PostgreSQL local (Host, Port, Database, Username, Password).

3. Aplique as Migrations (Isso criará as tabelas e fará o Seed das Categorias):
```
dotnet ef database update
```
4. Execute a aplicação:
```
dotnet run
```

Acesse a URL informada no terminal (geralmente http://localhost:5000 ou similar) no seu navegador.


