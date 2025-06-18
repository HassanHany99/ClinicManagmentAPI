# 🏥 Clinic Management API

An ASP.NET Core Web API project for managing clinics, doctors, patients, diagnoses, and appointments — built using a clean, layered architecture with Entity Framework Core and AutoMapper.

---

## 🧠 Project Purpose

This project was built as part of a hands-on journey to master backend development using ASP.NET Core Web API and EF Core. The focus is on clean architecture, separation of concerns, and writing production-style code similar to what’s used in real-life company environments.

---

## ✅ Features Implemented So Far

- 🔹 **Doctor Module**
  - Full CRUD operations via `DoctorController`
  - Business logic handled by `DoctorService`
  - DTOs used for cleaner request/response models

- 🔹 **Clinic Module**
  - Full CRUD operations via `ClinicController`
  - Includes navigation to related Doctors
  - Business logic in `ClinicService` with AutoMapper mapping

- 🔹 **Patient Module**
  -  implementeded
  - DTOs + Service Layer in progress

- 🔹 **Diagnosis & Appointment Modules**
  - implemented
  - Each have full CRUD + proper relational handling

---

## 🛠️ Tech Stack

- **ASP.NET Core 8.0**
- **Entity Framework Core**
- **AutoMapper**
- **SQL Server**
- **Swagger (planned)**
- **JWT Authentication (coming soon)**

---

## 🧱 Project Structure (Layered Architecture)

ClinicAPI/
│
├── Controllers/ # API Controllers (Doctors, Clinics, etc.)
├── Services/
│ ├── Interfaces/ # Service interfaces (e.g., IDoctorService)
│ └── Implementations/ # Actual business logic services
├── DTOs/ # Request/Response Models (DoctorDTOs, ClinicDTOs)
├── Models/ # Entity Models (Doctor, Clinic, etc.)
├── Data/ # DbContext and EF configuration
├── Profiles/ # AutoMapper profiles
├── Notes/ # Contains todo.md, bugs.md, architecture.md
└── Program.cs # App configuration and service registration

---

## 🔄 Work Progress

Development is in **active progress**.  
✅ All modules are fully functional.   
🛡️ Authentication, error handling, and documentation to follow.

---

## 📌 Next Steps

- Add Swagger for API testing and documentation
- Add JWT Authentication for secure access
- Improve validation and global error handling
- Clean/refactor code for best practices and consistency