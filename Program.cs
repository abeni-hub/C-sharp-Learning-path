using System;
using System.Collections.Generic;

class Program
{
    static List<string> tasks = new List<string>();

    static void Main()
    {
        Console.WriteLine("=== To-Do List App ===");
        string choice;

        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Task(s)");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Update Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddTasks(); break;
                case "2": ViewTasks(); break;
                case "3": UpdateTask(); break;
                case "4": DeleteTask(); break;
                case "5": Console.WriteLine("Goodbye!"); break;
                default: Console.WriteLine("Invalid choice"); break;
            }

        } while (choice != "5");
    }

    static void AddTasks()
    {
        Console.WriteLine("Enter tasks (type 'done' to finish):");
        while (true)
        {
            string task = Console.ReadLine();
            if (task.ToLower() == "done") break;
            tasks.Add(task);
        }
    }

    static void ViewTasks()
    {
        Console.WriteLine("\nYour Tasks:");
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks yet!");
            return;
        }
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }

    static void UpdateTask()
    {
        ViewTasks();
        Console.Write("Enter task number to update: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < tasks.Count)
        {
            Console.Write("Enter new task: ");
            tasks[index] = Console.ReadLine();
            Console.WriteLine("Task updated.");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }

    static void DeleteTask()
    {
        ViewTasks();
        Console.Write("Enter task number to delete: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < tasks.Count)
        {
            tasks.RemoveAt(index);
            Console.WriteLine("Task deleted.");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }
}
