# ZooManagement

## How to install packages

Run the following commands:
`dotnet add package Microsoft.EntityFrameworkCore.Relational --version 8.0.8`
`dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.8`
`dotnet add package Microsoft.EntityFrameworkCore --version 8.0.8`

## How to set up the database
Make sure you have DB Browser for SQLite installed. Open the zoomanagement.db file with DB Browser to see a visualisation of the database. If you update the database with new fields or data, delete this file and run the project to create a new version of the database.

## How to run the project
Run the following command:
`dotnet run --launch profile https`

Go to https://localhost:<port>/swagger/index.html to see the list of endpoints and use them to run Create, Read, Update and Delete commands on the database.

## To Do List
 [] The Quantity property of AnimalType should update automatically when new individual Animals are created or deleted from the database
 [] Create an endpoint which will list all the types of animals in the zoo
 [] Add a sample data file which will seed the database