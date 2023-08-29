// See https://aka.ms/new-console-template for more information

using ToDoApp;
using ToDoApp.Utils;

Utilities utilities = new Utilities();
int choice = 0;
int priority=0;



Console.WriteLine("Hello, This Your ToDo List");
do
{
    Console.WriteLine("Press 1 to add a task");
    //Console.WriteLine("Press 2 to remove a task");
    Console.WriteLine("Press 2 to complete a task");
    Console.WriteLine("Press 3 to list all tasks");
    Console.WriteLine("Press 4 to Edit a task");
    Console.WriteLine("Press 5 to exit");
    try
    {
        choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            //Add a task
            case 1:
                add();
                break;
            //Remove a task
            //case 2:
            //    delete();
            //    break;
            //Complete a task
            case 2:
                complete();
                break;
            //List all tasks
            case 3:
                viewTasks();
                break;
            //Edit a task
            case 4:
                edit();
                break;

            case 5:
                // exit the application
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Thank you for using ToDo List");
                Console.ResetColor();
                break;
            default:
                // invalid choice
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Choice");
                Console.ResetColor();
                break;
        }

    }
    catch (Exception e)
    {
        // print the error message
        Console.WriteLine(e.Message);
    }


} while (choice != 5);


void edit()
{
    Console.WriteLine("Enter the name of the task to edit");
    string nameToEdit = Console.ReadLine();
    // check if the task exists or not



    try
    {
        ToDoApp.Task taskToEdit = utilities.GetTask(nameToEdit);

        

        if (taskToEdit == null)
        {
            // check if the task exists or not and print the message
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Task Not Found");
            Console.ResetColor();
        }
        else
        {
            // save the old values of the task
            string nameEdited = null;
            string descriptionToEdit = taskToEdit.Description;
            Priority priorityToEdit = taskToEdit.Priority;
            // edit the task
            int choiceToEdit;
            do
            {
                Console.WriteLine("choose what you want to edit");
                Console.WriteLine("1- name of the task");
                Console.WriteLine("2- description of the task");
                Console.WriteLine("3- Priority of the Task");
                Console.WriteLine("4- For Save your Edit");
                //what user want to edit
                choiceToEdit = int.Parse(Console.ReadLine());
                switch (choiceToEdit)
                {
                    // edit the name of the task
                    case 1:
                        //Console.WriteLine("name : ");
                        //nameEdited = Console.ReadLine();

                         nameEdited = "";

                        bool isValidName = false;

                        while (!isValidName)
                        {
                            Console.WriteLine("Your Original Name : " + nameToEdit);
                            Console.WriteLine(" Your New name is : ");
                            nameEdited = Console.ReadLine();

                            if (!utilities.containsTask(nameEdited))
                            {
                                isValidName = true; // Valid input, exit the loop
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid input. Task Name Already Exists.");
                                Console.ResetColor();
                            }
                        }

                        break;
                    // edit the description of the task
                    case 2:
                        Console.WriteLine("Your Original Description : " + descriptionToEdit);
                        Console.WriteLine("Your New description is : ");
                        descriptionToEdit = Console.ReadLine();
                        break;
                    // edit the priority of the task
                    case 3:
                        Console.WriteLine("Your Original Priority : " + priorityToEdit);
                        Console.WriteLine("Your New Priority is : ");
                        try
                        {
                            // get the priority of the task
                            Console.WriteLine("Enter the priority of the task");
                            Console.WriteLine("1. High");
                            Console.WriteLine("2. Medium");
                            Console.WriteLine("3. Low");
                            int pr=0;
                        ///

                            bool isValidInput = false;
                            int number = 0;

                            while (!isValidInput)
                            {
                                Console.WriteLine("Please enter a number:");
                                string userInput = Console.ReadLine();

                                if (int.TryParse(userInput, out pr)&&pr>0&&pr<4)
                                {
                                    isValidInput = true; // Valid input, exit the loop
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid input. Please enter a number.");
                                    Console.ResetColor();
                                }
                            }

                            ///

                            switch (pr)
                                {
                                    // chosse the priority high, medium, low
                                    case 1:
                                        priorityToEdit = Priority.High;
                                        break;
                                    case 2:
                                        priorityToEdit = Priority.Medium;
                                        break;
                                    case 3:
                                        priorityToEdit = Priority.Low;
                                        break;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid Priority");
                                        Console.ResetColor();
                                        break;
                                }
                           
                        }
                        catch (Exception e)
                        {
                            // print the error message
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ResetColor();
                        }
                        break;
                    case 4:
                        // exit the application
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Thank you for Editing ToDo List");
                        Console.ResetColor();
                        break;
                    default:
                        // invalid choice
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Choice");
                        Console.ResetColor();
                        break;


                }

            } while (choiceToEdit != 4);


            // variable to check if the task edited
            bool edited = utilities.EditTask(nameToEdit, nameEdited, descriptionToEdit, priorityToEdit);
            // check if the task edited or not and print the message
            if (!edited)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Task Not Edited");//dublicate
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task Edited");
                Console.ResetColor();
            }
        }
    }
    catch (Exception e)
    {
        // print the error message
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(e.Message);
        Console.ResetColor();
    }
}

