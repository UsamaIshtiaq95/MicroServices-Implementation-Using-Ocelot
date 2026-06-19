# 🚀 DecorAI - AI-Powered Interior Design Platform

A modern microservices architecture built with **ASP.NET Core**, demonstrating service decomposition, API gateway routing, JWT authentication, and clean architecture principles.

---

## 🏗️ Architecture Overview

```
                        ┌─────────────────────┐
                        │   Client / Postman   │
                        └──────────┬──────────┘
                                   │
                        ┌──────────▼──────────┐
                        │   Ocelot API Gateway │  ← Route aggregation, auth middleware
                        │     (GatewayApi)     │
                        └──────┬───────┬───────┘
                               │       │
               ┌───────────────▼─┐   ┌─▼──────────────┐
               │   UserAuthApi   │   │    UserApi       │
               │  (JWT Auth)     │   │  (User CRUD)     │
               └───────┬─────────┘   └──────┬──────────┘
                       │                    │
               ┌───────▼────────────────────▼──────────┐
               │         Infrastructure / Domain        │
               │       (Shared Models, SQLite DB)       │
               └───────────────────────────────────────┘
```

---

## 📦 Services

| Service | Responsibility | Port |
|---|---|---|
| `GatewayApi` | Ocelot API Gateway — routes all requests to downstream services | 5000 |
| `UserAuthApi` | Handles registration, login, and JWT token generation | 5001 |
| `UserApi` | User management CRUD operations (protected routes) | 5002 |
| `UserDomain` | Shared domain models and entities | — |
| `Infrastructure` | Shared database context (SQLite via EF Core) | — |
| `Application` | Business logic layer with MediatR handlers | — |

---

## 🛠️ Tech Stack

- **Framework:** ASP.NET Core (.NET 10)
- **API Gateway:** Ocelot
- **Authentication:** JWT Bearer Tokens
- **Database:** SQLite (via Entity Framework Core)
- **ORM:** Entity Framework Core
- **API Design:** RESTful with MediatR CQRS pattern
- **Language:** C#

---

## ✨ Key Features

- ✅ API Gateway with **Ocelot** — centralized routing for all microservices
- ✅ **JWT Authentication** — token issued by Auth service, validated by downstream services
- ✅ **Clean Architecture** — domain, infrastructure, and application layers separated
- ✅ **CQRS Pattern** — MediatR for command/query separation
- ✅ **Generic Repository** — reusable CRUD operations for all entities
- ✅ **Full CRUD Operations** — for all 9 domain entities
- ✅ **Exception Handling** — custom middleware for error management
- ✅ **Postman collection** included for easy API testing

---

## 🚀 Getting Started

### Prerequisites

