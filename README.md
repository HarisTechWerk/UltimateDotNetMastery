# Ultimate DotNet Mastery

A full-stack .NET application showcasing real-world software development skills.

## 🚀 Tech Stack

- **Backend**: ASP.NET Core 9.0, Entity Framework Core  
- **Database**: SQL Server (LocalDB)  
- **Authentication**: Identity + JWT  
- **Frontend**: (TBD - React/Angular in progress)  
- **CI/CD**: (Coming Soon)  

## 📂 Project Structure

```
UltimateDotNetMastery/
│── .github/             # GitHub workflows
│── docs/               # Documentation (API, Architecture, Setup)
│── src/                # Source code
│   ├── API/            # Backend API (ASP.NET Core)
│   ├── Core/           # Business logic, Services, Data
│   ├── WebApp/         # Frontend (Upcoming)
│── case-studies/       # Real-world project examples
│── challenges/         # Coding challenges
│── UltimateDotNetMastery.sln # Solution file
```

## 🛠️ Setup Instructions

### 1️⃣ Clone the repository:
```sh
git clone https://github.com/HarisTechWerk/UltimateDotNetMastery.git
cd UltimateDotNetMastery
```

## 📖 Project Setup Guide

### Setup the Database:
```sh
dotnet ef database update --project src/Core/UltimateDotNetMastery.Core/ --startup-project src/API/UltimateDotNetAPI/UltimateDotNetAPI.csproj
```

### Run the API:
```sh
dotnet run --project src/API/UltimateDotNetAPI/UltimateDotNetAPI.csproj
```

### Open Swagger UI:
Once the API is running, open your browser and go to:
```
http://localhost:<PORT>/swagger
```

## ✅ Features Implemented
- User authentication using Identity + JWT
- Secure API endpoints with Authorization
- Entity Framework Core with SQL Server
- Swagger UI for API testing
- Modular backend architecture
- Upcoming frontend with React/Angular

## 📌 Future Improvements
- Add Role-based Authorization
- Integrate CI/CD pipeline
- Implement full-stack functionality with frontend
- Optimize API performance and security


---


