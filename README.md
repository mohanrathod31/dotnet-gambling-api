# dotnet-gambling-api

## Overview
dotnet-gambling-api is a .NET-based project that provides a versatile API for gambling-related activities. This API offers endpoints for placing bets, managing player accounts, and accessing game data, making it suitable for various gambling applications such as casinos, sports betting platforms, or lottery services.

## Features
- Betting: Allow users to place bets on gambling game.
- Player Management: Manage player accounts, including points balance.
- Game Data Access: Access game-related data such as results and odds.


The key components of the dotnet-gambling-api project:

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



## Getting Started
To use dotnet-gambling-api in your project, follow these steps:

1. Clone the repository: `git clone https://github.com/your-username/dotnet-gambling-api.git`
2. Navigate to the project directory: `cd dotnet-gambling-api`
3. Build and run the project: `dotnet run`

When run the API Project from Visual Studio if Visual Studio gives error like 

"Your Docker server host is configured for 'Linux', however your project targets 'Windows'."

Please Delete Docker file from the project. Right click On Gampble.API project, add Docker Support and Target OS should be linux.

Note: Some time you have uninstall your current Docker Desktop and intall latest docker desktop.
