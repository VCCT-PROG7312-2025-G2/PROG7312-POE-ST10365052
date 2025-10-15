# 🏙️ Municipality Online Services Portal

This project is an **ASP.NET Core MVC web application** designed for municipalities to improve citizen engagement and service delivery.  
It allows residents to **report issues**, track service requests, and access important local announcements.  

---

## ✨ Features

- **Home Page Dashboard**
  - Quick access to reporting, service status, and local events.
- **Report Issues**
  - Citizens can report potholes, streetlight faults, waste collection, water leaks, and more.
  - Attach supporting documents and images (PDF, JPG, PNG, DOC/DOCX).
  - Live **form completion progress tracker** for better user experience.
- **Service Request Tracking** *(coming soon)*
- **Local Events & Announcements** *(coming soon)*

---

## 📂 Project Structure

```plaintext
/Controllers
    HomeController.cs
    IssuesController.cs
/Models
    IssueViewModel.cs
/Views
    /Home
        Index.cshtml
        ReportView.cshtml
    /Shared
        _Layout.cshtml
wwwroot/
    css/
    js/
⚙️ Technology Stack
Backend: ASP.NET Core MVC 7.0

Frontend: HTML5, CSS3, JavaScript (Vanilla)

Authentication: ASP.NET Core Identity (optional future implementation)

🛡️ Security Notes
File uploads are validated on the server to prevent malicious files.

All form inputs are validated with both client-side and server-side checks.

Recommended deployment behind HTTPS.

📌 Roadmap
 Multi-language support

 User authentication & role-based access

 Service request tracking system

 Admin dashboard with analytics

 Email/SMS notifications
