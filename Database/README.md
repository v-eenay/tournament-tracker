# Tournament Tracker Database Setup

This folder contains the SQL script to set up the database for the Tournament Tracker application.

## Prerequisites

- MySQL Server (e.g., version 8.0 or later)
- MySQL Workbench or a similar MySQL management tool (e.g., DBeaver, HeidiSQL)

## Setup Instructions

1. Ensure your MySQL server is running.
2. Open MySQL Workbench or your preferred MySQL management tool.
3. Connect to your MySQL server instance (usually localhost, port 3306).
4. Open the `TournamentTracker.sql` script (note: this script will need to be converted to MySQL syntax).
5. Execute the script to create the `Tournaments` database and all required tables and stored procedures.

## Database Schema

The script will create the following:

- **Tournaments** database
- Tables:
  - Prizes
  - People
  - Teams
  - TeamMembers
  - Tournaments
  - TournamentPrizes
  - TournamentEntries
  - MatchupRounds
  - Matchups
  - MatchupEntries
- Stored Procedures:
  - spPrizes_Insert

## Connection String

The application will be configured to use a MySQL connection string. An example format is:

```
Server=localhost;Port=3306;Database=Tournaments;Uid=your_mysql_username;Pwd=your_mysql_password;
```

This connection string needs to be updated in the `appsettings.json` files in both the TrackerLibrary and TrackerUI projects. Replace `your_mysql_username` and `your_mysql_password` with your actual MySQL credentials.
