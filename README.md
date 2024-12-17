# Multi-Tenant Architecture in ASP.NET Core

## Overview
This project demonstrates a **multi-tenant architecture** in ASP.NET Core, where tenants are isolated by a unique `TenantId`. The system ensures that each tenant only accesses their respective data, providing a scalable and efficient way to handle multiple tenants in a single application.

![Tenant Architecture](images/tenant-architecture.png)

By implementing tenant isolation and tenant-aware data access, this solution can manage multiple tenants on a single platform without data leakage between them.

## Features
- **Tenant Isolation**: Each tenant has its data, accessible only by the respective tenant, ensuring security and privacy.
- **Tenant-Aware Data Access**: Requests are filtered by the tenant identifier, ensuring that only data relevant to the tenant is returned.
- **Custom Middleware**: A middleware is used to resolve the tenant based on the incoming request and ensures tenant-specific context throughout the application.

![Feature Diagram](images/feature-diagram.png)

## Technologies Used
- **ASP.NET Core**: The core framework for building the RESTful API and handling HTTP requests.
- **Entity Framework Core**: Provides ORM capabilities to interact with the SQL Server database.
- **SQL Server**: Stores tenant-specific data securely, where each tenant has its unique identifier (`TenantId`).
- **Swagger**: For API documentation, allowing easy exploration and testing of endpoints.

## API Endpoints

### 1. Get All Products by TenantId
- **Method**: `GET`
- **URL**: `/api/Product?tenantId={tenantId}`
- **Description**: Retrieves all products that belong to a specified tenant. The request filters products based on the provided `tenantId` to ensure tenant isolation.
  
![API Diagram](images/fullapi.png)

