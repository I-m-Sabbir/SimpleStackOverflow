# SimpleStackOverflow
## About The Poject
This is a simple project build following StackOverflow. There are some features in this project, implemented least like StackOverflow.
Users need to register before using any feature like posting questions or answering questions or voting questions or answers.
Below are the features of the project:
	1. User registration
	2. User login
	3. Asking questions
	4. Answering questions
	5. Vote any questions or answers
	6. Remove vote from those
	7. Questioner can accept answers
	8. Questioner can modify or delete his/her questions
	9. Answers can be modified or deleted by the owner
	10. Guest users can see the questions and answers but can't do any actions

## Build Using
	> Asp.NET Core 6
	> MSSQL Server 2019
	> C# 10
	> BootStap
	> Visual Studio 2022

## Installation
Follow the below instractions step by step to install the project locally :-
	* Clone the repository using : https://github.com/I-m-Sabbir/SimpleStackOverflow.git
	* Change ConnectionString in appsettings.json file according to MSSQL Server
	* Run this line of command in "Package Manager Console" to update the database :  
dotnet ef database update --project SimpleStackOverflow.Web
	* Now the project is ready to run

