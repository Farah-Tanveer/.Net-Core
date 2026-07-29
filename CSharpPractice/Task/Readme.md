# Student Management System

A C# console application that manages student records and grades using Microsoft SQL Server. Built as part of an internship training at NKU Technologies.

---

## Features

- Add students with grades for 5 subjects
- Display all students with subject-wise grades
- Search students by name
- Generate grade report with pass/fail status and class average
- Input validation for grades (0–100 range)
- SQL injection prevention using parameterized queries

---

## Tech Stack

- Language: C# (.NET 8)
- Database: Microsoft SQL Server
- Library: Microsoft.Data.SqlClient
- IDE: Visual Studio 2022

---

## Database Schema

### Students Table
```sql
CREATE TABLE Students (
    StudentId INT PRIMARY KEY IDENTITY(1,1),
    Name      NVARCHAR(100) NOT NULL,
    Class     NVARCHAR(50),
    Section   NVARCHAR(10)
);
```

### Subjects Table
```sql
CREATE TABLE Subjects (
    SubjectId   INT PRIMARY KEY,
    SubjectName NVARCHAR(100) NOT NULL
);

INSERT INTO Subjects VALUES (1, 'Math');
INSERT INTO Subjects VALUES (2, 'Physics');
INSERT INTO Subjects VALUES (3, 'Chemistry');
INSERT INTO Subjects VALUES (4, 'English');
INSERT INTO Subjects VALUES (5, 'Computer');
```

### StudentGrades Table
```sql
CREATE TABLE StudentGrades (
    GradeId   INT PRIMARY KEY IDENTITY(1,1),
    StudentId INT FOREIGN KEY REFERENCES Students(StudentId),
    SubjectId INT FOREIGN KEY REFERENCES Subjects(SubjectId),
    Grade     FLOAT NOT NULL
);
```

---

## Project Structure

```
StudentManagementSystem/
├── Program.cs       — main menu loop and all database functions
└── Student.cs       — Student class with properties and methods
```

### Student Class Methods

| Method | Description |
|---|---|
| `AddGrade(subject, grade)` | Dynamically adds a subject and grade to the student |
| `CalculateAverage()` | Returns average of all grades |
| `GetLetterGrade()` | Returns A/B/C/D/F based on average |
| `HasPassed()` | Returns true if average is 40 or above |
| `DisplayInfo()` | Prints all student details to console |

---

## How to Run

### Prerequisites
- Visual Studio 2022
- SQL Server 2022 (Developer Edition)
- SQL Server Management Studio (SSMS)

### Setup Steps

**1. Create the database in SSMS:**
- Open SSMS and connect to your server
- Right click Databases → New Database → name it `StudentManagementDB`
- Run the SQL schema above to create all three tables

**2. Update connection string in Program.cs:**
```csharp
string connectionString =
    "Server=YOUR_SERVER_NAME;Database=StudentManagementDB;Trusted_Connection=True;TrustServerCertificate=True;";
```
Replace `YOUR_SERVER_NAME` with your actual server name (visible in SSMS connection dialog).

**3. Install NuGet package:**
```
Microsoft.Data.SqlClient
```

**4. Run the project in Visual Studio (F5)**

---

## Menu Options

```
1. Add Student       — enter name, class, section and grades for 5 subjects
2. Display Students  — shows all students with subject grades and average
3. Search by Name    — partial name search, case insensitive
4. Generate Report   — summary table with grades, pass/fail, class average
5. Exit
```

---

## Grade System

| Average | Letter Grade | Status |
|---|---|---|
| 90 – 100 | A | PASS |
| 80 – 89  | B | PASS |
| 70 – 79  | C | PASS |
| 40 – 69  | D | PASS |
| Below 40 | F | FAIL |

---

## Key Concepts Used

- Object Oriented Programming — separate Student class with encapsulation
- ADO.NET — SqlConnection, SqlCommand, SqlDataReader
- Parameterized queries — prevents SQL injection
- Dictionary — groups multiple database rows into single Student objects
- Exception safe connections — using blocks auto-close database connections
- INNER JOIN — combines Students, StudentGrades, and Subjects tables
- OUTPUT INSERTED — captures auto-generated StudentId after insert

---

## Author

**Farah Tanveer**
CS Student — PUCIT-FCIT, University of the Punjab (2024–2028)
Web Development Intern — NKU Technologies, Lahore
GitHub: [github.com/Farah-Tanveer](https://github.com/Farah-Tanveer)
Portfolio: [farahtanveer.tech](https://farahtanveer.tech)