# Keyloop Sales Lead Management Tool - Backend

## Overview
A clean .NET 10 Web API for managing sales leads and follow-up activities, built for the Keyloop Technical Assessment (Scenario C).

## Features
- RESTful API for leads and activities
- SQLite persistence with EF Core
- Seeded sample data
- Swagger UI for easy testing
- Structured logging with Serilog
- Health check endpoint

## Tech Stack
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core + SQLite
- Serilog
- Swashbuckle (Swagger)

## How to Run

1. Ensure you have [.NET 10 SDK](https://dotnet.microsoft.com/download) installed.

2. Navigate to the project:
   ```bash
   cd Keyloop.SalesLeadTool
   ```

3. Restore and run:
   ```bash
   dotnet restore
   dotnet run --project src/Keyloop.SalesLeads.Api
   ```

4. Open Swagger: https://localhost:5001/swagger (or the port shown)

## API Endpoints

- `GET /api/leads` - List all leads
- `POST /api/leads` - Add new lead
- `GET /api/leads/{id}` - Get lead details + activities
- `POST /api/leads/{id}/activities` - Log new activity
- `GET /health` - Health check

## Example POST Body
```json
{
   "name": "string",
   "email": "user@example.com",
   "phone": "string",
   "vehicleInterest": "string",
   "status": "string",
   "source": "string"
}
```

## Tests
Basic tests can be added in `/tests` folder (xUnit recommended).

## AI Collaboration
This solution was built in close collaboration with Grok (xAI), Codex, Copilot.
- Grok helped generate models, controllers, seeding logic, and ensured clean architecture.
- Codex helped with fixes and updates.
- Copilot helped generate sample data and testings. 


---

**System Design Document** is in the conversation history.
