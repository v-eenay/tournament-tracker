# Tournament Tracker Database Setup

This folder contains the SQL script to set up the database for the Tournament Tracker application.

## Prerequisites

- SQL Server 16.0.1135.2 or later
- SQL Server Management Studio (SSMS) or Azure Data Studio

## Setup Instructions

1. Open SQL Server Management Studio (SSMS) or Azure Data Studio
2. Connect to your SQL Server instance (Server name: VEENAY)
3. Open the `TournamentTracker.sql` script
4. Execute the script to create the database and all required tables and stored procedures

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

The application is configured to use the following connection string:

```
Server=VEENAY;Database=Tournaments;Trusted_Connection=True;TrustServerCertificate=True;
```

This connection string is stored in the `appsettings.json` files in both the TrackerLibrary and TrackerUI projects.
