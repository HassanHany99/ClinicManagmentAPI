# Clinic Management System API 🏥

A RESTful Web API for managing doctors, patients, clinics, appointments, and diagnoses — built with ASP.NET Core Web API using a clean and scalable architecture.

---

## ✅ What's Done

- ✅ Used layered architecture: Controllers ➜ Services ➜ Repositories ➜ Unit of Work
- ✅ Applied Entity Framework Core + Code First + Fluent API
- ✅ Built full CRUD for:
  - 🧑‍⚕️ Doctor
  - 👤 Patient
- ✅ Used AutoMapper for clean DTO mapping
- ✅ Implemented async/await for non-blocking database calls
- ✅ Organized project with Clean Code & SOLID Principles
- 🛠️ Currently working on JWT Authentication and Authorization

---

## 👨‍⚕️ Modules Progress

| Module        | Service Layer | Repository Layer | Status    |
|---------------|---------------|------------------|-----------|
| Doctor        | ✅ Done        | ✅ Done           | ✅ Complete |
| Patient       | ✅ Done        | ✅ Done           | ✅ Complete |
| Clinic        | ✅ Done        | ❌ Not yet        | 🟡 In Progress |
| Appointment   | ✅ Done        | ❌ Not yet        | 🟡 In Progress |
| Diagnosis     | ✅ Done        | ❌ Not yet        | 🟡 In Progress |

---

## 🧩 What’s Next

- Implement **Repository Layer** for:
  - Clinic
  - Appointment
  - Diagnosis
- Add full **Validation** for input DTOs
- Finalize **JWT Authentication & Role-based Authorization**
- Build **Global Exception Handling**
- Setup **Logging & Error Tracking**

---

## ⚙️ Tech Stack

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQL Server
- AutoMapper
- LINQ
- Repository + Unit of Work Pattern
- JWT Authentication (in progress)
- C#
- RESTful API Design

---

## 🧠 Architecture

- `Controllers` → Handle HTTP requests
- `Services` → Contain business logic
- `Repositories` → Communicate with DB
- `Unit of Work` → Manage data transactions
- `DTOs` → Decouple layers
- `AutoMapper` → Clean object mapping

---

## 🔐 Security

JWT Authentication is currently under implementation to secure endpoints for real-world deployment.

---

## 🚀 Project Status

The core modules are in place and being improved.  
This project is continuously being expanded and refactored to match **production-level standards**.

---

## 📌 Notes

This project is being built from scratch with the goal of mastering .NET backend development  
and preparing for real-world job-ready deployment.

Stay tuned for upcoming updates!
