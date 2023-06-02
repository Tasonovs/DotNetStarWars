# **DotNetStarWars**

DotNetStarWars is a project that aims to showcase the usage of ASP.NET Core, EF Core, MediatR, Refit, and the CQRS pattern in a Star Wars-themed application. This project provides a foundation for building a web application that interacts with the Star Wars API (SWAPI) and demonstrates best practices for structuring and implementing a .NET application.

## **Features**

- Retrieve information about Star Wars characters from SWAPI.
- Implement the CQRS pattern for better separation of concerns.
- Leverage MediatR for easy implementation of queries and commands.
- Use Refit to simplify the consumption of the SWAPI RESTful API.
- Store and retrieve data using EF Core for efficient data management.

## **Technologies Used**

- ASP.NET Core: A cross-platform framework for building web applications.
- Entity Framework (EF) Core: An object-relational mapper for .NET applications.
- MediatR: A simple mediator pattern implementation for .NET applications.
- Refit: A library for automatically generating type-safe REST API clients.
- CQRS pattern: Command Query Responsibility Segregation pattern for better separation of concerns.

## **Installation**

To run the DotNetStarWars project locally, make sure you have the following prerequisites installed:

- **[.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)**

Follow these steps to get started:

1. Clone the repository:
    
    ```
    git clone https://github.com/Tasonovs/DotNetStarWars.git
    ```
    
2. Navigate to the project directory:
    
    ```
    cd DotNetStarWars
    ```
    
3. Build the project:
    
    ```
    dotnet build
    ```
    
4. Run the application:
    
    ```
    dotnet run
    ```
    
    The application will start and be accessible at **`http://localhost:5244`** (and **`http://localhost:5244/swagger`** for API documentation).
    

## **Acknowledgements**

- **[Star Wars API (SWAPI)](https://swapi.dev/)**: The source of Star Wars-related data used in this project.
- **[ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)**: Official documentation for ASP.NET Core.
- **[Entity Framework Core Documentation](https://docs.microsoft.com/ef/core)**: Official documentation for EF Core.
- **[MediatR Documentation](https://github.com/jbogard/MediatR/wiki)**: MediatR usage guidelines and examples.
- **[Refit Documentation](https://github.com/reactiveui/refit)**: Documentation for Refit library.
