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
*   Integration with `TrackerLibrary` for data access and business logic (initialization in `Program.cs`).

### In Progress

*   Implementing the full functionality within each form (data binding, event handling, validation).
*   Connecting UI elements to the corresponding `TrackerLibrary` methods for creating, reading, updating, and deleting data.
*   Designing and implementing the tournament bracket visualization on the `TournamentViewerForm`.
*   Developing the logic for the `TournamentDashboardForm` to display active tournaments and allow navigation.

### Next Steps

1.  **Complete `CreatePrizeForm`:** Implement logic to save new prize details.
2.  **Complete `CreateTeamForm`:** Implement logic to create new teams and add members.
3.  **Complete `CreateTournamentForm`:** Implement logic to create new tournaments, including selecting teams, setting up prizes, and generating initial matchups.
4.  **Develop `TournamentViewerForm`:** Implement the display of tournament brackets, matchups, scores, and allow for score entry.
5.  **Develop `TournamentDashboardForm`:** Implement functionality to load existing tournaments, navigate to the `TournamentViewerForm` for a selected tournament, and create new tournaments.
6.  **Data Validation and Error Handling:** Implement robust input validation and user-friendly error messages across all forms.
7.  **UI/UX Refinement:** Improve the overall look, feel, and usability of the application based on testing and feedback.
8.  **Thorough Testing:** Conduct comprehensive testing of all UI workflows and interactions with the `TrackerLibrary`.

## How to Run

1.  Ensure the `TrackerLibrary` is built and its dependencies are correctly referenced.
2.  Ensure the database (MySQL) is set up as per the `Database/README.md` and `TournamentTracker.sql` schema.
3.  Update `appsettings.json` with the correct database connection string if necessary.
4.  Build and run the `TrackerUI` project from Visual Studio or using the .NET CLI.

## Key Forms

*   **`CreatePrizeForm.cs`**: Allows users to define new prizes for tournaments.
*   **`CreateTeamForm.cs`**: Allows users to create new teams and add members to them.
*   **`CreateTournamentForm.cs`**: The main form for setting up a new tournament.
*   **`TournamentDashboardForm.cs`**: The entry point after application startup, showing existing tournaments and allowing creation of new ones.
*   **`TournamentViewerForm.cs`**: Displays the tournament bracket, matchups, and scores.