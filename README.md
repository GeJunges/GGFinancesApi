/****IN CONSTRUCTION****/

Project created in VS Code terminal: 
	creating command in line: 	
		dotnet new web --name FinancesApi --framework netcoreapp2.0
		dotnet new classlib --name FinancesApiTests --framework netcoreapp2.0
	
	nuget add packages command in line:
		dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

	nuget restore command in line:
		dotnet restore

	build command in line:
		dotnet build
		
	add project references command in line:
		dotnet add reference ../FinancesApi/FinancesApi.csproj

	run project command in line:
		dotnet run

	run tests command in line:
		dotnet test

	creating initial migrations:
		dotnet ef migrations add InitialCreate

	applying migration in database:
		dotnet ef database update

	delete database:
		dotnet ef database drop