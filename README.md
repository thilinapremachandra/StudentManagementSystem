# Student Management System

A desktop application built with C# and .NET Framework for managing student records with user authentication capabilities.

## Overview

The Student Management System is a Windows Forms application designed to help educational institutions manage student data efficiently. The system includes user authentication, registration capabilities, and basic CRUD operations for student records.

## Features

- **User Authentication**: Secure login system for authorized access
- **User Registration**: New users can create accounts to access the system
- **Student Management**:
  - Add new student records with name, address, and email
  - View all student records in a tabular format
  - Select and update existing student information
  - Delete student records with confirmation


## Technical Details

### Technologies Used

- **Language**: C# (.NET Framework)
- **UI Framework**: Windows Forms
- **Database**: Microsoft SQL Server (LocalDB)
- **IDE**: Visual Studio

### Database Structure

The application uses two main database tables:

1. **Login**: Stores user authentication information
   - Username (string)
   - Password (string)

2. **Students**: Stores student information
   - RegNo (int, auto-increment, primary key)
   - Name (string)
   - Address (string)
   - Email (string)

## Getting Started

### Prerequisites

- Visual Studio 2019 or newer
- .NET Framework 4.7.2 or newer
- SQL Server LocalDB or SQL Server Express

### Installation

1. Clone the repository or download the source code
2. Open the solution file (`StudentManagementSystem.sln`) in Visual Studio
3. Update the connection string in the files if necessary:
   ```csharp
   private string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=student;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
   ```
4. Create the required database schema using the following SQL commands:

```sql
CREATE DATABASE student;
GO

USE student;
GO

CREATE TABLE Login (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(50) NOT NULL
);

CREATE TABLE students (
    RegNo INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);
```

5. Build and run the application

## Usage

1. **Registration**: New users must register with a username and password
2. **Login**: Existing users can log in using their credentials
3. **Managing Students**:
   - Fill in the form fields and click "Add" to create a new student record
   - Click on any student in the data grid to load their details for viewing or editing
   - Select a student record and click "Delete" to remove a student

## Project Structure

- **LoginForm.cs**: Handles user authentication
- **Register.cs**: Manages new user registration
- **Main.cs**: The main application form for student management
- **Program.cs**: Application entry point

## Security Considerations

- The current implementation stores passwords in plain text, which is not recommended for production applications
- Consider implementing password hashing and additional security measures for a production environment

## Future Enhancements

- Add password hashing for improved security
- Implement role-based access control
- Add search functionality for student records
- Include student profile pictures
- Add reporting capabilities
- Enhance the UI with modern controls and themes
