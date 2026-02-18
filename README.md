Vehicle Inventory Microservice
# Architecture Overview
  - This project implements a Vehicle Inventory microservice using Clean Architecture and Domain-Driven Design (DDD) principles.
  - The service belongs to the Inventory bounded context of a car rental platform and is responsible for managing vehicles, their locations, and their status.
  - The architecture enforces a strict separation of concerns and a one-directional dependency flow to ensure maintainability, testability, and scalability.
  
# Clean Architecture Layers
  - The solution is structured into four logical layers:

# Domain Layer
  - Contains the core business logic and domain rules
  - Defines the Vehicle aggregate root and domain enums
  - Enforces all vehicle lifecycle and status transition rules
  - Has no dependencies on frameworks or infrastructure
  
# Application Layer
  - Orchestrates use cases and workflows
  - Defines repository interfaces and DTOs
  - Calls domain behavior methods to enforce business rules
  - Contains no ASP.NET Core or EF Core dependencies
  
# Infrastructure Layer
  - Handles persistence and database access
  - Implements repository interfaces using Entity Framework Core
  - Has no business logic
  
# WebAPI Layer
  - Exposes RESTful HTTP endpoints
  - Handles request/response mapping and dependency injection
  - Delegates all logic to the Application layer
  - Contains no domain or EF Core logic
  - Domain Model and Business Rules

# Vehicle Aggregate
  - The Vehicle entity represents a vehicle in the inventory and is the aggregate root for the Inventory bounded context.

# Core Properties
  - Id
  - VehicleCode
  - LocationId
  - VehicleType
  - Status
  
#Domain Behavior Methods
  - MarkAvailable()
  - MarkReserved()
  - MarkRented()
  - MarkServiced()

# Business Rules Enforced in the Domain
  - A vehicle cannot be rented if it is already rented
  - A vehicle cannot be rented if it is reserved
  - A vehicle cannot be rented if it is under service
  - A reserved vehicle cannot be marked as available without explicit release
  - All status transitions are validated within the entity
  - Invalid state changes throw domain exceptions
  - All business rules are enforced inside the Domain layer, not in controllers, repositories, or EF Core.

# Run Instructions
  - Clone the repository
  - Open the solution in Visual Studio
  - Update the database connection string in appsettings.json
  - Update-Database
  - Run the WebAPI project

# Open Swagger UI: (https://localhost:7123/swagger/index.html)

# Known Limitations
  - Authentication and authorization are not implemented
  - Reservations, payments, and customer management are handled by other services
  - Vehicle locations and types are managed using identifiers only
  - No inter-service communication is implemented
