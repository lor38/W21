using System;
using W21;

class Program
{
    static void Main()
    {
        var emp1 = new Employee("Robert", "Lorenc");
        var emp2 = new Employee("Sandra", "Lorenc");
        var emp3 = new Employee("Ameli", "Lorenc");
        var emp4 = new Employee("Julian", "Lorenc");

        string[] robertGrades = { "85.5", "abc", "92.3", "-5", "75" };
        ValidateGrades(emp1, robertGrades);

        
        emp2.AddGrade(5.0);
        emp2.AddGrade(5L);
        emp2.AddGrade(0f);

        emp3.AddGrade(2.0);
        emp3.AddGrade(2L);
        emp3.AddGrade(5f);

        emp4.AddGrade(6.0);
        emp4.AddGrade(5L);
        emp4.AddGrade(0f);

   
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("----Employee Statistics (Foreach Loop)----:");
        Console.ResetColor();
        foreach (var emp in new[] { emp1 })
        {
            var stats = emp.GetStatisticsWithForEach();
            PrintStats(emp, stats, ConsoleColor.Green);
        }

     
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("----Employee Statistics (For Loop)----:");
        Console.ResetColor();
        for (int i = 0; i < 1; i++)
        {
            var stats = emp2.GetStatisticsWithFor();
            PrintStats(emp2, stats, ConsoleColor.Yellow);
        }

       
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("----Employee Statistics (Do-While Loop)----:");
        Console.ResetColor();
        int j = 0;
        do
        {
            var stats = emp3.GetStatisticsWithDoWhile();
            PrintStats(emp3, stats, ConsoleColor.Magenta);
            j++;
        } while (j < 1);

        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("----Employee Statistics (While Loop)----:");
        Console.ResetColor();
        int k = 0;
        while (k < 1)
        {
            var stats = emp4.GetStatisticsWithWhile();
            PrintStats(emp4, stats, ConsoleColor.Blue);
            k++;
        }

        Console.ResetColor(); 
    }

    
    static void ValidateGrades(Employee employee, string[] grades)
    {
        foreach (var grade in grades)
        {
            if (!employee.TryAddGrade(grade, out string? error))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Error] Failed to add grade '{grade}' for {employee.Name} {employee.Surname}: {error}");
                Console.ResetColor();
            }
        }
    }

    
    static void PrintStats(Employee emp, Statistics stats, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"Employee: {emp.Name} {emp.Surname}");
        Console.WriteLine($"Average grade:     {stats.Average:N2}");
        Console.WriteLine($"Minimum grade:     {stats.Min}");
        Console.WriteLine($"Maximum grade:     {stats.Max}");
        Console.WriteLine(new string('-', 35));
        Console.ResetColor();
    }
}
