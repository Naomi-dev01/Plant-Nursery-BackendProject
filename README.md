# Plant Nursery Web API

## Project Description
This project is built using the **three-layer architecture** in **.NET Core**.  
It allows customers to:
- Register on the website
- Log in with a username
- Update their user information
- Create orders
- Delete orders

The project follows a layered approach:
- **Presentation Layer / API**: Handles HTTP requests and responses in JSON format.
- **Business Layer / Services**: Contains the application’s business logic.
- **Data Layer / Repositories**: Handles data access using Entity Framework.
- **DTOs**: Used for transferring data between layers and to the frontend.

## Requirements
- .NET Core 6 or later
- SQL Server (or any compatible database)
- Visual Studio or VS Code

## Installation and Running
1. **Clone the repository:**
   ```bash
   git clone https://github.com/Naomi-dev01/Plant-nursery-BackendProject.git
2. Open the solution in Visual Studio

3. Update appsettings.json with your database connection

4. Apply database migrations:
dotnet ef database update

5. Run the API:
dotnet run

## Available Endpoints
Users
POST /api/users/register – Register a new user

POST /api/users/login – Log in a user

PUT /api/users/{id} – Update user information

Orders
POST /api/orders – Create a new order

DELETE /api/orders/{id} – Delete an existing order

GET /api/orders/{userId} – Get all orders for a specific user

All endpoints return JSON responses.

## Future Improvements
-Add authentication and authorization using JWT

-Integrate chatbot and AI agents

-Enhance order management and inventory features

5ץ 
