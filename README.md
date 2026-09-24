# Student Management REST API

C# and ASP.NET Core were used to create a REST API for student management.
The program uses a SQL Server relational database to manage enrollments, departments, courses, and students.

## Technology Applied
 - C#
 - ASP.NET Fundamental Web API Core of the Entity Framework
 - SQL Server
 - The SQL Server Management Studio (SSMS)
 - Open API and Swagger
 - GitHub and Git

## Features
 - Create, view, update, and delete student
 -  Create, view, update, and delete courses
 -  Control academic departments
 -  Enroll students in courses
 -  Assign students to departments
 -  Assign courses to departments
 -  Verify the relationships between students and courses prior to enrollment
 -  Use SQL Server to store and manage data.
 -  Use Swagger UI to test API endpoints.

## Endpoints for APIs

### Students
-  GET/api/students
-  GET/api/students-{id}
-  POST/api/students
-  PUT/api/students-{id}
-  DELETE/api/students-{id}

### Courses
 - GET/api/courses
 - GET/api/courses-{id}
 - POST/api/courses
 - PUT/api/courses-{id}
 - DELETE/api/courses-{id}

### Departments
  - GET/api/departments
  - GET/api/departments-{id}
  - POST/api/departments
  - PUT/api/departmets-{id}
  - DELETE/api/departmets-{id}

### Enrollments
  - GET/api/enrollments
  - GET/api/enrollments-{id}
  - POST/api/enrollments
  - PUT/api/enrollments-{id}
  - DELETE/api/enrollments-{id}

## Database Relationship
Relationships between the database entities are managed by the application using Entity Framework Core.
 - There may be more than one student in a  department.
 - A department may offer more than one course.
 - Through the Enrollment entity, a student can sign up for classes.
 - A student's enrollment links them to a course.

## Database
SQL Server and Entity Framework Core migrations are used in the project.

Main database tables:
 - Students
 - Courses
 - Departments
 - Enrollments
The database can be examined and managed using SQL Server Management Studio (SSMS).


## Swagger / OpenAPI
REST API endpoints are used for testing the Swagger UI and which can also be viewed.

While the application is being developed, Swagger can be viewed at: "https://localhost:<port>/swagger"

##  Executing the Project
 1. Make a copy of the repository.
 2. Launch Visual Studio ad open the solution.
 3. In "appsettings.json", set up the SQL Server connection string.
 4. For Entity Framework Core implement the migrations.
 5. Manage and construct the project.
 6. To test the API endpoints, launch Swagger.

## Development Assisted by AI
- ChatGPT was utilized to help troubleshoot code and migration mistakes.
- It was also used to provide guidance and comprehend the migration errors, ASP.NET core and REST API Concepts.
