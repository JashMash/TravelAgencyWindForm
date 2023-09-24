# Travel Agency Windows Form

This is a windows from application done through Visual studio,
interacting with a SQL Database. 

Primary Functions:
1. Edit and Create Travel Packages
2. Edit and Create Product Suppliers
3. Edit and Create Products 
4. Edit and Create Suppliers

The delete functionality isnt given just so no entries 
should be deleted.

To create the Database used in the application is given in file:
- travelexperts-mssql.sql

We used SQL Server Management Studio 2019 for viewing and hosting our local Database.

When trying to use this application on your machine:
1. please DO NOT clone this using the Visual studio github extension use Git Bash or Github Desktop.
2. You will first need to run the SQL file in the SQL server mangement tool you use and take down the data source it should look something like: "localhost\sqlexpress"
3. Navigate to Models folder in project files in the Solution explorer, find the "TravelExpertsContext.cs" file, at line 59 change the Data Source to your "localhost\sqlexpress".
4. Save
5. Now you should be able to run the project.
