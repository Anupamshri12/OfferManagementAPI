-->Offer Management API

This project is a .NET Core 8 Web API designed to manage and retrieve promotional offers, including cashback and discount data.

------------------------------------------------------------------------------------------------------------------------------

Setup Instructions

- Download [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Download SQL Server (SSMS)
- Download Visual Studio 2022 Community(preffered) or VS Code

1. Clone the repository:-

  - git clone https://github.com/Anupamshri12/OfferManagementAPI.git
  - cd OfferManagementAPI

2. NuGet packages:-

  - dotnet add package Microsoft.EntityFrameworkCore
  - dotnet add package Microsoft.EntityFrameworkCore.SqlServer
  - dotnet add package Microsoft.EntityFrameworkCore.Tools
  - dotnet add package Microsoft.EntityFrameworkCore.Design
  - dotnet add package Microsoft.Data.SqlClient
  - dotnet add package Newtonsoft.Json
  - dotnet add package Microsoft.Net.Http

3. Setup the ConnectionString in appsettings.json:->
    
  - "ConnectionStrings": {
      "DefaultConnection": "Data Source=localhost\\SQLEXPRESS;User Id= Your_UserName;Password = Your_Password;Initial Catalog=Your_DB; Encrypt=True; TrustServerCertificate=True"
     }
  
3. Add Migrations:-(It will create tables in OfferDatabase)
  - If migrations are already there delete the folder of it.
  - dotnet tool install --global dotnet-ef
  - dotnet ef migrations add InitialCreate
  - dotnet ef database update

4. Run the API:->

  - dotnet build
  - dotnet run

------------------------------------------------------------------------------------------------------------------------------
ASSUMPTIONS MADE:-

1. Offers are uniquely identified by adjustmentId, which is set as the primary key in the database. This ensures that duplicate or repeated offers are not stored multiple times.

2. Offer Types: Only flat discounts and cashback offers are parsed and considered. 

3. Used REGEX Parsing method to extract the discounts and cashbacks made (ex-> 5% cashback , upto 500 off, minimum order 500 etc.)

4. Offers are stored as flat entities without relational normalization.

5. A single bank can have multiple offers, and all are considered valid.

6. Assumed Banks , emi-months etc. can be empty .

------------------------------------------------------------------------------------------------------------------------------

DESIGN CHOICES:->

1. Used .NET CORE 8 framework : Lightweight ,modern ,scalable and highly secured.

2. Used SQL SERVER as database: Data is in organized way, supports all database operations ,easy of setup and connection ,supports migrations ,stored procedures ,Familiarity.

3. Used Migrations and Enitity Framework core which helps in-> interacting with database and operations and wrote optimised queries.

4. Used different layers to keep different part of code for testability and separation of concerns making more readable , modular and secure.

5. Layers added--> Controllers ,Services ,Interfaces ,DAO(Database Access Object) ,Entities ,Models ,DTOs.

6. Used Dependency Injection (design pattern which reduces tight coupling) helping injecting services easily.

7. Used Swagger for testing out the RESTAPIs .

------------------------------------------------------------------------------------------------------------------------------

Scale the GET /highest-discount endpoint to handle 1,000 requests per second-->

1. Add Caching: Use in-memory caching (IMemoryCache or Redis) for frequently accessed offers.

2. Optimize Regex: Compile and reuse regex patterns.

3. RateLimiting and Throttling -> Limit from overuse the APIs

4. Add indexes on searchable fields (like Banks, AdjustmentType).

5. Make Database calls async for better concurrency handling.

6. Horizontal Scaling: Use container orchestration (Kubernetes) and load balancers.

7. Load Offers in bulk and cache them.

8. Use DTOs(Data transfer object) to avoid unnecessary representation of colums.

------------------------------------------------------------------------------------------------------------------------------

Improvements id had more time:-

1. Implement Exception handling middleware to handle exceptions by providing custom exception.

2. Implement caching using Redis for scalability.

3. Add unit and integration test for testing.

4. Implement RateLimiting or Throttling for limiting the use of APIs.

5. Use Async for better concurrency handling.


