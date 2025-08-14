# mcp.setup - .NET 9.0 Console Application

Always reference these instructions first and fallback to search or bash commands only when you encounter unexpected information that does not match the info here.

This is a simple .NET 9.0 console application called "HelloYallNerds" that serves as a Copilot Agent proof-of-concept. The application outputs welcome messages and integrates with GitHub Actions for automated issue handling.

## Working Effectively

### Prerequisites and Setup
- **CRITICAL**: This project requires .NET 9.0 SDK which is NOT installed by default
- Install .NET 9.0 SDK using the official installer:
  ```bash
  curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --version latest --channel 9.0
  export PATH="/home/runner/.dotnet:$PATH"
  ```
- Verify installation: `dotnet --version` should return 9.0.x

### Build and Run Commands
- **Bootstrap the project**:
  ```bash
  export PATH="/home/runner/.dotnet:$PATH"
  cd HelloYallNerds/
  dotnet restore
  ```
  Takes ~1 second. Set timeout to 30+ seconds for safety.

- **Build the application**:
  ```bash
  dotnet build --no-restore
  ```
  Takes ~4 seconds. Set timeout to 60+ seconds for safety.

- **Run tests**:
  ```bash
  dotnet test --no-build --verbosity normal
  ```
  Takes ~1 second. IMPORTANT: No actual unit tests exist - this only validates the framework.

- **Run the application**:
  ```bash
  dotnet run
  ```
  Takes ~2 seconds. Outputs:
  ```
  Hello Y'all Nerds!
  Welcome to the Copilot Agent POC!
  ```

### Alternative Build Approach
- **Full rebuild from scratch**:
  ```bash
  dotnet clean
  dotnet restore
  dotnet build
  dotnet run
  ```

## Validation and Testing

### Manual Validation Requirements
- **ALWAYS** run the application after making changes: `dotnet run`
- Verify the output contains both expected messages:
  - "Hello Y'all Nerds!"
  - "Welcome to the Copilot Agent POC!"
- **CRITICAL**: Application should exit cleanly with code 0

### No Unit Tests
- The project contains NO actual unit tests
- `dotnet test` validates framework compatibility only
- Do NOT expect test failures when running `dotnet test`
- When adding features, consider adding proper unit tests in a separate test project

### CI/CD Validation
- The repository includes `.github/workflows/copilot-agent.yml`
- CI workflow runs: restore → build → test
- CI uses `dotnet-version: '9.0.x'` in GitHub Actions
- Always ensure changes are compatible with the CI pipeline

## Repository Structure

### Key Files and Locations
```
mcp.setup/
├── README.md                           # Minimal project description
├── .gitignore                          # .NET-specific gitignore
├── .github/
│   └── workflows/copilot-agent.yml     # GitHub Actions workflow
└── HelloYallNerds/                     # Main project directory
    ├── HelloYallNerds.csproj           # Project file (targets net9.0)
    └── Program.cs                      # Main application code
```

### Project Configuration
- **Target Framework**: net9.0 (requires .NET 9.0 SDK)
- **Output Type**: Console application executable
- **Features**: ImplicitUsings and Nullable enabled
- **Dependencies**: None (uses only built-in .NET libraries)

## Common Tasks and Troubleshooting

### If Build Fails
- **Error NETSDK1045**: .NET 9.0 SDK not installed
  - Error message: "The current .NET SDK does not support targeting .NET 9.0"
  - Solution: Install .NET 9.0 SDK using the command in Prerequisites section
- **Restore failures**: Run `dotnet clean` then `dotnet restore`
- **Path issues**: Ensure `/home/runner/.dotnet` is in PATH
- **Package conflicts**: Use `dotnet clean` followed by `dotnet restore` to reset state

### GitHub Actions Integration
- Workflow triggers on issue labels 'copilot-agent' or comment '@copilot-agent'
- Uses ubuntu-latest with .NET 9.0.x setup
- Runs standard build pipeline: restore → build → test
- No deployment or publishing steps

### Making Changes
- **Always validate**: Run `dotnet run` after any code changes
- **No linting**: No code formatting or linting tools configured
- **No additional validation**: No code coverage, static analysis, or security scanning
- **Simple structure**: Single file application, minimal complexity

## Time Expectations and Timeouts

### Command Timing (based on validation)
- `dotnet restore`: ~1 second (use 30+ second timeout)
- `dotnet build --no-restore`: ~4 seconds (use 60+ second timeout)  
- `dotnet test --no-build`: ~1 second (use 30+ second timeout)
- `dotnet run`: ~2 seconds (use 30+ second timeout)
- `dotnet add package <name>`: ~4 seconds (use 60+ second timeout)
- Fresh .NET 9.0 SDK installation: ~30 seconds (use 300+ second timeout)

### **NEVER CANCEL** Guidelines
- All commands complete quickly (under 5 seconds)
- Use generous timeouts as specified above
- If commands hang, check .NET 9.0 SDK installation first

## Working with the Codebase

### Program.cs Structure
```csharp
// Simple console application
Console.WriteLine("Hello Y'all Nerds!");
Console.WriteLine("Welcome to the Copilot Agent POC!");
```

### Making Code Changes
- Edit `HelloYallNerds/Program.cs` for application logic changes
- Edit `HelloYallNerds/HelloYallNerds.csproj` for project configuration
- **Always test changes**: Run `dotnet run` to validate functionality
- **Keep it simple**: This is a proof-of-concept console application

### Adding Dependencies
- Use `dotnet add package <PackageName>` in the HelloYallNerds/ directory
- Restore with `dotnet restore` after adding packages
- Update CI workflow if new system dependencies are required

## Expected Output Reference
When running `dotnet run`, expect exactly:
```
Hello Y'all Nerds!
Welcome to the Copilot Agent POC!
```

Any deviation from this output indicates a problem with the changes made.