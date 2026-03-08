# API de Empreendimentos de Santa Catarina

## Descrição

Esta aplicação consiste em uma API REST desenvolvida em .NET para gerenciamento de empreendimentos localizados no estado de Santa Catarina. A API permite realizar operações de cadastro, consulta, atualização e exclusão de empreendimentos, seguindo o padrão CRUD.

Este projeto foi desenvolvido como parte do projeto técnico do SCTEC, para o EDITAL DE SELEÇÃO Nº 02/2026 – IA para DEVs, com foco em backend.

---

## Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger (OpenAPI)

---

## Estrutura do Projeto

Controllers → endpoints da API
Models → entidades do sistema
DTOs → objetos de transferência de dados
Data → contexto de banco de dados
Migrations → controle de versões do banco

---

## Campos do Empreendimento

- Id do Empreendimento
- Nome do empreendimento
- Nome do empreendedor responsável
- Município de Santa Catarina
- Segmento de atuação
    - Tecnologia
    - Comércio
    - Indústria
    - Serviços
    - Agronegócio
- Email 
- Status (ativo ou inativo)

Campos adicionais implementados:

- Telefone
- Observacao do empreendimento
- Data de cadastro

---

## Endpoints da API

### Listar empreendimentos

GET 
/api/empreendimentos

---

### Buscar por ID

GET 
/api/empreendimentos/{id}

---

### Criar empreendimento

POST
/api/empreendimentos

---

### Atualizar empreendimento

PUT
/api/empreendimentos/{id}

---

### Remover empreendimento

DELETE
/api/empreendimentos/{id}

---

## Como executar o projeto

### 1 - Clonar repositório

git clone https://github.com/seuusuario/empreendimentos-sc-api.git

---

### 2 - Abrir no Visual Studio

Abrir o arquivo da solução no Visual Studio.

---

### 3 - Para criar o banco

No Package Manager Console:


Add-Migration InitialCreate
Update-Database

---

### 4 - Executar aplicação

Pressionar:

F5

---

### 5 - Acessar documentação da API

https://localhost:xxxx/swagger

---

## Autor

Desenvolvido por  
Jacson Tobias Bordin

---

## Vídeo Pitch

Link do vídeo explicando a solução:

