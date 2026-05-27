# Gas-Consumption-portal
Change to the master branch to access the files.

## Table of Contents
- [About the Project](#about-the-project)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Database Setup](#database-setup)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

---

## About the Project

This project, "Gas-Consumption-portal," aims to provide a system for managing and tracking gas consumption. 

**Example elaborations:**
* "This web application allows users to record their gas consumption details, view historical data, and generate reports, helping them to monitor and manage their energy usage efficiently."
* "It provides a user-friendly interface for adding new consumption entries, tracking different types of gas usage (e.g., household, vehicle), and visualizing consumption trends over time."

## Features

* **User Authentication & Authorization:** (Likely includes Login, Register, Logout functionality as seen from `AccountController.cs` and `Register.cshtml`, `Login.cshtml`).
* **Gas Consumption Data Entry:** (Presumably, users can input details of their gas consumption).
* **Data Viewing/Reporting:** (Ability to view historical consumption, perhaps charts or summaries).
* **User Profile Management:** (Possibly, if there's a `ConsumerProfile.cshtml`).
* **Dashboard:** (As suggested by `Dashboard.cshtml`, probably an overview for users).
* **Database Management:** (Uses EF Core for data persistence, implied by `Migrations` folder).


## Technologies Used

* **Backend:**
    * C#
    * ASP.NET Core (MVC / Razor Pages - based on `Pages` folder)
    * Entity Framework Core (for database interactions, hinted by `Migrations`)
* **Frontend:**
    * HTML
    * CSS
    * JavaScript / jQuery (common in ASP.NET Core Razor Pages)
    * Bootstrap (common for UI styling in ASP.NET Core)
* **Database:**
    * SQL Server (or mention if it's SQLite, PostgreSQL, etc., if you configured it differently)
* **Development Environment:**
    * Visual Studio 2022 (or whichever version you are using)

## Getting Started

To get a local copy up and running, follow these simple steps.

### Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/download) (.NET 8.0)
* [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) (Community Edition is free)
* [SQL Server LocalDB](https://docs.microsoft.com/en-us/sql/relational-databases/sql-server-express-localdb?view=sql-server-ver16) (usually comes with Visual Studio) or a SQL Server instance.

### Installation

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/Shaurya16h/Gas-Consumption-portal.git](https://github.com/Shaurya16h/Gas-Consumption-portal.git)
    ```
2.  **Navigate to the project directory:**
    ```bash
    cd Gas-Consumption-portal
    ```
3.  **Open in Visual Studio:**
    * Open the `.sln` (solution) file located in the root of the cloned directory (e.g., `Gas-Consumption-portal.sln`) with Visual Studio.

### Database Setup

This project uses Entity Framework Core Migrations for database management.

1.  **Update Connection String:**
    * Open `appsettings.json` (or `appsettings.Development.json`).
    * Locate the `ConnectionStrings` section and ensure the `DefaultConnection` points to your SQL Server instance or LocalDB.
        ```json
        "ConnectionStrings": {
          "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=GasConsumptionDB;Trusted_Connection=True;MultipleActiveResultSets=true"
        }
        ```
        *(Adjust `Database=GasConsumptionDB` to your desired database name if necessary.)*

2.  **Apply Migrations:**
    * Open the **Package Manager Console** in Visual Studio (Go to `Tools` > `NuGet Package Manager` > `Package Manager Console`).
    * Run the following commands:
        ```powershell
        Update-Database
        ```
    * This command will create the database and all necessary tables based on your EF Core migrations.

## Usage

1.  **Run the application:**
    * After setting up the database, run the project from Visual Studio by pressing `F5` or clicking the "IIS Express" (or "HTTPS") button in the toolbar.
2.  **Access the application:**
    * The application will typically open in your default browser at `https://localhost:XXXX` (where XXXX is a port number, usually 7000s or 5000s).
3.  **Register an account:**
    * On the website, use the "Register" link to create a new user account.
4.  **Explore features:**
    * Log in and start adding gas consumption entries, viewing your dashboard, etc.

## Project Structure

Briefly describe the key folders and their purpose:

* `Controllers/`: Contains MVC controllers (if applicable).
* `Data/`: Contains `ApplicationDbContext.cs` and potentially other data access classes.
* `Migrations/`: Entity Framework Core database migration files.
* `Models/`: Contains application models/entities.
* `Pages/`: Contains Razor Pages (`.cshtml` and `.cshtml.cs` files) for UI and backend logic.
* `wwwroot/`: Contains static files like CSS, JavaScript, images.
* `appsettings.json`: Application configuration settings (e.g., database connection strings).
* `Program.cs`: Application entry point and startup configuration.

## Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1.  Fork the Project
2.  Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3.  Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4.  Push to the Branch (`git push origin feature/AmazingFeature`)
5.  Open a Pull Request

## License

Distributed under the [MIT License](https://opensource.org/licenses/MIT). See `LICENSE` for more information. *(You'll need to add a LICENSE file to your repository if you choose one.)*

## Contact

Aditya - adich3103@gmail.com

Project Link: [https://github.com/adikc015/gas-consumption-portal.git](https://github.com/adikc015/gas-consumption-portal.git)
