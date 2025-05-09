# TrackerLibrary

## Overview

This class library contains the core business logic, data models, and data access components for the Tournament Tracker application.

## Project Status

### Completed

*   Initial setup of the class library project.
*   Definition of core data models:
    *   `PersonModel`
    *   `PrizeModel`
    *   `TeamModel`
    *   `TournamentModel`
    *   `MatchupModel`
    *   `MatchupEntryModel`
*   Global configuration setup (`GlobalConfig.cs`).
*   Full implementation of data access interfaces (`IDataConnection`).
*   Full implementation of `SqlConnector.cs` to interact with the MySQL database using stored procedures.
*   Full implementation of `TextConnector.cs` for data storage in text files.
*   Successful integration with `TrackerUI` for core data operations.

### Next Steps

1.  **Implement Advanced Business Logic:** Focus on developing core tournament management logic, including:
    *   Automated matchup generation based on tournament type (e.g., round-robin, single elimination).
    *   Score recording and validation.
    *   Round progression and winner determination.
    *   Prize calculation and distribution logic.
2.  **Comprehensive Unit Testing:** Develop thorough unit tests for all data access methods and business logic components to ensure reliability and correctness.
3.  **Refinement and Optimization:** Review existing code for potential optimizations and clarity.

## How to Use

This library is intended to be referenced by the `TrackerUI` project or any other presentation layer that needs to interact with the tournament data and logic.

## Key Components

*   **Models:** Located in the `TrackerLibrary/Models` directory, these classes represent the data entities of the application.
*   **DataAccess:** Located in the `TrackerLibrary/DataAccess` directory, these classes handle the interaction with the data sources (SQL database and text files).
*   **GlobalConfig.cs:** Manages global application settings, including database connection strings.