# Customer Management API

## Introduction
Customer Management API is a web application designed to manage customers, their orders, and related data. It provides a set of RESTful API endpoints to perform CRUD operations on customers, orders, and associated entities.

## Installation
1. Clone the repository to your local machine.
2. Navigate to the project directory.
3. Run `dotnet restore` to install the necessary packages.
4. Set up the database connection in the `appsettings.json` file.
5. Run `dotnet ef database update` to apply migrations and create the database schema.
6. Run the application using `dotnet run`.
7. The API will be available at `https://localhost:<port>/api`.

## Endpoints
### CustomersController
- **GET /api/customers**: Retrieve all customers.
- **GET /api/customers/{id}**: Retrieve a specific customer by ID.
- **POST /api/customers**: Add a new customer.
- **PUT /api/customers**: Update an existing customer.
- **DELETE /api/customers/{id}**: Delete a customer by ID.

### OrdersController
- **GET /api/orders/{id}**: Retrieve a specific order by ID.
- **GET /api/orders**: Retrieve orders for a specific customer.
- **PUT /api/orders**: Update an existing order.
- **POST /api/orders**: Add a new order.

### UserController
- **POST /api/user/login**: User login authentication.
- **POST /api/user/register**: User registration.

## Usage
### Sample Requests and Responses
1. **Retrieve All Customers**
   - **Request**: `GET /api/customers`
   - **Response**: 
     ```json
     [
       {
         "id": 1,
         "name": "John Doe",
         "email": "john.doe@example.com",
         ...
       },
       ...
     ]
     ```

2. **Add New Customer**
   - **Request**: `POST /api/customers`
     ```json
     {
       "name": "Jane Smith",
       "email": "jane.smith@example.com",
       ...
     }
     ```
   - **Response**: `HTTP 200 OK`

3. **Retrieve Order by ID**
   - **Request**: `GET /api/orders/1`
   - **Response**:
     ```json
     {
       "id": 1,
       "customerId": 1,
       "orderDate": "2024-05-19T12:00:00",
       ...
     }
     ```

4. **User Login**
   - **Request**: `POST /api/user/login`
     ```json
     {
       "username": "user123",
       "password": "password123"
     }
     ```
   - **Response**: 
     ```json
     {
       "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
     }
     ```

## Technologies Used
- C#
- ASP.NET Core
- Entity Framework Core
- Microsoft SQL Server
- JWT Authentication

