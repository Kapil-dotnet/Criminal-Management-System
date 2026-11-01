# 🚔 Criminal Management System

A web application built with ASP.NET Core MVC for managing criminal records.

The application allows authorized users to create, view, update, delete, and search criminal records. It also includes user authentication, status filtering, and REST API endpoints.

## 🚀 Features

- 👤 **User Registration and Login:** Users can register, log in, and log out.
- 🔒 **Login Protection:** Criminal pages and API endpoints require an authenticated session.
- 📋 **Criminal Record Management:** Create, view, edit, and delete criminal records.
- 🔍 **Criminal Search:** Search records by criminal code, name, or city.
- 🏷️ **Status Filter:** Filter records by Arrested, Under Trial, Released, Convicted, or Acquitted status.
- ✅ **Form Validation:** Validates required fields, email addresses, and phone numbers.
- 🌐 **REST API:** Provides GET, POST, PUT, and DELETE endpoints for criminal records.
- 📄 **JSON Responses:** API responses contain criminal record data in JSON format.

## 🛠️ Tech Stack

| Category | Technologies |
|---|---|
| Programming Language | C# |
| Web Framework | ASP.NET Core MVC |
| Database | Microsoft SQL Server |
| Data Access | Entity Framework Core |
| Authentication | ASP.NET Core Identity |
| Frontend | Razor Views, HTML, CSS, Bootstrap |
| API | ASP.NET Core Web API |
| Version Control | Git, GitHub |

## 📁 Project Structure

```text
CriminalManagementSystem/
├── Controllers/
│   ├── AccountController.cs
│   ├── CriminalsController.cs
│   ├── CriminalsApiController.cs
│   └── HomeController.cs
├── Data/
│   └── CriminalDbContext.cs
├── Migrations/
├── Models/
│   ├── Criminal.cs
│   ├── LoginViewModel.cs
│   └── RegisterViewModel.cs
├── Views/
│   ├── Account/
│   ├── Criminals/
│   ├── Home/
│   └── Shared/
├── wwwroot/
├── appsettings.json
├── Program.cs
└── README.md
```

## ⚙️ Installation and Setup

### 1. Prerequisites

Make sure the following tools are installed:

- 💻 Visual Studio with the ASP.NET and web development workload
- 🧰 The .NET SDK version required by the project
- 🗄️ SQL Server or SQL Server LocalDB
- 🔧 Git

### 2. Clone the Repository

```bash
git clone https://github.com/Kapil-dotnet/Criminal-Management-System.git
cd Criminal-Management-System
```

### 3. Configure the Database

Open `appsettings.json` and configure the `DefaultConnection` connection string for your SQL Server.

Never publish database passwords or other secrets on GitHub.

### 4. Apply Database Migrations

In Visual Studio, open **Tools → NuGet Package Manager → Package Manager Console** and run:

```powershell
Update-Database
```

### 5. Run the Application

Open the solution or `.csproj` file in Visual Studio, then press **F5** or click **Start**.

### 6. Register and Log In

Register an account and log in to access the Criminals pages.

### 7. Publish the Application

To create a Release build, open a terminal in the project directory and run:

```bash
dotnet publish -c Release
```

The publish output is created in the project's `bin/Release` directory.

## 🔗 API Endpoints

The API provides the following endpoints. All endpoints require an authenticated session.

| HTTP Method | Endpoint | Description |
|---|---|---|
| GET | `/api/criminals` | Gets all criminal records |
| GET | `/api/criminals/{id}` | Gets one criminal record by ID |
| POST | `/api/criminals` | Creates a criminal record |
| PUT | `/api/criminals/{id}` | Updates a criminal record |
| DELETE | `/api/criminals/{id}` | Deletes a criminal record |

After logging in, open `/api/criminals` in the same browser to view the records as JSON.

## 🗃️ Database Migrations

Entity Framework Core migrations keep the database schema in sync with the application models.

To apply existing migrations to the configured database, run:

```powershell
Update-Database
```

When the model changes, create a migration and then update the database:

```powershell
Add-Migration MigrationName
Update-Database
```

## 🧪 Backend Verification

After starting the application:

1. Log in through the browser.
2. Open `/api/criminals` using the same browser session.
3. Confirm that criminal records appear as JSON.
4. Try an API endpoint without logging in; a `401 Unauthorized` response is expected.

## 🔐 Security and Best Practices

- 🔑 Do not commit database passwords or secrets to GitHub.
- 🧪 Use fictional sample records for demonstrations.
- 🛡️ API endpoints and criminal pages require authentication.
- 🔒 Do not publish real sensitive personal or criminal information.
- 📦 Keep project packages and dependencies up to date.
- 🌿 Use Git and GitHub to track project changes.

## 🔮 Future Improvements

- 📄 Add pagination to the criminal records list.
- 👥 Add role-based access for different user types.
- 🖼️ Add criminal photo upload support.
- 📊 Add dashboard summaries and reports.
- ☁️ Deploy the application with a hosted database.

## 👨‍💻 Author

GitHub: [Kapil-dotnet](https://github.com/Kapil-dotnet)
LinkedIn: [Kapil Rathod](https://www.linkedin.com/in/kapil-rathod-dotnet/)

