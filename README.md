# 👥 User Management API

A minimal yet robust RESTful API built with **.NET 8 Minimal APIs** for managing user data.  
This project supports full CRUD operations, validation, middleware for logging, authentication, and proper error handling.

---

## 📁 Project Structure

UserManagementAPI/
├── Program.cs # Entry point with endpoint definitions and middleware registration
├── Models/
│ └── User.cs # User model with validation attributes
├── Middleware/
│ ├── ErrorHandlingMiddleware.cs # Global error handler
│ ├── AuthenticationMiddleware.cs # API key-based authentication
│ └── RequestResponseLoggingMiddleware.cs # Request/Response logger
├── Services/
│ └── UserService.cs # In-memory data store and CRUD logic
├── README.md # Project documentation


---

## 🚀 Getting Started

### 🔧 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Git
- Postman or `curl` (for API testing)

### 🛠️ Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/Umer-Iftikhar/UserManagementAPI.git
   cd UserManagementAPI

2. **Run the API
    ```bash
    dotnet run
3.**api will be available at:
  ```bash
  https://localhost:{PORT}/api/users

### 📬 API Endpoints

Method	Endpoint	Description
GET	/api/users	Get all users
POST	/api/users	Add new user
PUT	/api/users/{id}	Update user by ID
DELETE	/api/users/{id}	Delete user by ID

🔐 Authentication Required
Include a header:
X-Api-Key: your-secret-key

### 🤖 Copilot Collaboration
Throughout development, I used Microsoft Copilot to:

Debug model binding issues and resolve 400/500 errors

Refactor data structures (e.g., from List to Dictionary for performance)

Implement validation using Validator.TryValidateObject

Design and register custom middleware components

Improve error messaging and developer experience

Copilot provided step-by-step guidance, code snippets, and best practices that accelerated development and deepened my understanding of backend API design.

### 🧰 Technologies Used
.NET 8 Minimal APIs

C#

In-Memory Data Store

Custom Middleware

Error Handling

API Key Authentication

Request/Response Logging

### 📄 License
This project is licensed under the MIT License.
