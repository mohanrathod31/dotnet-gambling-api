# dotnet-gambling-api

## Overview
dotnet-gambling-api is a .NET-based project that provides a API for gambling activitity. This API offers endpoints for placing bets and managing player accounts.
## Features
- Betting: Allow users to place bets on gambling game.
- Player Management: Manage player accounts, including points balance.

## Future feature enhancements
- Game Data Access: Access game-related data such as results and odds
- Player History etc.
- making it suitable for various gambling applications such as casinos, sports betting platforms, or lottery services.

**The key components of the dotnet-gambling-api project:**

##Followed Domain Driven Design(DDD)

**GampleAPI.Application (Contains Application Features)
   - Controllers
   - Services

**GampleAPI.Domain (Contains Domain Enties)
   - Bet.cs
   - GameResult.cs
   - Player.cs

**GampleAPI.Infrastructute (Repositories and DbContext)

   - Data
   - Repositories

##Followed Test Driven Development (TDD)
   - GambleAPI.Tests (Contains Unit Test methods for GameService Play method)

##Followed Design Patterns
  - Repository Pattern
  - Dependency Injection

## Followed Exception Handling and Data Validation as well.

## Technologies used.
   - .NET 8
   - EntityFramework Core 8.2
   - Visual Studio 2022

## Getting Started
Steps to run dotnet-gambling-api:

1. Clone the repository: `git clone https://github.com/mohanrathod31/dotnet-gambling-api.git`
2. Navigate to the project directory: `cd dotnet-gambling-api`
3. Build and run the project: `dotnet run`

When run the API Project from Visual Studio if Visual Studio gives error like 

"Your Docker server host is configured for 'Linux', however your project targets 'Windows'."

Please Delete Docker file from the project Then Right click On Gampble.API project, add Docker Support and Target OS should be linux.

Note: Some time you need to uninstall your current Docker Desktop and intall latest docker desktop to run the application.
