# Portfolio Project Documentation

## Project Overview

This is a full-stack portfolio application that showcases professional experience, skills, and projects. The project consists of:

- **Backend**: ASP.NET Core Web API (.NET 6+) for managing portfolio data
- **Frontend**: React/TypeScript web application for displaying the portfolio
- **Database**: Entity Framework Core with SQL Server

The application provides a RESTful API backend that serves portfolio content to a modern web frontend, allowing users to view professional information in an interactive format.

## Getting Started

### Prerequisites

- .NET 6.0 SDK or later
- Node.js 16+ and npm/yarn
- Visual Studio 2022 or VS Code
- SQL Server or SQL Server Express LocalDB

### Installation

1. **Backend Setup**:

   ```bash
   cd Portfolio.Api
   dotnet restore
   dotnet build
   ```

2. **Frontend Setup**:

   ```bash
   cd Portfolio.Web
   npm install
   # or
   yarn install
   ```

3. **Database Configuration**:
   - Update connection strings in `appsettings.json`
   - Run database migrations: `dotnet ef database update`

### Running the Application

1. **Backend**:

   ```bash
   cd Portfolio.Api
   dotnet run
   ```

2. **Frontend**:
   ```bash
   cd Portfolio.Web
   npm run dev
   # or
   yarn dev
   ```

### Running Tests

```bash
cd Portfolio.Api
dotnet test
```

## Project Structure

### Backend (`Portfolio.Api/`)

- `BlogPost/` - Blog post management controllers and models
- `Common/` - Shared utilities and common components
- `Context/` - Entity Framework Core database context
- `Education/` - Education-related data models and controllers
- `Experience/` - Work experience data models and controllers
- `Initialization/` - Database initialization logic
- `Project/` - Project showcase data models and controllers
- `Site/` - Site configuration and settings
- `SkillCategory/` - Skills categorization models and controllers
- `Program.cs` - Application entry point
- `appsettings.json` - Configuration files

### Frontend (`Portfolio.Web/`)

- `src/` - Main source code directory
- `public/` - Static assets
- `package.json` - Dependencies and scripts
- `vite.config.ts` - Vite build configuration

## Development Workflow

### Coding Standards

- Follow .NET C# coding conventions
- Use PascalCase for C# identifiers
- Follow RESTful API design principles
- Use TypeScript for frontend with strict typing

### Testing Approach

- Unit tests using xUnit for backend
- Integration tests for API endpoints
- Frontend tests using Jest or React Testing Library

### Build and Deployment

1. **Backend**:
   - Build: `dotnet build`
   - Publish: `dotnet publish -c Release`

2. **Frontend**:
   - Build: `npm run build`
   - Serve: `npm run preview`

### Contribution Guidelines

- Create feature branches from `main`
- Follow commit message conventions (e.g., "feat: add new skill category")
- Run tests before submitting pull requests
- Update documentation for new features

## Key Concepts

### Domain Models

- **Experience**: Work history with company, position, and duration
- **Education**: Academic background with institution and degree details
- **Project**: Portfolio projects with descriptions and technologies used
- **SkillCategory**: Grouping of skills by category (e.g., Frontend, Backend)
- **BlogPost**: Technical articles or blog entries

### Design Patterns

- **Repository Pattern**: Data access abstraction in `Context/` directory
- **Dependency Injection**: Managed through ASP.NET Core DI container
- **CQRS Pattern**: Separation of read and write operations
- **Mediator Pattern**: For handling complex business logic

## Common Tasks

### Adding New Experience Entry

1. Create new experience model in `Experience/` folder
2. Add controller endpoint in `Experience/ExperienceController.cs`
3. Update database context in `Context/PortfolioContext.cs`
4. Run migration: `dotnet ef migrations add AddExperience`

### Adding New Project

1. Create project model in `Project/` folder
2. Add controller endpoint in `Project/ProjectsController.cs`
3. Update database context in `Context/PortfolioContext.cs`
4. Run migration: `dotnet ef migrations add AddProject`

### Updating Skills

1. Modify skill data in `SkillCategory/` models
2. Update API endpoints if needed
3. Test changes in frontend

## Troubleshooting

### Database Issues

- **Migration errors**: Run `dotnet ef database update`
- **Connection issues**: Verify connection strings in `appsettings.json`
- **Data seeding**: Use `Initialization/` folder for seed data

### Frontend Development

- **Hot reload not working**: Ensure Node.js is properly installed and `node_modules` are up to date
- **TypeScript errors**: Run `npm run type-check` to identify issues
- **Build failures**: Clear `node_modules` and reinstall dependencies

### API Issues

- **404 errors**: Verify controller routes and endpoint URLs
- **CORS issues**: Check CORS configuration in `Program.cs`
- **Authentication problems**: Review JWT token handling in authentication middleware

## References

- [.NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [React Documentation](https://reactjs.org/docs/getting-started.html)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [TypeScript Documentation](https://www.typescriptlang.org/docs/)
- [Vite Documentation](https://vitejs.dev/guide/)

## Additional Notes

This project uses:

- ASP.NET Core 6.0 for backend API
- React with TypeScript for frontend
- Entity Framework Core for data access
- Docker for containerization (as indicated by Dockerfile)
- RESTful API design principles
