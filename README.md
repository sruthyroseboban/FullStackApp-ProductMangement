# FullStackApp — Product Management

Small full‑stack API for user + product management built with .NET 9, MediatR, EF Core (MySQL) and JWT authentication.

## Repo layout
- `FullStackApp.API` — ASP.NET Core Web API, controllers, Swagger and startup.
- `FullStackApp.Application` — application layer (commands, queries, DTOs).
- `FullStackApp.Infrastructure` — EF Core `AppDbContext`, repositories, JWT token generator.

## Prerequisites
- .NET 9 SDK
- MySQL server
- Visual Studio 2026 (optional) or `dotnet` CLI
- (NuGet) Internet access for package restore

## Configuration
Edit `FullStackApp.API\appsettings.json` (or use environment variables) to set your DB and JWT values:

- Connection string: `ConnectionStrings:DefaultConnection`
- JWT settings under `Jwt`:
  - `Key`, `Issuer`, `Audience`, `ExpiryMinutes`

Example (do not commit secrets):
