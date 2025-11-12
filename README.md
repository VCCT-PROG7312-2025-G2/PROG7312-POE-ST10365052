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

Compilation

Open the project in Visual Studio 2022 or higher.

Ensure .NET 8 SDK and ASP.NET Core MVC workload are installed.

Restore dependencies via:

dotnet restore


Build the solution using Ctrl + Shift + B or:

dotnet build


Running the Application

Set the main web project as the startup project.

Press F5 or run:

dotnet run


The application will start on https://localhost:5001/.

Using the Programme

Home Page: Displays service options such as reporting issues and viewing events.

Service Request Form: Allows users to log a new request (e.g., pothole, streetlight fault).

Service Request Status Page: Displays the current status of logged issues, including progress updates handled by custom data structures.

Events Page: Lists local events with a recommendation system based on categories.

Implemented Data Structures and Their Role
1. Binary Search Tree (BST)

Purpose: Used to efficiently store and retrieve service requests by location.

Role in Efficiency:

Lookup and insertion operations are O(log n), enabling fast retrieval of request statuses.

Example:

var statusNode = serviceRequestBST.Search("Cape Town Central");


This allows the system to quickly fetch all requests from a specific area.

Contribution: Enhanced data access speed and made the “Service Request Status” page dynamic and responsive.

2. Min Heap

Purpose: Prioritizes urgent service requests based on their priority value or severity.

Role in Efficiency:

The smallest (most urgent) request is always on top — O(1) for access.

Example:

var urgentTask = requestHeap.GetMin();


This allows the system to automatically process the most critical reports first.

3. Graph

Purpose: Models the relationships between locations (e.g., districts and service zones).

Role in Efficiency:

Used for optimizing routing between connected service zones.

Example:

var shortestRoute = locationGraph.FindShortestPath("Zone A", "Zone D");


Ensures service assignments are optimized based on proximity and connectivity.
