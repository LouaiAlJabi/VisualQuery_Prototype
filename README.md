### VisualQuery_Prototype

# Overview
VisualQuery_Prototype is a simple C# application that allows users to interactively execute SQL queries on an in-memory SQLite database. The app uses Raylib for graphics rendering, providing a user-friendly interface to visualize the results of SQL queries on a pre-defined data table.

# Features
* Dynamic Table Creation: Initializes a data table with sample data.
* SQL Query Execution: Users can input SQL queries, which are executed against an in-memory SQLite database.
* Visual Feedback: The application visually displays the results of the executed queries.
  
# Getting Started

**Prerequisites**
* .NET SDK (version 5.0 or later)
* Raylib (installed via NuGet)
* Microsoft.Data.Sqlite (installed via NuGet)

# Installation
Clone the repository:
```bash
git clone https://github.com/LouaiAlJabi/VisualQuery_Prototype.git
```

Navigate to the project directory:
```bash
cd VisualQuery_Prototype
```

Restore dependencies:
```bash
dotnet restore
```

Build the project:
```bash
dotnet build
```

Running the Application
```bash
dotnet run
```

The application window will open, displaying a table with default data. You can enter SQL queries in the text box at the bottom.

# Usage

* Entering Queries: Type your SQL query into the text box. You can use the following keys:
    * Enter: Execute the current query.
    * Backspace: Remove the last character from the query.
    * Space: Insert a space character.
    * Other printable ASCII characters, except digits, _, ;, * (still work in progress)
* Viewing Results: Query results will replace the current data table displayed in the window.


# Code Overview

* Main Class: The entry point of the application where the Raylib window is initialized.
* Data Table: A 2D list is created to hold sample data. This is then converted to a DataTable for SQL operations.
* Database Connection: An in-memory SQLite database is used to execute SQL commands.
* User Input Handling: The application captures keyboard input to build SQL queries and executes them on pressing Enter.
* Rendering: The user interface is drawn each frame, showing the current state of the data table and the input box.


Acknowledgments

* Raylib - for the graphics rendering.
* Microsoft.Data.Sqlite - for SQLite database interactions.
* Hunter Dyar - for guidance on the project

