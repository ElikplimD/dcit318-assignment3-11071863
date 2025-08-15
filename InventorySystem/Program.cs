using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "inventory.json");

        // First session: seed and save
        InventoryApp app = new InventoryApp(filePath);
        app.SeedSampleData();
        app.SaveData();

        Console.WriteLine("\n🔄 Simulating new session...\n");

        // Second session: load and print
        InventoryApp newSession = new InventoryApp(filePath);
        newSession.LoadData();
        newSession.PrintAllItems();
    }
}
