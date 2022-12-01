# .NET 6 MVC Template V1.0.0
Template for ASP.NET MVC Web Apps with .NET 6

## Getting Started
1. Clone the repo/download the latest release
2. Put the MVCTemplate ZIP in <your navigation>\Visual Studio 2022\Templates\ProjectTemplates 
3. Open Visual Studio 2022
4. Create a new project
5. Select the MVCTemplate
6. Change the connection string(s) in UI/appsettings.json
7. Open Tools -> NuGet Package Manager -> Package Manager Console
8. Run the following commands on Default Project: Infrastructure
    - Add-Migration "Initial" -Context BusinessContext
    - Update-Database -Context BusinessContext
    - Add-Migration "Initial" -Context IdentityContext
    - Update-Database -Context IdentityContext

## Featuring
- Onion Architecture
- EntityFramework Core
- Identity (Authentication & Authorization)
- RepositoryManager
- ServiceManager
- NPM (TailwindCSS, Autoprefixer, PostCSS)
- FlowBite (CSS addition for TailwindCSS)
