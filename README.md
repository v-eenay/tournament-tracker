# Tournament Tracker

This project is a Tournament Tracker application designed to manage tournaments, teams, players, prizes, and matchups. It is built using C# with .NET, employing Windows Forms for the user interface and MySQL for the database.

## Project Status

### Overall Progress

The project has established its foundational components, including the database schema, core data models, and the basic structure for the data access layer and user interface.

*   **Database:** Migrated to MySQL, with all tables and core stored procedures implemented. See `Database/README.md` for details.
*   **TrackerLibrary:** Core models and data access structure are in place. The `SqlConnector` (for MySQL) and `TextConnector` (for flat files) have been fully implemented. See `TrackerLibrary/README.md` for details.
*   **TrackerUI:** Basic forms have been created. Implementation of form logic and connection to the library is in progress. See `TrackerUI/README.md` for details.

### Next Steps (High-Level)

1.  **Implement Core Business Logic (`TrackerLibrary`):** With the data access layer complete, the next step is to develop the logic for tournament management, matchup generation, scoring, etc.
2.  **Develop UI Functionality (`TrackerUI`):** Implement the full functionality for all forms, including data binding, event handling, and user interaction workflows.
3.  **Thorough Testing:** Conduct unit tests for the library and comprehensive integration and UI testing for the entire application.
4.  **Refinement:** Iterate on UI/UX based on testing and feedback.


## Project Structure

The project is organized into three main components:

*   **`/Database`**: Contains the MySQL database schema (`TournamentTracker.sql`) and detailed documentation in its `README.md`. This includes setup instructions and information about the stored procedures.
*   **`/TrackerLibrary`**: A .NET class library that houses the business logic, data models (e.g., `TournamentModel`, `TeamModel`, `PrizeModel`), and data access components (`SqlConnector`, `TextConnector`). Its `README.md` provides an overview of its structure and status.
*   **`/TrackerUI`**: A Windows Forms application that serves as the graphical user interface for the Tournament Tracker. Users can interact with this application to manage tournaments. Its `README.md` details the forms and their intended functionality.

## Getting Started

1.  **Database Setup:** Follow the instructions in `Database/README.md` to set up the MySQL database.
2.  **Configure Connection Strings:** Update the `appsettings.json` files in both `TrackerLibrary` and `TrackerUI` projects with your MySQL database credentials.
3.  **Build the Solution:** Open the solution in Visual Studio (or your preferred IDE) and build all projects.
4.  **Run the Application:** Set `TrackerUI` as the startup project and run it.

## Contribution

Currently, this project is under active development. Future contributions will be considered once the core functionalities are stable.