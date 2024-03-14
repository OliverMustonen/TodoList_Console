using System;
using System.Collections.Generic;

class Task
{
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public Task(string description)
    {
        Description = description;
        IsCompleted = false;
    }
}

class ToDoList
{
    private List<Task> tasks;

    public ToDoList()
    {
        tasks = new List<Task>();
    }

    public void AddTask(string description)
    {
        Task newTask = new Task(description);
        tasks.Add(newTask);
        Console.WriteLine($"Task added: {description}");
    }

    public void MarkTaskAsCompleted(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks[index].IsCompleted = true;
            Console.WriteLine($"Task marked as completed: {tasks[index].Description}");
        }
        else
        {
            Console.WriteLine("Invalid task index.");
        }
    }

    public void PrintTasks()
    {
        Console.WriteLine("\nToDo List:");

        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. [{(tasks[i].IsCompleted ? "X" : " ")}] {tasks[i].Description}");
        }
    }
}

class Program
{
    static void Main()
    {
        ToDoList todoList = new ToDoList();

        Console.WriteLine("Welcome to the ToDo List Application!");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Mark Task as Completed");
            Console.WriteLine("3. Print Tasks");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice (1-4): \n");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter task description: ");
                    string taskDescription = Console.ReadLine();
                    todoList.AddTask(taskDescription);
                    break;
                case "2":
                    Console.Write("Enter the index of the task to mark as completed: ");
                    if (int.TryParse(Console.ReadLine(), out int taskIndex))
                    {
                        todoList.MarkTaskAsCompleted(taskIndex - 1);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                    break;
                case "3":
                    todoList.PrintTasks();
                    break;
                case "4":
                    Console.WriteLine("Exiting the ToDo List Application. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }
}
