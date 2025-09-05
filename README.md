# 📚 Livros API

## 📌 Descrição do Projeto

O **Livros API** é uma aplicação desenvolvida em **ASP.NET Core Web API** que permite realizar o cadastro, consulta, atualização e exclusão de livros utilizando o **MongoDB Atlas** como banco de dados.  
O objetivo do projeto é praticar a construção de **APIs RESTful** com persistência em bancos NoSQL e documentação automática via **Swagger**.

---

## 👨‍💻 Integrantes

- Pedro Abrantes Andrade | RM558186  
- Ricardo Tavares de Oliveira Filho | RM556092  
- Victor Alves Carmona | RM555726  

---

## 🚀 Tecnologias Utilizadas

- ASP.NET Core 8 Web API  
- C#  
- MongoDB Atlas (cloud)  
- Swagger (Swashbuckle)  
- Visual Studio 2022  

---

## 📂 Instalação e Execução

### Pré-requisitos

- .NET 8.0 ou superior  
- Visual Studio 2022 ou superior  
- Conta no [MongoDB Atlas](https://www.mongodb.com/atlas)  
- String de conexão válida no Atlas  

---

### 1️⃣ Clonar o repositório
```bash
git clone https://github.com/pdroandrad/cp4---Advanced-Business-Development-with-.NET
cd livros
```

### 2️⃣ Configurar conexão no `appsettings.json`

Abra o projeto no Visual Studio e edite a string de conexão com os dados do seu **MongoDB Atlas**:  

```json
{
  "LivrosDatabase": {
    "ConnectionString": "sua-string-de-conexao-do-atlas",
    "DatabaseName": "LivrosDB",
    "LivrosCollectionName": "Livros"
  }
}
```

### 3️⃣ Executar a API

Rode a aplicação com **HTTPS**.  
O **Swagger UI** será aberto automaticamente em:

👉 [https://localhost:7210/swagger](https://localhost:7210/swagger)

---

## 📡 Endpoints da API

### 🔧 LivrosController

| Método | Endpoint           | Descrição                          |
|--------|--------------------|------------------------------------|
| GET    | `/api/Livros`      | Lista todos os livros cadastrados. |
| GET    | `/api/Livros/{id}` | Retorna os detalhes de um livro.   |
| POST   | `/api/Livros`      | Cria um novo livro.                |
| PUT    | `/api/Livros/{id}` | Atualiza os dados de um livro.     |
| DELETE | `/api/Livros/{id}` | Remove um livro do sistema.        |

---

## 📑 Exemplos de Requisição JSON

### Criar Livro (POST) → `/api/Livros`
```json
{
  "titulo": "Os Miseráveis",
  "anoPublicacao": 1862
  "autor": {
    "nome": "Victor Hugo",
    "nacionalidade": "francesa"
  },

}
```

As demais ações - GET(por ID), PUT e DELETE podem ser realizadas passando o ID que foi gerado automaticamente no método POST.


