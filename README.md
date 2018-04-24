

/****IN CONSTRUCTION****/

Project created in VS Code terminal: 
	creating command in line: 	
		dotnet new webapi --name UserService --framework netcoreapp1.1
		dotnet new classlib --name UserServiceTests --framework netcoreapp1.1
	
	nuget add packages command in line:
		dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

	nuget restore command in line:
		dotnet restore

	build command in line:
		dotnet build
		
	add project references command in line:
		dotnet add reference ../UserService/UserService.csproj

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