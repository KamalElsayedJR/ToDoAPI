![.NET](https://img.shields.io/badge/.NET-6.0-blue)
![EF Core](https://img.shields.io/badge/EF_Core-6.0-lightgrey)

# Todo API

A simple Todo API built with ASP.NET Core 6, using Repository & Service layers with EF Core.

## Features
- Create, Read, Update, Delete Todo items
- Change task status
- Uses DTOs and AutoMapper
- Clean architecture (Core, Services, Repository, API)

## Tech Stack
- ASP.NET Core 6
- Entity Framework Core
- AutoMapper
- SQL Server

## How to Run
1. Clone the repo
```bash
git clone https://github.com/username/TodoApi.git
```
2. **Open the solution in Visual Studio**

Open TodoApi.sln

3. **Update appsettings.json with your connection string**

Open ToDo.API/appsettings.json and edit:
```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TodoDb;Trusted_Connection=True;"
}
```

4. **Run migrations (if needed)**
```
dotnet ef database update --startup-project ./ToDo.API
```
This will create or update the database according to the migrations.

5. **Run the API**

Press F5 or Ctrl+F5 in Visual Studio.

6. **Test endpoints using Swagger or Postman**
