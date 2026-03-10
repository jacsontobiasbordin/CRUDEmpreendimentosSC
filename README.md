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
Enums → enumerações utilizadas no sistema
Data → contexto de banco de dados
Migrations → controle de versões do banco
Middleware → tratamento global de exceções
Seed → inicialização de dados
Examples → exemplos de requisições para Swagger

---

## Campos do Empreendimento

- Id do Empreendimento
- Nome do empreendimento
- Nome do empreendedor responsável
- Município de Santa Catarina
- Segmento de atuação
    - 1 - Tecnologia
    - 2 - Comércio
    - 3 - Indústria
    - 4 - Serviços
    - 5 - Agronegócio
- Email 
- Status (ativo ou inativo)

Campos adicionais implementados:

- Telefone
- Observacao do empreendimento
- Data de cadastro

---

## Endpoints da API

### Listar empreendimentos

GET /api/empreendimentos

O endpoint permite filtrar empreendimentos por parâmetros de consulta:

GET /api/empreendimentos?municipio=Joinville
GET /api/empreendimentos?segmento=1
GET /api/empreendimentos?municipio=Joinville&segmento=1

O endpoint também possui paginação (opcional). Se não informados os parâmetros de paginação, assume a página 1 com limite máximo de 100 registros por página:

GET /api/empreendimentos?page=1&pageSize=50

---

### Buscar por ID

GET /api/empreendimentos/{id}

---

### Criar empreendimento

POST /api/empreendimentos

```json
{
  "nomeEmpreendimento": "Tech Joinville",
  "nomeEmpreendedor": "João Silva",
  "municipio": "Joinville",
  "segmento": 1,
  "email": "contato@techjoinville.com",
  "status": true,
  "telefone": "47999999999",
  "observacao": "Startup de tecnologia",
  "porteEmpresa": "Médio Porte",
  "website": "www.techjoinville.com.br"
}
```

---

### Atualizar empreendimento

PUT /api/empreendimentos/{id}

---

### Remover empreendimento

DELETE /api/empreendimentos/{id}

---

### Listar segmentos

GET /api/segmentos

---

### Estatísticas de empreendimentos

GET /api/empreendimentos/estatisticas

Retorna dados agregados como:

- Total de empreendimentos
- Quantidade de empreendimentos ativos/inativos
- Distribuição por segmento
- Distribuição por município

---

## Como executar o projeto

### 1 - Clonar repositório

git clone https://github.com/jacsontobiasbordin/CRUDEmpreendimentosSC.git

---

### 2 - Abrir no Visual Studio

Abrir o arquivo da solução no Visual Studio.

---

### 3 - Executar aplicação

Pressionar:

F5

---

### 4 - Acessar documentação da API

A documentação é gerada automaticamente com Swagger.

Após executar a aplicação, deve abrir uma página no navegador, com o seguinte endereço:

https://localhost:xxxx/swagger

O Swagger inclui exemplos automáticos de requisições para os endpoints, para facilitar os testes.

---

## Melhorias Implementadas

Além dos requisitos mínimos do desafio, foram implementadas algumas melhorias para tornar a API mais completa e próxima de um cenário real de produção:

- Implementação de **Enum para Segmento**, garantindo consistência nos valores permitidos.
- Endpoint **GET /api/segmentos** para listar os segmentos disponíveis.
- Implementação de **filtros por município e segmento** no endpoint de listagem de empreendimentos.
- Implementação de **paginação** no endpoint de consulta, com limite máximo de 100 registros por página.
- Criação de endpoint de **estatísticas** (`GET /api/empreendimentos/estatisticas`) com dados agregados por segmento e município.
- Implementação de **middleware global de tratamento de exceções**, padronizando as respostas de erro da API.
- Documentação completa da API com **Swagger / OpenAPI**.
- Inclusão de **exemplos automáticos de requisição no Swagger** para facilitar os testes.
- Implementação de **Seed automático de dados**, populando o banco com 100 empreendimentos de exemplo.
- Organização do projeto em camadas (Controllers, Models, DTOs, Enums, Middleware, Seed).
- Utilização de **DTOs** para controle dos dados de entrada da API.

---

## Autor

Desenvolvido por:
Jacson Tobias Bordin

---

## Vídeo Pitch

Link do vídeo explicando a solução:
https://youtu.be/2GuppKz2IPQ


