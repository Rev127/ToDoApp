# ToDoApp

# ToDoApp

A full-stack To-Do application designed to help users manage their daily tasks in a simple and convenient way.

The project is built using a layered architecture with a separate client application, API, data access layer, and business logic/services.

## Overview

**ToDoApp** is a full-stack task management application that allows users to create and manage their tasks through a web-based client.

The application is divided into several independent projects:

- **ToDoApp.Client** — client-side application and user interface
- **ToDoApp.Api** — backend API responsible for handling HTTP requests
- **ToDoApp.Services** — business logic and application services
- **ToDoApp.Data** — data access layer and database functionality

## Project Architecture

### ToDoApp.Client

The client application provides the user interface for interacting with the task management system.

It is responsible for:

- Displaying tasks
- Creating new tasks
- Updating existing tasks
- Deleting tasks
- Communicating with the backend API

### ToDoApp.Api

The API layer provides HTTP endpoints used by the client application.

### ToDoApp.Services

The services layer contains the application's business logic.

This layer is responsible for:

- Task operations
- User operations
- Categories operations

### ToDoApp.Data

The data layer is responsible for communication with the application's data storage.

It provides functionality for:

- Updating data
- Deleting data

## Features

The application provides the core functionality required for task management:

- Create new tasks
- View existing tasks
- Update tasks
- Delete tasks
- Manage tasks through a web interface

## Technologies

This project was developed using the following tools:

- **Frontend** - Visual Studio Code (Angular/TypeScript/HTML/CSS/Bootstrap)
- **Backend** - Visual Studio 2026 (C#/.NET/ASP.NET Core/Entity Framework)
- **Database** - MySQL Server 8.0

## Getting Started

### Prerequisites

Before running the project, make sure you have the required development environment installed.

Depending on the project configuration, this may include:

- .NET SDK
- Node.js and npm
- A supported database (ex. MySQL Server 8.0)
- Git

### 1. Clone the repository

```bash
git clone https://github.com/Rev127/ToDoApp.git
cd ToDoApp
```

### 2. Configure the application

Before starting the application, configure the required connection strings and environment-specific settings.

Check the configuration files inside the API and data projects.

For example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_CONNECTION_STRING"
  }
}
```

### 3. Start the backend

Navigate to the API project:

```bash
cd ToDoApp.Api
```

Run the application:

```bash
dotnet run
```

The API will start on the URL configured by the project.

### 4. Start the client

Open a new terminal and navigate to the client project:

```bash
cd ToDoApp.Client
```

Install dependencies if required:

```bash
npm install
```

Then start the development server:

```bash
npm start
```

The client application will be available at the URL displayed in the terminal.