void viewTasks()
{
    // list all tasks
    List<KeyValuePair<string,ToDoApp.Task>> list = utilities.ListAllTasks();
    // check if the list is empty or not and print the message or the list
    if (list.Count == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("No tasks to display");
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine("Your Tasks are:");
        Console.ForegroundColor = ConsoleColor.Magenta;

        foreach (KeyValuePair<string,ToDoApp.Task> task in list)
        {
            Console.WriteLine("Name: " + task.Key);
            Console.WriteLine("Description: " + task.Value.Description);
            Console.WriteLine("Priority: " + task.Value.Priority);
            Console.WriteLine("Created: " + task.Value.Created);
            Console.WriteLine("IsComplete: " + task.Value.IsComplete);
            Console.WriteLine();
        }
        Console.ResetColor();

    }
}

void complete()
{
    // complete a task
    Console.WriteLine("Enter the name of the task to complete");
    // get the name of the task to complete
    string nameToComplete = Console.ReadLine();
    // variable to check if the task was completed
    bool complete = utilities.CompleteTask(nameToComplete);
    // check if the task was completed or not and print the message
    if (!complete)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Task Not Found");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Task Completed and Deleted");
        Console.ResetColor();
    }
}

# region delete
//void delete()
//{
//    // remove a task
//    Console.WriteLine("Enter the name of the task to remove");
//    // get the name of the task to remove
//    string nameToRemove = Console.ReadLine();
//    // variable to check if the task was removed
//    bool removed = utilities.RemoveTask(nameToRemove);
//    // check if the task was removed or not and print the message
//    if (!removed)
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("Task Not Found");
//        Console.ResetColor();
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Green;
//        Console.WriteLine("Task Removed");
//        Console.ResetColor();
//    }
//}
#endregion

void add()
{
    //Console.WriteLine("Enter the name of the task");
    // get the name of the task
    string name ="";

    bool isValidName = false;

    while (!isValidName)
    {
        Console.WriteLine("Enter the name of the task");
        name = Console.ReadLine();

        if (!utilities.containsTask(name))
        {
            isValidName = true; // Valid input, exit the loop
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Task Name Already Exists.");
            Console.ResetColor();
        }
    }

    Console.WriteLine("Enter the description of the task");
    // get the description of the task
    string description = Console.ReadLine();
    Console.WriteLine("Enter the priority of the task");
    Console.WriteLine("1. High");
    Console.WriteLine("2. Medium");
    Console.WriteLine("3. Low");
    // variable to check if the task was added
    bool added = false;
    int flag = 0;
    try
    {
        // get the priority of the task
      //  priority = Convert.ToInt32(Console.ReadLine());
        bool isValidInput = false;
        int number = 0;

        while (!isValidInput)
        {
            Console.WriteLine("Please enter a number:");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out priority) && priority > 0 && priority < 4)
            {
                isValidInput = true; // Valid input, exit the loop
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.ResetColor();
            }
        }
        switch (priority)
        {
            // add the task based on the priority high, medium, low
            case 1:
                added = utilities.AddTask(name, description, Priority.High);
                break;
            case 2:
                added = utilities.AddTask(name, description, Priority.Medium);
                break;
            case 3:
                added = utilities.AddTask(name, description, Priority.Low);
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Priority");
                Console.ResetColor();
                flag = 1;
                break;
        }
    }
    catch (Exception e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(e.Message);
        Console.ResetColor();
        return;

    }

    // check if the task was added or not and print the message
    if (added)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Task Added");
        Console.ResetColor();
    }
    else if (flag == 1)
    {

    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Task Already Exists");
        Console.ResetColor();
    }
}