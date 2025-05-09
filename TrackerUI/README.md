# TrackerUI

## Overview

This project is a Windows Forms application that provides the user interface for the Tournament Tracker. It allows users to create and manage tournaments, teams, players, prizes, and view tournament progress.

## Project Status

### Completed

*   Initial setup of the Windows Forms project.
*   Basic UI forms created:
    *   `CreatePrizeForm`
    *   `CreateTeamForm`
    *   `CreateTournamentForm`
    *   `TournamentDashboardForm`
    *   `TournamentViewerForm`
*   Integration with `TrackerLibrary` for data access and business logic (initialization in `Program.cs`). The `TrackerLibrary` now has fully implemented `SqlConnector` and `TextConnector` for data operations.

### Completed

*   Implementation of core functionality within `CreatePrizeForm`, `CreateTeamForm`, and `CreateTournamentForm`, including data binding, event handling, and connection to `TrackerLibrary` for creating entities.
*   Basic functionality for `TournamentDashboardForm` to display a list of tournaments and navigate to creation forms.
*   Initial setup and wiring for `TournamentViewerForm`, with recent UI refinements to improve user experience.
*   UI refinements made to `TournamentDashboardForm` for better navigation and usability.

### Next Steps

1.  **Enhance `TournamentViewerForm`:** Continue to fully implement the display of tournament brackets, matchups, scores, and enable score entry and progression through rounds. Initial UI refinements have been completed.
2.  **Refine `TournamentDashboardForm`:** Continue to add functionality to load and display details of existing tournaments, and allow users to select a tournament to view in `TournamentViewerForm`. Initial UI refinements have been completed.
3.  **Implement Edit/Delete Functionality:** Add capabilities to edit and delete existing tournaments, teams, and prizes through the UI.
4.  **Advanced Data Validation and Error Handling:** Implement comprehensive input validation and user-friendly error messages across all forms.
5.  **UI/UX Polish:** Refine the overall user interface and experience, focusing on intuitiveness and visual appeal.
6.  **Comprehensive UI Testing:** Conduct thorough testing of all UI workflows, interactions with the `TrackerLibrary`, and edge cases.

## How to Run

1.  Ensure the `TrackerLibrary` (with its completed data connectors) is built and its dependencies are correctly referenced.
2.  Ensure the database (MySQL) is set up as per the `Database/README.md` and `TournamentTracker.sql` schema.
3.  Update `appsettings.json` with the correct database connection string if necessary.
4.  Build and run the `TrackerUI` project from Visual Studio or using the .NET CLI.

## Key Forms

*   **`CreatePrizeForm.cs`**: Allows users to define new prizes for tournaments.
*   **`CreateTeamForm.cs`**: Allows users to create new teams and add members to them.
*   **`CreateTournamentForm.cs`**: The main form for setting up a new tournament.
*   **`TournamentDashboardForm.cs`**: The entry point after application startup, showing existing tournaments and allowing creation of new ones.
*   **`TournamentViewerForm.cs`**: Displays the tournament bracket, matchups, and scores.