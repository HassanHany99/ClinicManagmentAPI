# ✅ TODO List

## ✅ What’s Already Done (by order of implementation):

- [x] Created DoctorController (basic CRUD directly on DbContext)
- [x] Created ClinicController (basic CRUD directly on DbContext)
- [x] Refactored DoctorController to use IDoctorService
- [x] Implemented DoctorService with full logic and AutoMapper
- [x] Refactored ClinicController to use IClinicService
- [x] Implemented ClinicService with full logic and AutoMapper

## 🛠️ Currently Working On:
- [ ] Building PatientController using DTOs
- [ ] Creating IPatientService and implementing PatientService
- [ ] Building DiagnosisController with full CRUD
- [ ] Creating IDiagnosisService and implementing DiagnosisService
- [ ] Building AppointmentController with full CRUD
- [ ] Creating IAppointmentService and implementing AppointmentService

## 🔜 Coming Next:
- [ ] Add Swagger documentation for all endpoints
- [ ] Apply global error handling middleware
- [ ] Start JWT-based authentication system
- [ ] Clean up code (e.g., use IEnumerable properly, remove unnecessary context usage, consistent naming)
- [ ] Final testing and validation before deployment

## 🧹 Later (Optional Enhancements):
- [ ] Add logging with Serilog
- [ ] Unit Tests for Service Layer
- [ ] Add pagination for list endpoints
