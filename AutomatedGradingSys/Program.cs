using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "students.txt";
            string outputPath = "report.txt";

            StudentResultProcessor processor = new StudentResultProcessor();
            List<Student> students = processor.ReadStudentsFromFile(inputPath);
            processor.WriteReportToFile(students, outputPath);

            Console.WriteLine("✅ Report generated successfully.");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(" Input file not found: " + ex.Message);
        }
        catch (InvalidScoreFormatException ex)
        {
            Console.WriteLine("Invalid score format: " + ex.Message);
        }
        catch (MissingFieldException ex)
        {
            Console.WriteLine(" Missing field: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(" Unexpected error: " + ex.Message);
        }
    }
}