- [.NET 10 SDK or higher](https://dotnet.microsoft.com/download)
- Visual Studio 2022 or VS Code
- No external database setup required — SQLite is embedded

### Run the Solution

1. **Clone the repository**
```bash
git clone https://github.com/UsamaIshtiaq95/DecorAI.git
cd DecorAI
```

2. **Open the solution**
```bash
start DecorAI.sln
```

3. **Set multiple startup projects** in Visual Studio:
   - `GatewayApi`
   - `UserAuthApi`
   - `UserApi`

4. **Run the solution** — all services will start on their respective ports

---

## 📁 Available API Endpoints

All endpoints are accessible through the API Gateway at `https://localhost:7009`

### Core Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/auth/register` | Register new user |
| POST | `/api/auth/login` | Login and get JWT token |
| GET | `/api/user/Getprofile` | Get user profile (JWT protected) |
| PATCH | `/api/user/UpdateProfile` | Update user profile (JWT protected) |

### CRUD Endpoints (All Entities)

#### Admins
- `GET /api/admins` - Get all admins
- `GET /api/admins/{id}` - Get admin by ID
- `POST /api/admins` - Create admin
- `PUT /api/admins/{id}` - Update admin
- `DELETE /api/admins/{id}` - Delete admin

#### Rooms
- `GET /api/rooms` - Get all rooms
- `GET /api/rooms/{id}` - Get room by ID
- `POST /api/rooms` - Create room
- `PUT /api/rooms/{id}` - Update room
- `DELETE /api/rooms/{id}` - Delete room

#### Contexts
- `GET /api/contexts` - Get all contexts
- `GET /api/contexts/{id}` - Get context by ID
- `POST /api/contexts` - Create context
- `PUT /api/contexts/{id}` - Update context
- `DELETE /api/contexts/{id}` - Delete context

#### Chats
- `GET /api/chats` - Get all chats
- `GET /api/chats/{id}` - Get chat by ID
- `GET /api/chats/user/{userId}` - Get chats by user
- `GET /api/chats/room/{roomId}` - Get chats by room
- `POST /api/chats` - Create chat
- `PUT /api/chats/{id}` - Update chat
- `DELETE /api/chats/{id}` - Delete chat

#### ChatMessages
- `GET /api/chatmessages` - Get all messages
- `GET /api/chatmessages/{id}` - Get message by ID
- `GET /api/chatmessages/chat/{chatId}` - Get messages by chat
- `POST /api/chatmessages` - Create message
- `PUT /api/chatmessages/{id}` - Update message
- `DELETE /api/chatmessages/{id}` - Delete message

#### AIResults
- `GET /api/apiresults` - Get all AI results
- `GET /api/apiresults/{id}` - Get AI result by ID
- `GET /api/apiresults/chat/{chatId}` - Get results by chat
- `POST /api/apiresults` - Create AI result
- `PUT /api/apiresults/{id}` - Update AI result
- `DELETE /api/apiresults/{id}` - Delete AI result

#### Logs
- `GET /api/logs` - Get all logs
- `GET /api/logs/{id}` - Get log by ID
- `GET /api/logs/user/{userId}` - Get logs by user
- `POST /api/logs` - Create log
- `PUT /api/logs/{id}` - Update log
- `DELETE /api/logs/{id}` - Delete log

#### Images
- `GET /api/images` - Get all images
- `GET /api/images/{id}` - Get image by ID
- `GET /api/images/room/{roomId}` - Get images by room
- `POST /api/images` - Create image
- `PUT /api/images/{id}` - Update image
- `DELETE /api/images/{id}` - Delete image

#### ApiKeys
- `GET /api/apikeys` - Get all API keys
- `GET /api/apikeys/{id}` - Get API key by ID
- `GET /api/apikeys/service/{serviceName}` - Get API key by service
- `POST /api/apikeys` - Create API key
- `PUT /api/apikeys/{id}` - Update API key
- `DELETE /api/apikeys/{id}` - Delete API key

---

## 🔐 Authentication Flow

```
1. POST /api/auth/register   → Create new user
2. POST /api/auth/login      → Returns JWT token
3. GET  /api/users           → Pass token in Authorization header
```

**Example Authorization Header:**
```
Authorization: Bearer <your_jwt_token>
```

---

## 🧪 Testing with Postman

A Postman collection is included in the root directory:
📁 `Test-Updated.postman_collection.json`

Import it into Postman and test all endpoints without manual setup.

---

## 📁 Project Structure

```
DecorAI/
├── GatewayApi/              # Ocelot gateway configuration & routing
├── UserAuthApi/             # Authentication service (register/login/JWT)
├── UserApi/                 # User management service (CRUD)
├── UserDomain/              # Shared domain entities & models
├── Infrastructure/          # EF Core DbContext, migrations, repositories
├── Application/             # MediatR handlers, DTOs, Requests/Responses
├── DecorAI.sln              # Visual Studio solution file
└── Test-Updated.postman_collection.json  # Postman test collection
```

---

## 🏛️ Clean Architecture Layers

```
┌─────────────────────────────────────────────────┐
│              Presentation Layer                  │
│  UserApi / UserAuthApi / GatewayApi (Web APIs)   │
│  Controllers, Middleware, Program.cs             │
├─────────────────────────────────────────────────┤
│              Application Layer                    │
│  Application (MediatR CQRS pattern)              │
│  Request/Response DTOs, Handlers                 │
├─────────────────────────────────────────────────┤
│              Domain Layer                         │
│  UserDomain (Entities, Interfaces, Exceptions)   │
│  Pure domain logic, no external dependencies      │
├─────────────────────────────────────────────────┤
│              Infrastructure Layer                 │
│  Infrastructure (EF Core, Repositories, JWT)     │
│  Data access, external service implementations   │
└─────────────────────────────────────────────────┘
```

---

## 📌 Ocelot Gateway Config

Routes are configured in `ocelot.json` inside `GatewayApi`. Example:

```json
{
  "UpstreamPathTemplate": "/api/users/{everything}",
  "UpstreamHttpMethod": [ "GET", "POST", "PUT", "DELETE" ],
  "DownstreamPathTemplate": "/api/users/{everything}",
  "DownstreamHostAndPorts": [{ "Host": "localhost", "Port": 5002 }],
  "AuthenticationOptions": {
    "AuthenticationProviderKey": "Bearer"
  }
}
```

---

## 🔮 Future Improvements

- [ ] Replace SQLite with SQL Server for production use
- [ ] Add Docker & docker-compose support
- [ ] Implement RabbitMQ / message bus for async service communication
- [ ] Add health check endpoints
- [ ] Add unit tests with xUnit
- [ ] Add file upload handling for images
- [ ] Implement caching for frequently accessed data

---

## 👨‍💻 Author

**Usama Ishtiaq** — Backend .NET Engineer
🔗 [LinkedIn](https://www.linkedin.com/in/usama-ishtiaq-094881156/)
📁 [GitHub](https://github.com/UsamaIshtiaq95)

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).
