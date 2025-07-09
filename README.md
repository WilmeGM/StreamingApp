# 🎬 StreamingApp – ASP.NET Core MVC App

A video streaming web application built with **ASP.NET Core C#**, following **Onion Architecture**, **Generic Repository Pattern**, and applying **SOLID principles** and **Clean Code** practices. This project showcases how to build scalable, layered, and testable web applications using modern .NET technologies.

---

## 🎯 Purpose

This project aims to:

- Demonstrate the use of **Onion Architecture** for clear separation of concerns.
- Apply **SOLID principles** through services, repositories, and ViewModels.
- Build a clean, maintainable CRUD system for managing streaming content.
- Practice **Entity Framework Core** with the **Code First** approach.
- Offer a real-world example of modular ASP.NET Core MVC development.

---

## 🚀 Features

### 🏡 Home Page
- Displays a list of all created series with:
  - Title
  - Cover image
  - Genres (primary & secondary)
  - Producer name
- Each series includes a "Details" button that leads to a video player page (YouTube embedded).

### 🔍 Search & Filtering
- **Search by name** (text input).
- **Filter by producer** (dropdown).
- **Filter by genre** (dropdown).

### 📦 Series Management
- **List, create, edit, and delete** series.
- Fields: name, cover image URL, YouTube link, producer, primary and secondary genres.
- Validations: all fields except secondary genre are required.
- Clean UI using Bootstrap.

### 🏢 Producer Management
- CRUD operations for producers.
- Validations for required fields.

### 🎭 Genre Management
- CRUD operations for genres.
- Validations for required fields.

---

## 🧱 Tech Stack

| Layer        | Technology                     |
|--------------|---------------------------------|
| Backend      | ASP.NET Core MVC (.NET 6/7/8)  |
| Architecture | Onion Architecture             |
| ORM & DB     | Entity Framework Core + SQL Server |
| UI           | Razor Views + Bootstrap        |
| Pattern      | Generic Repository             |
| Validation   | DataAnnotations in ViewModels  |

---

## 📂 Getting Started

1. Clone the repository  
   `git clone https://github.com/WilmeGM/StreamingApp.git`

2. Configure the database in `appsettings.Development.json` or create your own based on.

3. Apply migrations  
   `dotnet ef database update`

4. Run the app  
   `dotnet run`

## 📄 License

This project is licensed under the MIT License – free to use and extend.

---
