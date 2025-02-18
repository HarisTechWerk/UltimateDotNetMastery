# Ultimate DotNet Mastery 

### A full-stack .NET application showcasing real-world software development skills.

## 🛠️ Tech Stack
- **Backend:** ASP.NET Core 9.0, Entity Framework Core
- **Database:** SQL Server (LocalDB)
- **Authentication:** Identity + JWT
- **Frontend:** (TBD - React/Angular in progress)
- **CI/CD:** (Coming Soon)

## 📂 Project Structure

UltimateDotNetMastery/
│── .github/            # GitHub workflows
│── docs/               # Documentation (API, Architecture, Setup)
│── src/                # Source code
│   │── API/            # Backend API (ASP.NET Core)
│   │── Core/           # Business logic, Services, Data
│   │── WebApp/         # Frontend (Upcoming)
│── case-studies/       # Real-world project examples
│── challenges/         # Coding challenges
│── UltimateDotNetMastery.sln  # Solution file


##  Setup Instructions
1. Clone the repository:
   ```sh
   git clone https://github.com/HarisTechWerk/UltimateDotNetMastery.git
   cd UltimateDotNetMastery

# Project Setup Guide

## Setup the Database (Make sure SQL Server is running):

```sh
dotnet ef database update --project src/Core/UltimateDotNetMastery.Core/ --startup-project src/API/UltimateDotNetAPI/

2. Run the API:
dotnet run --project src/API/UltimateDotNetAPI/UltimateDotNetAPI.csproj

3. Open Swagger UI:

Once the API is running, open your browser and go to:
http://localhost:<PORT>/swagger

4. Open Swagger UI to test the API.