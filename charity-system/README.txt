===============================================
Charity Donation System (C# WinForms + SQL Server)
===============================================

🧠 Project Description:
------------------------
The Charity Donation System is a desktop-based application developed using 
C# Windows Forms, SQL Server, and Guna.UI2 Framework for a modern, 
interactive user interface. 

This system allows Admins to manage charity campaigns and Donors to make 
donations, view receipts, and track their contributions easily.

-----------------------------------------------
📦 Requirements:
-----------------------------------------------
1️⃣ Software Requirements:
   - Windows 10 / 11
   - Visual Studio 2022 or later
   - SQL Server or LocalDB
   - .NET Framework 4.8 or higher

2️⃣ Third-Party Libraries Used:
   - **Guna.UI2.WinForms (v2.0.0.5 or later)**
     👉 Used for modern buttons, textboxes, panels, and DataGridView styling.
   - (Optional) **FontAwesome.Sharp**
     👉 Used for sidebar icons and navigation.

-----------------------------------------------
⚙️ Setup Instructions:
-----------------------------------------------
1️⃣ Database Setup:
   - Open SQL Server Management Studio (SSMS)
   - Restore the backup file from the folder:
     📁 Database\CharityDB.bak
   - Or manually run the SQL script provided (Database\CharityDB.sql)

2️⃣ Project Setup in Visual Studio:
   - Open the solution file: CharityDonationSystem.sln
   - Go to:
     👉 Tools → NuGet Package Manager → Manage NuGet Packages for Solution
   - Search and install:
     - `Guna.UI2.WinForms`
     - (optional) `FontAwesome.Sharp`
   - Restore all NuGet dependencies (Right-click Solution → Restore NuGet Packages)

3️⃣ Configure Database Connection:
   - Open `App.config` or your database helper class
   - Update the connection string if needed:
     ```
     Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CharityDB;Integrated Security=True
     ```
   - Test connection by running the Login Form

-----------------------------------------------
👥 Roles (Default Accounts):
-----------------------------------------------
👨‍💼 **Admin Account**
   Email: admin@charity.org
   Password: 12345

🙋‍♂️ **Donor Account**
   Email: rina@gmail.com
   Password: 12345

-----------------------------------------------
💻 How to Run the Project:
-----------------------------------------------
1. Open the solution file in Visual Studio
2. Rebuild the project (Ctrl + Shift + B)
3. Run (F5) to start the application
4. Login using one of the provided accounts

-----------------------------------------------
📂 Project Structure:
-----------------------------------------------
📦 Charity Donation System - project
 ┣ 📁 CharityDonationSystem (Source Code)
 ┣ 📁 Database
 ┃ ┣ CharityDB.bak
 ┃ ┗ CharityDB.sql
 ┣ 📄 README.txt
 ┣ 📄 Charity Donation System - book.pdf
 ┗ 📄 Charity Donation System - slide.pdf

-----------------------------------------------
🧩 Main Forms:
-----------------------------------------------
🔹 LoginForm.cs — Handles authentication and role redirection
🔹 AdminMainForm.cs — Dashboard for Admin
🔹 ManageCharitiesForm.cs — CRUD operations for Campaigns
🔹 DonorMainForm.cs — Dashboard for Donor
🔹 DonateNowForm.cs — Handles donation entry
🔹 MyDonationsForm.cs — Displays donation history
🔹 ReportsForm.cs — Shows system statistics

-----------------------------------------------
🧱 Database Tables:
-----------------------------------------------
1. Users (Admin / Donor info)
2. Campaigns (Charity campaigns)
3. Donations (Transaction history)
4. Payments (Payment info)
5. Receipts (Donation receipts)
6. Reports (Admin summaries)

-----------------------------------------------
🌐 Developer Team:
-----------------------------------------------
👤 [Your Name] (Team Leader)
👤 [Member 2]
👤 [Member 3]

-----------------------------------------------
✅ Notes:
-----------------------------------------------
⚠️ Before running the project, ensure that:
- The Guna.UI2 library is properly installed.
- The SQL database is restored correctly.
- Your Visual Studio project references .NET Framework 4.8+.
- Connection string matches your SQL Server instance.

-----------------------------------------------
✨ Credits:
-----------------------------------------------
- Guna.UI2.WinForms for UI Components
- Microsoft SQL Server for Database Management
- Visual Studio for Development Environment

-----------------------------------------------
