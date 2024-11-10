using System;
using System.Collections.Generic;

namespace TaskTracker
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }

    class Program
    {
        static List<TaskModel> tasks = new List<TaskModel>();
        static int nextId = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Task Tracker");
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Toggle Task Completion");
                Console.WriteLine("4. Exit");

                var choice = Console.ReadLine();
                if (choice == "1") AddTask();
                else if (choice == "2") ViewTasks();
                else if (choice == "3") ToggleTaskCompletion();
                else if (choice == "4") break;
            }
        }

        static void AddTask()
        {
            Console.Write("Enter task title: ");
            var title = Console.ReadLine();
            Console.Write("Enter task description: ");
            var description = Console.ReadLine();
            tasks.Add(new TaskModel { TaskId = nextId++, Title = title, Description = description, IsComplete = false });
            Console.WriteLine("Task added.");
        }

        static void ViewTasks()
        {
            Console.WriteLine("\nTasks:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.TaskId}: {task.Title} - {task.Description} (Completed: {task.IsComplete})");
            }
        }

        static void ToggleTaskCompletion()
        {
            Console.Write("Enter task ID to toggle completion: ");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                var task = tasks.Find(t => t.TaskId == taskId);
                if (task != null)
                {
                    task.IsComplete = !task.IsComplete;
                    Console.WriteLine("Task status updated.");
                }
                else Console.WriteLine("Task not found.");
            }
            else Console.WriteLine("Invalid input.");
        }
    }
}
