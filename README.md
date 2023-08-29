
# ToDoApp

## Description
This is a simple ToDoApp using C# and XUnit testing. This app allows the user to create a ToDo list, add items to the list,
and complete items from the list and view the items From List .

## Getting Started
- Clone this repository to your local machine.
``` git clone [ToDoApp](https://github.com/mohamed154salah/ToDoApp)``

- Once downloaded, cd into the ```ToDoApp``` directory.
``` cd ToDoApp/ToDoApp```

- The dependencies for the project are managed through NuGet. Make sure you have the NuGet CLI installed.
``` dotnet restore ```
- To Build The Project ``` dotnet build ```
- To Run The Project ``` dotnet run ```

- To Run The Tests
	- ``` cd ToDoApp.Tests ```
	- ``` dotnet test ```

ps: you can use Visual Studio to run the project and the tests.

## Project In Action
- Type ``` dotnet run ``` in the terminal. 

	- Option 1: Create a new list.
	
		- You will be prompted to enter a name for your Task.
		- You will be prompted to enter a description for your Task.
		- you will be prompted to enter a Priority for your Task.
		
			- Options are: 1 for High, 2 for Medium, 3 for Low.
			- If you enter a number other than 1, 2, or 3, you will be prompted to enter a valid number.
	- Option 2: Complete a Task.
	
		- You will be prompted to enter the name of the Task you would like to complete.
		
	- Option 3: List All Tasks
	
		- You will be shown a list of all Tasks.
	
	- Option 4: Edit Task
	
		- You will be prompted to enter the name of the Task you would like to edit.
			
			- If Task Exists You have Options 1 for Name, 2 for descrbtion, 3 For Priority, 4 For save Your Edit.
		











## Technologies Used
The project build  With
- .NET 6
- XUnit
	
