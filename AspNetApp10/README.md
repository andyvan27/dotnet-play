# Create ASPNet App
```
dotnet new webapp -n MyAspNetApp10 -f net10.0
```
# Run
```
dotnet run
```

# Debug
Create .vscode/launch.json:
```
{
    "version": "0.2.0",
    "configurations": [
        {
            "name": "C#: AspNetApp10 Debug",
            "type": "dotnet",
            "request": "launch",
            "projectPath": "${workspaceFolder}/AspNetApp10.csproj"
        }
    ]
}
```
# Add Open Api
```
dotnet add package Microsoft.AspNetCore.OpenApi
```

# Add NewtonsoftJson
```
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson
```

# Add xUnit
```
dotnet new xunit -n AspNetApp10.Tests
dotnet add AspNetApp10.Tests/AspNetApp10.Tests.csproj reference AspNetApp10.csproj
dotnet sln AspNetApp10.sln add AspNetApp10.Tests/AspNetApp10.Tests.csproj
dotnet add AspNetApp10.Tests package Microsoft.AspNetCore.Mvc.Testing
```

# Trust cert:
```
dotnet dev-certs https --clean
dotnet dev-certs https --trust
```