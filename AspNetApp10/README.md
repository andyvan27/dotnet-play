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

