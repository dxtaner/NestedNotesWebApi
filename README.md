
Notes API
=========

Endpoints
---------

### GET /api/notes

Retrieves all the notes.

    GET /api/notes

### GET /api/notes/{id}

Retrieves a specific note by its ID.

    GET /api/notes/{id}

### POST /api/notes

Creates a new note.

    POST /api/notes

### DELETE /api/notes/{id}

Deletes a note and its child comments recursively.

    DELETE /api/notes/{id}

Error Handling
--------------

If an error occurs while processing a request, the API will respond with an appropriate error message and status code.

    {
      "message": "Internal server error: An exception occurred.",
      "status": 500
    }

Database
--------

The API uses a database to persist notes and comments. The connection string and database provider are configured in the `appsettings.json` file.

Getting Started
---------------

1.  Clone the repository: `git clone https://github.com/your-username/notes-api.git`
2.  Navigate to the project directory: `cd notes-api`
3.  Restore the NuGet packages: `dotnet restore`
4.  Update the database connection string in `appsettings.json` if necessary.
5.  Apply the database migrations: `dotnet ef database update`
6.  Run the API: `dotnet run`
7.  The API will be accessible at `http://localhost:5000/api/notes`

Dependencies
------------

The API depends on the following NuGet packages:

*   Microsoft.AspNetCore.Mvc
*   Microsoft.EntityFrameworkCore

These packages will be automatically restored when you run the `dotnet restore` command.
