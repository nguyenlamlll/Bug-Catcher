# Bug Catcher

## Installation

### Build from source
In order to build from source and run this web application locally, you need: Netcore 2.0 SDK and SQL Server.

1. Under `BugCatcher\BugCatcher.DALImplementation`, run the PowerShell script `dotnet restore`.
2. And `dotnet ef database update` to create SQL database.
3. Open the solution with Visual Studio.
4. Build and run BugCatcher.Web project.

Note, check the connection string in `appsettings.json` and make sure the database name is correct (or you can use a dot "." as a database name).

### Host locally with IIS
Coming soon.

## Live Demo

The website is live at: bugcatcher-test.azurewebsites.net
Create new accounts to test or log in with: empl_01@email.com | !Aa123456789
