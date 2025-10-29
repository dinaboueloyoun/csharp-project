using System;

namespace ConsoleApp23
{
    internal class Program
    {
        static string[] tasks = new string[100];
        static int taskCount = 0;

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                ShowHeader();
                ShowMenu();

                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ShowTasks();
                        break;
                    case "3":
                        DeleteTask();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        PrintColored("❌ Invalid choice! Please enter 1-4.", ConsoleColor.Red);
                        Pause();
                        break;
                }
            }

            PrintColored("\n Thank you for using To-Do List App! ", ConsoleColor.Yellow);
        }

        static void ShowHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===================================");
            Console.WriteLine("         TO-DO LIST APP         ");
            Console.WriteLine("===================================");
            Console.ResetColor();
        }

        static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("1. Add a new task");
            Console.WriteLine("2. Show all tasks");
            Console.WriteLine("3. Delete a task");
            Console.WriteLine("4. Exit");
            Console.ResetColor();
        }

        static void AddTask()
        {
            Console.Clear();
            ShowHeader();

            string newTask;

            while (true)
            {
                Console.Write("Enter a new task: ");
                newTask = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newTask) || int.TryParse(newTask, out _))
                {
                    PrintColored("❌ Task cannot be empty or a number! Please enter a valid task.", ConsoleColor.Red);
                }
                else
                {
                    tasks[taskCount] = newTask;
                    taskCount++;
                    PrintColored("✅ Task added successfully!", ConsoleColor.Green);
                    break;
                }
            }

            Pause();
        }

        static void ShowTasks()
        {
            Console.Clear();
            ShowHeader();

            if (taskCount == 0)
            {
                PrintColored("No tasks available.", ConsoleColor.DarkYellow);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Your Tasks:");
                Console.WriteLine("────────────────────────────────────");
                for (int i = 0; i < taskCount; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{i + 1}. ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(tasks[i]);
                }
                Console.ResetColor();
                Console.WriteLine("────────────────────────────────────");
            }

            Pause();
        }

        static void DeleteTask()
        {
            Console.Clear();
            ShowHeader();

            if (taskCount == 0)
            {
                PrintColored("❌ No tasks to delete!", ConsoleColor.Red);
                Pause();
                return;
            }

            ShowTasks(); // عرض المهام مرة واحدة قبل إدخال الرقم

            while (true)
            {
                Console.Write("Enter the number of the task to delete: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int index))
                {
                    PrintColored("❌ Invalid input! Please enter a number.", ConsoleColor.Red);
                    Console.WriteLine("Press Enter to try again...");
                    Console.ReadLine();
                }
                else if (index < 1 || index > taskCount)
                {
                    PrintColored($"❌ Invalid number! Enter a number between 1 and {taskCount}.", ConsoleColor.Red);
                    Console.WriteLine("Press Enter to try again...");
                    Console.ReadLine();
                }
                else
                {
                    for (int i = index - 1; i < taskCount - 1; i++)
                        tasks[i] = tasks[i + 1];
                    taskCount--;
                    PrintColored("🗑️ Task deleted successfully!", ConsoleColor.Green);
                    Pause();
                    break;
                }
            }
        }

        static void PrintColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
