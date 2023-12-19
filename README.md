# CoursesAppMVC

Welcome to CoursesAppMVC, a web application designed to help students manage their courses and study hours effectively.  
Here is a video walkthrough about the application and its features: [YouTube Walkthrough](https://youtu.be/CGV46zMYfWk)

## Features

- **User Authentication:** Secure registration and login system.
- **Course Management:** Add, edit, and delete modules with details like module code, name, credits, and study hours.
- **Study Progress:** Track your study hours and view study progress over time.
- **Dynamic Charts:** Visual representation of study hours and class hours per week.
- **User-Friendly Interface:** Intuitive and easy-to-use interface.

## Getting Started

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/)

### Running Locally  

### Please note: The app runs without isssue on the `Microsoft Edge browser`, if your `default` browser is different (such as Chrome) you may expereience errors related to certificates and permissions

1. Clone the repository OR download the ZIP folder:

    ```bash
    git clone https://github.com/SamTheCopy-ninja/C-Sharp-ASP.NET-Core-Modules-Tracker-Web-App.git
    ```

2. Navigate to the project directory on your device

3. Open the solution in Visual Studio.

4. Create a local database on your device in `Microsoft SQL Server Management Studio`

5. Connect the database (you have just created) to the application then update the database connection string in `appsettings.json` in the application:

    ```json
    "DefaultConnection": "YourConnectionStringHere"
    ```

6. Open the `Package Manager Console` in the project directory and run the following commands:

    ```
    add-migration InitialCreation
    update-database
    ```
   ### IMPORTANT
   PLEASE NOTE: Testing the app reveals an issue that may occur in user databases created on your local machine.

   The initial migration may create the `Modules` table in your database with a misssing `WeeksInSemester` column and also incorrect `DATA TYPES` for the following columns:
   `StudentID` and `SelfStudyHoursPerWeek`

   Please check your SQL database (before running the app) to ensure that within your database:
   
   The `WeeksInSemester` column is present in your database with an `int` data type  
   The `StudentID` column should be a `nvarchar(max)` data type  
   The `SelfStudyHours` column should be a `float` data type

   If the table columns in your database were created incorrectly by the initial migration please run another migration in your `Package Manager Console` which includes the following:

   ```
    protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
            name: "WeeksInSemester",
            table: "Modules",
            nullable: false,
            defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
            name: "SelfStudyHoursPerWeek",
            table: "Modules",
            type: "float",
            nullable: false,
            oldClrType: typeof(float),
            oldType: "real");

            migrationBuilder.AlterColumn<string>(
            name: "StudentID",
            table: "Modules",
            type: "nvarchar(max)",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "int");
        }

    protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
            name: "StudentID",
            table: "Modules",
            type: "int",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<float>(
            name: "SelfStudyHoursPerWeek",
            table: "Modules",
            type: "real",
            nullable: false,
            oldClrType: typeof(float),
            oldType: "float");

        }
    ```

    Then update the database again:
   ```
    update-database
    ```
8. Run the application.

9. Access the app in your web browser.

## Author

- [Samkelo Tshabalala](https://github.com/SamTheCopy-ninja)

## Code Attribution

This project was built with the help of various open-source libraries and frameworks, including code snippets adapted from online articles and documentation found below:

- [ASP.NET Core](https://docs.microsoft.com/aspnet/core)
  
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
  
- [Chart.js](https://www.chartjs.org/)
  
- Jayachandran, S., 2017. Charts In ASP.NET MVC Using Chart.js. [Online] 
Available at: https://www.c-sharpcorner.com/article/charts-in-asp-net-mvc-using-chart-js/
[Accessed 27 November 2023].

- Learning Programming, 2021. Create ASP.NET Core MVC 5 Project. [Online] 
Available at: https://learningprogramming.net/net/asp-net-core-mvc-5/use-images-css-and-javascript-in-asp-net-core-mvc-5/
[Accessed 27 November 2023].

- Microsoft, 2023. Tutorial: Get started with EF Core in an ASP.NET MVC web app. [Online] 
Available at: https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0
[Accessed 27 November 2023].

- Rout, P., 2023. Forms Authentication in ASP.NET MVC. [Online] 
Available at: https://dotnettutorials.net/lesson/forms-authentication-in-mvc/
[Accessed 27 November 2023].
