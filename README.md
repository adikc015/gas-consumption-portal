# Smart Gas Portal

Smart Gas Portal is an ASP.NET Core 8 web app for gas consumption customers. It uses Razor Pages, ASP.NET Core Identity, and SQLite to provide login, registration, and dashboard-style pages for consumer account access.

## Features

- User registration and login
- ASP.NET Core Identity authentication
- SQLite-backed data storage
- Razor Pages UI for portal screens
- EF Core migrations for schema updates

## Prerequisites

- .NET 8 SDK
- SQLite is used automatically through EF Core, so no separate database server is required

## Project Structure

- `Login page/Program.cs` - app startup and service registration
- `Login page/Data/ApplicationDbContext.cs` - EF Core database context
- `Login page/Models/` - Identity and domain models
- `Login page/Pages/` - Razor Pages for login, register, dashboard, and profile screens
- `Login page/Migrations/` - EF Core migrations
- `Login page/appsettings.json` - connection string and app settings

## Setup

From the repository root:

```powershell
cd "Login page"
dotnet restore
dotnet ef database update
```

The app uses the connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=GasConsumption.db"
}
```

That creates or updates the local SQLite database file inside the project folder.

## Run the app

From the `Login page` folder:

```powershell
dotnet run
```

When the app starts, open the local URL shown in the terminal. In this workspace, it has been running at:

```text
http://localhost:5232/Login
```

## Build

```powershell
cd "Login page"
dotnet build
```

## Database Updates

If you change the models or migrations, apply the schema update again:

```powershell
cd "Login page"
dotnet ef database update
```

## Notes

- The project folder name contains a space, so keep the quotes in PowerShell commands.
- The `GasConsumption.db` file is the local SQLite database created by EF Core.
- Swagger is enabled in Development mode.

## Troubleshooting

- If the app will not start, make sure the .NET 8 SDK is installed.
- If database errors appear, rerun `dotnet ef database update` from the `Login page` folder.
- If you change ports or profiles, check `Login page/Properties/launchSettings.json`.
