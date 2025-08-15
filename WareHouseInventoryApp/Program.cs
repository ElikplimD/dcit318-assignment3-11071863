using System;

class Program
{
    static void Main()
    {
        var manager = new WareHouseManager();
        manager.SeedData();

        Console.WriteLine("📦 Grocery Items:");
        manager.PrintAllItems(manager.Groceries);

        Console.WriteLine("\n🔌 Electronic Items:");
        manager.PrintAllItems(manager.Electronics);

        Console.WriteLine("\n🚫 Testing Error Handling:");
        try
        {
            manager.Groceries.AddItem(new GroceryItem(101, "Duplicate Milk", 5, DateTime.Now.AddDays(5)));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Duplicate Test: {ex.Message}");
        }

        manager.RemoveItemById(manager.Electronics, 999); // Non-existent
        manager.IncreaseStock(manager.Groceries, 102, -5); // Invalid quantity
    }
}
