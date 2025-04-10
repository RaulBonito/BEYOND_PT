using Beyond.PruebaTecnica.Abstractions.Services;
using Beyond.PruebaTecnica.Abstractions.Repositories;
using Beyond.PruebaTecnica.Repositories;
using Beyond.PruebaTecnica.Services;
using Beyond.PruebaTecnica.ConsoleApp;

ITodoListRepository repository = new TodoListRepository();
ITodoList service = new TodoListService(repository);

while (true)
{
    ConsoleHelper.WriteHeader("TodoList Manager");

    Console.WriteLine("Choose an action:");
    Console.WriteLine("  [1] Add Item");
    Console.WriteLine("  [2] Update Description");
    Console.WriteLine("  [3] Remove Item");
    Console.WriteLine("  [4] Register Progression");
    Console.WriteLine("  [5] Print Items");
    Console.WriteLine("  [0] Exit");

    Console.Write("\nYour choice: ");
    var input = Console.ReadLine();

    try
    {
        switch (input)
        {
            case "1": // Add Item
                ConsoleHelper.WriteHeader("Add New TodoItem");

                int id = repository.GetNextId();

                Console.Write("Title: ");
                var title = Console.ReadLine();

                Console.Write("Description: ");
                var desc = Console.ReadLine();

                var categories = repository.GetAllCategories();
                var availableCategories = string.Join(", ", categories);
                Console.WriteLine($"Available Categories: {availableCategories}");

                Console.Write("Category: ");
                var cat = Console.ReadLine();

                service.AddItem(id, title!, desc!, cat!);
                ConsoleHelper.WriteSuccess("Item added successfully.");
                break;

            case "2": // Update Description
                ConsoleHelper.WriteHeader("Update TodoItem Description");

                Console.Write("Id: ");
                id = int.Parse(Console.ReadLine()!);

                Console.Write("New description: ");
                desc = Console.ReadLine();

                service.UpdateItem(id, desc!);
                ConsoleHelper.WriteSuccess("Description updated.");
                break;

            case "3": // Remove Item
                ConsoleHelper.WriteHeader("Remove TodoItem");

                Console.Write("Id: ");
                id = int.Parse(Console.ReadLine()!);

                service.RemoveItem(id);
                ConsoleHelper.WriteSuccess("Item removed.");
                break;

            case "4": // Register Progression
                ConsoleHelper.WriteHeader("Register Progression");

                Console.Write("Id: ");
                id = int.Parse(Console.ReadLine()!);

                var dateTime = ConsoleHelper.ReadDateTime();

                Console.Write("Percent: ");
                var percent = decimal.Parse(Console.ReadLine()!);

                service.RegisterProgression(id, dateTime, percent);
                ConsoleHelper.WriteSuccess("Progress registered.");
                break;

            case "5": // Print Items
                ConsoleHelper.WriteHeader("Todo Items Overview");
                service.PrintItems();
                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
                break;

            case "0": // Exit
                Console.WriteLine("Goodbye!");
                return;

            default:
                ConsoleHelper.WriteError("Invalid option. Please choose between 0-5.");
                break;
        }
    }
    catch (Exception ex)
    {
        ConsoleHelper.WriteError(ex.Message);
        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();
    }
}
