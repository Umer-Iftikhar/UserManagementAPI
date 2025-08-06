# 👥 User Management API

A minimal yet robust RESTful API built with **.NET 8 Minimal APIs** for managing user data.  
This project supports full CRUD operations, validation, middleware for logging, authentication, and proper error handling.

---

## 📁 Project Structure

UserManagementAPI/
├── Program.cs
├── Models/
│ └── User.cs
├── Middleware/
│ ├── ErrorHandlingMiddleware.cs
│ ├── AuthenticationMiddleware.cs
│ └── RequestResponseLoggingMiddleware.cs
├── Services/
│ └── UserService.cs
├── README.md

yaml
Copy
Edit

---

## 🚀 Getting Started

### 🔧 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Git
- Postman or `curl`

### 🛠️ Setup Instructions

```bash
git clone https://github.com/Umer-Iftikhar/UserManagementAPI.git
cd UserManagementAPI
dotnet run
Navigate to:
https://localhost:{PORT}/api/users
```bash

### 📬 API Endpoints
Method	Endpoint	Description
GET	/api/users	Get all users
POST	/api/users	Add a new user
PUT	/api/users/{id}	Update a user
DELETE	/api/users/{id}	Delete a user

🔐 Authentication
This API uses a simple API Key Authentication method.

Include this header in all requests:

http
Copy
Edit
X-Api-Key: your-secret-key
🧠 Features
✅ Minimal API structure

✅ API Key Authentication

✅ Custom Middleware (logging + error handling)

✅ Data Validation via Data Annotations

✅ DTOs for clean data transfer

✅ In-memory store (no database required)

🤖 Powered with Copilot
Throughout development, I used Microsoft Copilot to:

Debug model binding issues and resolve 400/500 errors

Refactor data structures (e.g., from List to Dictionary for performance)

Implement validation using Validator.TryValidateObject

Design and register custom middleware components

Improve error messaging and developer experience

📄 License
MIT License
© 2025 Umer Iftikhar
See LICENSE for details.
