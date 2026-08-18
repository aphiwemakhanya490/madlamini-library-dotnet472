# 📚 MaDlamini Library Management System

A desktop-based Library Management System developed using **C# Windows Forms and .NET Framework 4.7.2**.

The application provides a simple interface for managing a library book catalogue, handling book selections/bookings, and controlling access through user authentication and role-based sessions.

---

## 📌 Project Overview

The **MaDlamini Library Management System** is a Windows desktop application designed to support basic library operations.

The system provides authenticated users with access to the library's book catalogue and booking functionality. It also maintains information about the currently logged-in user, including their name and role.

The project was developed using **C# and Windows Forms**, with the goal of applying object-oriented programming, desktop application development, user authentication, and basic transaction/cart functionality.

---

## ✨ Features

### 🔐 User Login

The application includes a login screen that allows registered users to authenticate before accessing the main application.

Features include:

- Email and password authentication
- Password visibility toggle
- Login validation
- Error handling
- User session creation
- Role identification

After successful authentication, the user's name and role are stored in the application session.

---

### 👥 Role-Based User Sessions

The system supports different user roles, including:

- **Admin**
- **Manager**

The logged-in user's name and role are displayed within the main application.

The application also provides different visual behaviour based on the user's role.

---

### 📚 Book Catalogue

The Books module provides a catalogue of available books.

Users can:

- Browse books
- Select books
- Increase book quantities
- Decrease book quantities
- Add selected books to the booking/cart
- Remove books from the cart

The application calculates the price associated with selected quantities.

---

### 🛒 Book Booking / Cart

The application includes a book booking functionality.

Users can select multiple books and manage their selections before completing the booking process.

The cart provides:

- Book name
- Quantity
- Price
- Quantity controls
- Add/remove functionality
- Subtotal calculation

Example workflow:

```text
Browse Books
     ↓
Select Book
     ↓
Increase Quantity
     ↓
Add to Cart
     ↓
Review Selection
     ↓
Calculate Subtotal
     ↓
Book / Continue

💰 Price Calculation

The system calculates the price of selected books based on quantity.

When the quantity of a book changes, the corresponding row in the cart is updated.

This helps prevent duplicate entries for the same book and keeps the selected quantity and price synchronized.

🚪 Logout

Authenticated users can log out of the application.

The logout process:

Displays a confirmation message.
Clears the current user's session information.
Returns the user to the login screen.
Closes the current main application window.
🛠️ Technologies Used
Technology	Purpose
C#	Application development
.NET Framework 4.7.2	Application framework
Windows Forms	Desktop graphical user interface
Visual Studio	Development environment
LINQ	Collection searching and data operations
.NET Collections	In-memory user and application data

🏗️ Application Architecture
The application follows a Windows Forms desktop architecture.
                   ┌─────────────────────┐
                   │       User          │
                   └──────────┬──────────┘
                              │
                              ▼
                   ┌─────────────────────┐
                   │    Login Form       │
                   │      Form1          │
                   └──────────┬──────────┘
                              │
                       Authentication
                              │
                              ▼
                   ┌─────────────────────┐
                   │    User Session     │
                   │ Full Name + Role    │
                   └──────────┬──────────┘
                              │
                              ▼
                   ┌─────────────────────┐
                   │    Main Form        │
                   │     Dashboard       │
                   └──────────┬──────────┘
                              │
                    ┌─────────┴─────────┐
                    ▼                   ▼
             ┌─────────────┐     ┌──────────────┐
             │    Books    │     │ Book Booking │
             │  Catalogue  │     │  / Cart      │
             └─────────────┘     └──────────────┘
📂 Project Structure
madlamini-library-dotnet472
│
├── .github/
│
├── MaDlamini Library/
│   │
│   ├── App.config
│   │
│   ├── Form1.cs
│   ├── Form1.Designer.cs
│   ├── Form1.resx
│   │
│   ├── Main.cs
│   ├── Main.Designer.cs
│   ├── Main.resx
│   │
│   ├── Books.cs
│   ├── Books.Designer.cs
│   ├── Books.resx
│   │
│   ├── BooksBooking.cs
│   ├── BooksBooking.Designer.cs
│   ├── BooksBooking.resx
│   │
│   └── MaDlamini Library.csproj
│
├── MaDlamini Library.sln
├── .gitignore
└── .gitattributes

The repository contains a Visual Studio solution and a dedicated Windows Forms project.

🔄 Application Flow
1. Login

The user enters their email and password.

Email + Password
       ↓
Validate Credentials
       ↓
   ┌─── Valid ───┐
   ↓             ↓
Create Session   Invalid
   ↓             ↓
Main Form      Error Message

2. Main Dashboard

After successful authentication, the application opens the main form.

The application loads the Books catalogue by default and displays information about the logged-in user.

The session contains:

Full Name
Role
Amount Due

The main form also provides navigation to the Books catalogue and Books Booking modules.

3. Book Selection

Users can increase or decrease the quantity of books.
The application updates the selected item and calculates its corresponding price.

4. Cart Management
Selected books are displayed in a DataGridView.
The application can:

Add a new book to the cart
Update an existing book quantity
Remove a book when its quantity reaches zero
Update prices
Calculate the subtotal

💻 Getting Started
Prerequisites
Before running the project, make sure you have:
Windows 10/11
Visual Studio 2019 or later
.NET Framework 4.7.2
.NET Framework 4.7.2 Developer Pack
