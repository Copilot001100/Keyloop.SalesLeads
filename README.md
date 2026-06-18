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
- `GET /api/leads/{id}` - Get lead details + activities
- `POST /api/leads/{id}/activities` - Log new activity
- `GET /health` - Health check

## Example POST Body
```json
{
  "type": "Call",
  "notes": "Customer interested in test drive",
  "performedBy": "Alice"
}
```

## Tests
Basic tests can be added in `/tests` folder (xUnit recommended).

## AI Collaboration
This solution was built in close collaboration with Grok (xAI). Grok helped generate models, controllers, seeding logic, and ensured clean architecture.

---

**System Design Document** is in the conversation history.
