# Electronics Shop Warehouse manager

This is very simple console program that manages articles in warehouse.

The articles are added / listed / modified / removed  <i>(CRUD)</i> via command interface.
Project uses <b>MS SQL</b> server database to actually store articles.
This project is explanation how to work with Entity Framework Core
Code first approach to create database is used.
When you change database Models, database is automatically updated with corresponding structure.

NuGet packages required: 
	<b>Microsoft.EntityFrameworkCore.Design to create models</b>
	<b>Microsoft.EntityFrameworkCore.SqlServer</b> to connect with database server
	<b>Microsoft.EntityFrameworkCore.Tools</b> to work with Package Manager Console inside Visual Studio
