using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class InventoryLogger<T> where T : IInventoryEntity
{
    private List<T> _log = new();
    private readonly string _filePath;

    public InventoryLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void Add(T item)
    {
        _log.Add(item);
    }

    public List<T> GetAll()
    {
        return _log;
    }

    public void SaveToFile()
    {
        try
        {
            string json = JsonSerializer.Serialize(_log, new JsonSerializerOptions { WriteIndented = true });
            using StreamWriter writer = new StreamWriter(_filePath);
            writer.Write(json);
            Console.WriteLine("✅ Data saved to file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error saving to file: " + ex.Message);
        }
    }

    public void LoadFromFile()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                Console.WriteLine("⚠️ File not found. No data loaded.");
                return;
            }

            using StreamReader reader = new StreamReader(_filePath);
            string json = reader.ReadToEnd();
            _log = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            Console.WriteLine("✅ Data loaded from file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error loading from file: " + ex.Message);
        }
    }
}
