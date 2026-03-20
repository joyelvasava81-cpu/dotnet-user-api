# User Management API - .NET Project

This repository contains a simple User Management API built with **ASP.NET Core**. This project was developed as part of the **[Back-End Development with .NET](https://www.coursera.org/learn/back-end-development-with-dotnet/home/welcome)** course.

## 🚀 Features & Project Requirements

### 1. CRUD Endpoints
The API provides full Create, Read, Update, and Delete functionality for user management via the `UsersController`:
- **GET /api/users**: Retrieve all users.
- **GET /api/users/{id}**: Retrieve a specific user by ID.
- **POST /api/users**: Add a new user.
- **PUT /api/users/{id}**: Update an existing user's details.
- **DELETE /api/users/{id}**: Remove a user from the system.

### 2. Copilot-Assisted Development & Debugging
In accordance with the **[Module 5](https://www.coursera.org/learn/back-end-development-with-dotnet/home/module/5)** requirements, **Microsoft Copilot** was utilized to:
- Generate initial boilerplate for the Controller actions.
- Debug logic errors, specifically ensuring the `PUT` method correctly handles scenarios where a user ID does not exist.
- Refine the `Program.cs` middleware pipeline.

### 3. Data Validation
To ensure only valid user data is processed, the project implements **Data Annotations** in the `User` model:
- `[Required]`: Ensures name and email are provided.
- `[EmailAddress]`: Validates the format of the email string.
- `[StringLength]`: Restricts the name length for database consistency.
- **ModelState Validation**: The controller checks `ModelState.IsValid` before performing data operations.

### 4. Middleware Implementation
The project includes a middleware pipeline in `Program.cs` that handles:
- **Logging**: A custom middleware delegate logs the HTTP method and path for every incoming request to the console.
- **Developer Tools**: Integration of Swagger/OpenAPI for testing endpoints.
- **Security**: Standard `.NET` Authorization and HTTPS Redirection middleware.

## 🛠️ How to Run
1. Clone the repository.
2. Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed.
3. Run `dotnet run` in the terminal.
4. Navigate to `/swagger` to test the API endpoints.