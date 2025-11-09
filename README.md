# ARCA ERP

This is the repository for the ARCA ERP system, a comprehensive ERP solution built with a modern technology stack.

## Project Overview

*   **Backend:** ASP.NET Core 8.0 MVC + Web API
*   **Frontend:** React.js (with TypeScript and Material-UI)
*   **Database:** Microsoft SQL Server
*   **Architecture:** Clean Architecture

## Prerequisites

### Backend

*   [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
*   [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Frontend

*   [Node.js](https://nodejs.org/) (which includes npm)

## Getting Started

### Backend Setup

1.  **Clone the repository:**
    ```bash
    git clone <repository-url>
    cd <repository-directory>
    ```

2.  **Configure the database connection:**
    The project uses a user secret to store the database connection string. To set this up, navigate to the `Presentation` directory and run the following command, replacing the placeholder with your actual connection string:
    ```bash
    cd Presentation
    dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=your_server;Database=ARCAERP;User Id=your_user;Password=your_password;"
    cd ..
    ```

3.  **Apply database migrations:**
    The application uses Entity Framework Core migrations to manage the database schema. To apply the migrations and create the database, run the following command from the root directory:
    ```bash
    dotnet ef database update --project Infrastructure --startup-project Presentation
    ```

4.  **Run the backend server:**
    Navigate to the `Presentation` directory and run the application:
    ```bash
    cd Presentation
    dotnet run
    ```
    The backend server will start, typically on `http://localhost:5000` or `https://localhost:5001`.

### Frontend Setup

1.  **Navigate to the frontend directory:**
    ```bash
    cd arca-erp-frontend
    ```

2.  **Install dependencies:**
    ```bash
    npm install
    ```

3.  **Start the frontend development server:**
    ```bash
    npm start
    ```
    The frontend application will open in your browser at `http://localhost:3000`.

## Project Structure

### Backend

The backend follows the principles of Clean Architecture, with the following project structure:

*   **Core/Domain:** Contains the core entities and business logic of the application.
*   **Core/Application:** Contains application-specific logic, such as services and interfaces.
*   **Infrastructure:** Contains the implementation of the services defined in the Application layer, such as database access and external integrations.
*   **Presentation:** The entry point of the application, which includes the Web API controllers.

### Frontend

The frontend is a React application with the following structure:

*   **src:** Contains the source code for the React application.
*   **src/components:** Contains reusable UI components.
*   **src/pages:** Contains the main pages of the application.
*   **src/services:** Contains the logic for making API calls to the backend.
