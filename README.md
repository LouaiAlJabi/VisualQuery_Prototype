### VisualQuery_Prototype

# Overview
VisualQuery_Prototype is a simple C# application that allows users to interactively execute SQL queries on an in-memory SQLite database. The app uses Raylib for graphics rendering, providing a user-friendly interface to visualize the results of SQL queries on a pre-defined data table.

# Features
Create and visualize a simple data table with ID, Name, and Value columns.
Execute custom SQL queries using an interactive text box.
Dynamically display query results in a structured table format.
Intuitive keyboard controls for entering queries.

# Getting Started

**Prerequisites**
* .NET SDK (version 5.0 or later)
* Raylib (installed via NuGet)
* Microsoft.Data.Sqlite (installed via NuGet)

# Installation
Clone the repository:
```bash
git clone <repository-url>
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
    * Other printable ASCII characters, except digits, _, ;, * (work in progress)
* Viewing Results: Query results will replace the current data table displayed in the window.




