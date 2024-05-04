
# Web App

Seminarski rad iz razvoj sotvera I 
*Ajdin Kuduzovic 
*Jasir Buric



## Requirements Windows / Linux
- Visual studio or VS code with dotnet extentions
- NodeJS , NPM , Angular , .NET-sdk >= 6
- WebStorm or VS code
- MSSQL server or Docker / Podman
- MSSQL server managment studio or Azure data studio  



## Run and test project 
- Edit ConnectionStrings in appsettings.json
- Visual Studio : add-migration initV1 - update-database in package manager 
- VS Code : dotnet tool restore - dotnet ef migrations add init - dotnet ef database update 
