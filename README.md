# 🏥 Clinic Management API

A clean, well-structured ASP.NET Core Web API for managing Clinics, Doctors, Patients, Appointments, and Diagnoses — built step by step following real-world backend architecture practices.

---

## 📈 Project Evolution (How it was built step-by-step)

> This project wasn't written all at once — it was built progressively, like real projects in companies:

| Step | What was done |
|------|----------------|
| ✅ 1 | Built initial `DoctorController` and `ClinicController` directly using DbContext |
| ✅ 2 | Introduced Service Layer (`IDoctorService`, `IClinicService`) and applied AutoMapper & DTOs |
| ✅ 3 | Refactored code to use Clean Architecture pattern (Controller → Service → Data) |
| ✅ 4 | Completed full CRUD for `Patients` using DTOs and service structure |
| ✅ 5 | Built `Appointment` module with relationships to `Doctor` and `Patient` (with validation) |
| ✅ 6 | Implemented `Diagnosis` with smart checks (no duplicate per appointment) |
| ✅ 7 | Organized all logic into separate layers with clear structure and no tight coupling |

---

## 🚀 Features

### ✅ Clinic Module
- Create, Read, Update, Delete Clinics
- Returns related Doctors per clinic

### ✅ Doctor Module
- Full CRUD with clean mapping
- Service layer handles all logic

### ✅ Patient Module
- Full CRUD
- Connected to appointments

### ✅ Appointment Module
- Related to both Doctors and Patients
- Full validation before creation
- Returns all linked data (Doctor, Patient, Diagnosis)

### ✅ Diagnosis Module
- One-to-one relation with Appointment
- Prevents duplicate Diagnoses for same Appointment

---

## 🛠️ Tech Stack

- ASP.NET Core 8.0
- Entity Framework Core
- SQL Server
- AutoMapper
- RESTful API Design
- Clean Architecture + Service Layer
- Swagger (coming soon)
- JWT Authentication (coming soon)

---

## 📁 Project Structure

ClinicAPI/
├── Controllers/
├── DTOs/
│ ├── Doctor/
│ ├── Clinic/
│ ├── Patient/
│ ├── Appointment/
│ └── Diagnosis/
├── Models/
├── Services/
│ ├── Interfaces/
│ └── Implementations/
├── Data/
├── Profiles/ (AutoMapper)
├── Notes/
│ ├── todo.md
│ ├── bugs.md
│ └── architecture.md
└── Program.cs

---

🔜 Coming Next
- JWT Authentication (login, token handling, authorization)

 -Swagger UI for API testing

 - Model validation and global error handling

 - Logging & Diagnostics (Serilog or built-in logging)

 - Unit Testing for service layer

