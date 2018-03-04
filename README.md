# Bug Catcher

## Installation

### Build from source
In order to build from source and run this web application locally, you need: Netcore 2.0 SDK and SQL Server.

1. Under `BugCatcher\BugCatcher.Web` directory, run the PowerShell script `dotnet restore`. Next, `dotnet ef database update` to create SQL database.  
1.1. Alternatively, you can run this command `Update-Database` in Package Manager Console inside Visual Studio. Remember to set default project to `BugCatcher.Web`
2. Open the solution with Visual Studio 2017.
3. Build and run BugCatcher.Web project.

Note, check the connection string in `appsettings.json` and make sure the database name is correct (or you can use a dot "." as a database name).

### Host locally with IIS
Coming soon.

## Live Demo

The website is live at: bugcatcher-test.azurewebsites.net
Create new accounts to test or log in with: empl_01@email.com | !Aa123456789
