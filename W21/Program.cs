using System;
using W21;

class Program
{
    static void Main()
    {
        var emp1 = new Employee("Robert", "Lorenc");

       
        emp1.AddGrade(85.5f);        
        emp1.AddGrade(92.3);          
        emp1.AddGrade(75L);           

        
        if (!emp1.TryAddGrade("88.8", out string? err1) && err1 != null)
            Console.WriteLine($"Error: {err1}");

        if (!emp1.TryAddGrade("abc", out string? err2) && err2 != null)
            Console.WriteLine($"Error: {err2}");

        if (!emp1.TryAddGrade("", out string? err3) && err3 != null)
            Console.WriteLine($"Error: {err3}");

        if (!emp1.TryAddGrade("150", out string? err4) && err4 != null)
            Console.WriteLine($"Error: {err4}");

        emp1.AddGrade(3);             
        emp1.AddGrade(5);

        var emp2 = new Employee("Sandra", "Lorenc");
        emp2.AddGrade(5.0);
        emp2.AddGrade(5L);
        emp2.AddGrade(0f);

        var emp3 = new Employee("Ameli", "Lorenc");
        emp3.AddGrade(2.0);
        emp3.AddGrade(2L);
        emp3.AddGrade(5f);

        var emp4 = new Employee("Julian", "Lorenc");
        emp4.AddGrade(6.0);
        emp4.AddGrade(5L);
        emp4.AddGrade(0f);

        var employees = new[] { emp1, emp2, emp3, emp4 };

        Console.WriteLine("----Employee Statistics----:");

        foreach (var emp in employees)
        {
            var stats = emp.GetStatistics();

            Console.WriteLine($"Employee: {emp.Name} {emp.Surname}");
            Console.WriteLine($"Average grade:     {stats.Average:N2}");
            Console.WriteLine($"Minimum grade:     {stats.Min}");
            Console.WriteLine($"Maximum grade:     {stats.Max}");
            Console.WriteLine(new string('-', 35));

        }
    }
}
