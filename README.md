# 🚀 Microservices Architecture with Ocelot API Gateway

A production-style microservices implementation built with **ASP.NET Core**, demonstrating service decomposition, API gateway routing, JWT authentication, and clean architecture principles.

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

---

## 🛠️ Tech Stack

- **Framework:** ASP.NET Core (.NET 8)
- **API Gateway:** Ocelot
- **Authentication:** JWT Bearer Tokens
- **Database:** SQLite (via Entity Framework Core)
- **ORM:** Entity Framework Core
- **API Testing:** Postman (collection included)
- **Language:** C#

---

## ✨ Key Features

- ✅ API Gateway with **Ocelot** — centralized routing for all microservices
- ✅ **JWT Authentication** — token issued by Auth service, validated at gateway level
- ✅ **Role-based authorization** — protected routes accessible only with valid token
- ✅ **Clean Architecture** — domain, infrastructure, and application layers separated
- ✅ **Shared Infrastructure** — common DB context and models via shared projects
- ✅ **Postman collection** included for easy API testing

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK or higher](https://dotnet.microsoft.com/download)
- Visual Studio 2022 or VS Code
- No external database setup required — SQLite is embedded

### Run the Solution

1. **Clone the repository**
```bash
git clone https://github.com/UsamaIshtiaq95/MicroServices-Implementation-Using-Ocelot.git
cd MicroServices-Implementation-Using-Ocelot
```

2. **Open the solution**
```bash
start Solution1.sln
```

3. **Set multiple startup projects** in Visual Studio:
   - `GatewayApi`
   - `UserAuthApi`
   - `UserApi`

4. **Run the solution** — all services will start on their respective ports

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
MicroServices-Implementation-Using-Ocelot/
├── GatewayApi/              # Ocelot gateway configuration & routing
├── UserAuthApi/             # Authentication service (register/login/JWT)
├── UserApi/                 # User management service (CRUD)
├── UserDomain/              # Shared domain entities & models
├── Infrastructure/          # EF Core DbContext, migrations, SQLite
├── Solution1.sln            # Visual Studio solution file
└── Test-Updated.postman_collection.json  # Postman test collection
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

---

## 👨‍💻 Author

**Usama Ishtiaq** — Backend .NET Engineer  
🔗 [LinkedIn](https://www.linkedin.com/in/usama-ishtiaq-094881156/)  
📁 [GitHub](https://github.com/UsamaIshtiaq95)

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).
