# C# and ASP.NET Core Learning Journey
### By Farah Tanveer — PUCIT-FCIT, University of the Punjab (2024–2028)

A structured self-learning repository documenting my progress through C# fundamentals, Object-Oriented Programming, database integration, and ASP.NET Core MVC web development.

---

## Repository Structure

```
CSharp-Learning/
├── Day1-Basics/
├── Day2-Strings/
├── Day3-Conditionals/
├── Day4-Loops/
├── Day5-Arrays-Lists/
├── Day6-Methods/
├── Day7-Classes-OOP/
├── Day8-Inheritance/
├── Day9-ExceptionHandling/
├── Day10-LINQ/
├── Day11-Interfaces/
├── Day12-Dictionary/
├── Day13-FileIO/
├── StudentManagementSystem/
└── StudentMVC/
```

---

## What I Learned

### C# Fundamentals
- Variables, data types, type conversion
- String methods and interpolation
- Conditionals — if/else, switch, ternary operator
- Loops — for, while, foreach, do-while
- Arrays and Lists
- Methods — void, return types, optional parameters, overloading

### Object-Oriented Programming
- Classes, constructors, properties
- Access modifiers — public, private
- The `this` keyword and static members
- Inheritance — base/derived classes, virtual and override
- Abstract classes and methods
- Sealed classes
- Polymorphism
- Interfaces

### Exception Handling
- try/catch/finally blocks
- Multiple catch blocks
- Custom exceptions
- throw keyword
- Common exceptions — NullReferenceException, ArgumentException, FormatException

### Collections
- List — Add, Remove, Contains, Count
- Dictionary — key/value pairs, TryGetValue, ContainsKey
- Iterating with foreach and LINQ

### LINQ
- Where, Select, OrderBy, OrderByDescending
- First, FirstOrDefault, MaxBy
- Any, All, Count, Sum, Average, Max, Min
- GroupBy and method chaining
- Anonymous types

### File I/O
- File.WriteAllText, File.ReadAllText
- File.WriteAllLines, File.ReadAllLines
- File.Exists for safe file access
- StreamWriter and StreamReader

---

## Projects Built

### 1. Student Management System (Console App + MSSQL)

A console-based student management application connected to Microsoft SQL Server using ADO.NET.

**Features:**
- Add students with grades for 5 subjects
- Display all students with subject-wise grades
- Search students by name
- Generate grade report with pass/fail status and class average
- Input validation for grades (0-100)
- SQL injection prevention using parameterized queries

**Tech Stack:** C#, ADO.NET, Microsoft SQL Server, SSMS

**Database Schema:**
```sql
Students      (StudentId, Name, Class, Section)
Subjects      (SubjectId, SubjectName)
StudentGrades (GradeId, StudentId, SubjectId, Grade)
```

**Key Concepts Applied:**
- OOP — separate Student class with encapsulation
- ADO.NET — SqlConnection, SqlCommand, SqlDataReader
- Parameterized queries for SQL injection prevention
- Dictionary for grouping JOIN results into single objects
- INNER JOIN across three tables
- OUTPUT INSERTED for capturing auto-generated IDs
- Foreign key relationships

---

### 2. StudentMVC (ASP.NET Core Web Application + MSSQL)

A full-stack web application built with ASP.NET Core MVC and Entity Framework Core.

**Features:**
- View all students in a Bootstrap table
- Add new students via web form
- Edit existing student records
- Delete students
- Data persists in Microsoft SQL Server

**Tech Stack:** ASP.NET Core MVC, Entity Framework Core, MSSQL, Bootstrap 5, Razor Views

**Project Structure:**
```
StudentMVC/
├── Controllers/
│   ├── HomeController.cs
│   └── StudentController.cs
├── Models/
│   └── Student.cs
├── Views/
│   └── Student/
│       ├── Index.cshtml
│       ├── Create.cshtml
│       └── Edit.cshtml
├── Data/
│   └── AppDbContext.cs
├── appsettings.json
└── Program.cs
```

**Key Concepts Applied:**
- MVC pattern — Model, View, Controller separation
- Entity Framework Core — Code First approach
- Migrations — Add-Migration, Update-Database
- DbContext and DbSet
- Dependency Injection
- Model Binding — form fields map to C# objects automatically
- IActionResult — View, RedirectToAction, NotFound
- Razor syntax — mixing C# with HTML using @
- Hidden fields for passing Id in edit forms
- LINQ — ToList, Find, FirstOrDefault

---

## Tools and Technologies

| Tool | Purpose |
|---|---|
| Visual Studio 2022 | Primary IDE |
| SQL Server 2022 Developer | Database engine |
| SSMS 22 | Database management GUI |
| .NET 8 | Runtime framework |
| Bootstrap 5 | Frontend styling |
| GitHub | Version control |

---

## Key Concepts Understood

### ADO.NET vs Entity Framework

| | ADO.NET | Entity Framework |
|---|---|---|
| SQL | Written manually | Generated automatically |
| Control | Full control | Convention based |
| Use case | Complex queries, legacy | Standard CRUD, MVC apps |

### MVC Pattern

```
Browser Request
      ↓
  Controller — handles request
      ↓
   Model — data and business logic
      ↓
   View — renders HTML
      ↓
Browser Response
```

### Entity Framework Flow

```
_context.Students.ToList()  →  SELECT * FROM Students
_context.Students.Add(s)    →  INSERT INTO Students
_context.Students.Remove(s) →  DELETE FROM Students
_context.SaveChanges()      →  commits to database
```

---

## What Is Next

- Stored Procedures with ADO.NET
- ASP.NET Core validation and data annotations
- Authentication and session management
- Bus Terminal Management System — full-stack .NET project

---

## Author

**Farah Tanveer**
CS Student — PUCIT-FCIT, University of the Punjab (2024–2028)
GitHub: github.com/Farah-Tanveer
Portfolio: farahtanveer.tech
