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
*   Basic structure for data access (`IDataConnection`, `SqlConnector`, `TextConnector`).
*   Global configuration setup (`GlobalConfig.cs`).

### In Progress

*   Implementation of data access logic within `SqlConnector.cs` to interact with the MySQL database using stored procedures.
*   Implementation of data access logic for text file storage in `TextConnector.cs`.
*   Refinement of data models as development progresses.

### Next Steps

1.  **Complete `SqlConnector` Implementation:** Finish implementing all methods to save and retrieve data for all models using the defined stored procedures.
2.  **Complete `TextConnector` Implementation:** Finish implementing all methods to save and retrieve data for all models using text files.
3.  **Implement Business Logic:** Add business logic for tournament creation, team management, matchup generation, score recording, and prize distribution.
4.  **Unit Testing:** Develop unit tests for data access methods and business logic components.
5.  **Integration with `TrackerUI`:** Ensure seamless integration with the UI layer for data flow and user interactions.

## How to Use

This library is intended to be referenced by the `TrackerUI` project or any other presentation layer that needs to interact with the tournament data and logic.

## Key Components

*   **Models:** Located in the `TrackerLibrary/Models` directory, these classes represent the data entities of the application.
*   **DataAccess:** Located in the `TrackerLibrary/DataAccess` directory, these classes handle the interaction with the data sources (SQL database and text files).
*   **GlobalConfig.cs:** Manages global application settings, including database connection strings.