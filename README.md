# Tournament Tracker

This project is a Tournament Tracker application designed to manage tournaments, teams, players, prizes, and matchups. It is built using C# with .NET, employing Windows Forms for the user interface and MySQL for the database.

## Project Status

### Overall Progress

The project has established its foundational components, including the database schema, core data models, and the basic structure for the data access layer and user interface.

*   **Database:** Migrated to MySQL, with all tables and core stored procedures implemented. See `Database/README.md` for details.
*   **TrackerLibrary:** Core models and data access structure are in place. The `SqlConnector` (for MySQL) and `TextConnector` (for flat files) have been fully implemented. See `TrackerLibrary/README.md` for details.
*   **TrackerUI:** UI forms have been created and their core logic has been implemented and connected to the `TrackerLibrary`. Users can now create tournaments, teams, and prizes. Significant UI refinements have been made to `TournamentDashboardForm` and `TournamentViewerForm` for improved user experience. See `TrackerUI/README.md` for details.

### Next Steps (High-Level)

1.  **Implement Advanced Business Logic (`TrackerLibrary`):** Focus on developing advanced tournament management features, such as automated matchup generation, scoring systems, and round progression logic.
2.  **Enhance UI Functionality (`TrackerUI`):** Continue refining existing forms, fully implement tournament viewing/management dashboards (especially `TournamentViewerForm`), and improve overall user experience. Recent enhancements include UI improvements in `TournamentDashboardForm` and `TournamentViewerForm`.
3.  **Thorough Testing:** Conduct comprehensive unit tests for the `TrackerLibrary` and integration/UI testing for the `TrackerUI` to ensure robustness and reliability.
4.  **Documentation and Refinement:** Update documentation and refine UI/UX based on testing and feedback.


## Project Structure

The project is organized into three main components:

*   **`/Database`**: Contains the MySQL database schema (`TournamentTracker.sql`) and detailed documentation in its `README.md`. This includes setup instructions and information about the stored procedures.
*   **`/TrackerLibrary`**: A .NET class library that houses the business logic, data models (e.g., `TournamentModel`, `TeamModel`, `PrizeModel`), and data access components (`SqlConnector`, `TextConnector`). Its `README.md` provides an overview of its structure and status.
*   **`/TrackerUI`**: A Windows Forms application that serves as the graphical user interface for the Tournament Tracker. Users can interact with this application to manage tournaments. Its `README.md` details the forms and their intended functionality.

## Getting Started

1.  **Database Setup:** Follow instructions in `Database/README.md` to set up the MySQL database.
2.  **Configure Connection Strings:** Update the `appsettings.json` files in both `TrackerLibrary` and `TrackerUI` projects with your MySQL database credentials.
3.  **Build the Solution:** Open the solution in Visual Studio (or your preferred IDE) and build all projects.
4.  **Run the Application:** Set `TrackerUI` as the startup project and run it.

## Contribution

Currently, this project is under active development. Future contributions will be considered once the core functionalities are stable.