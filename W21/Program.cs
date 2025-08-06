
using W21;

class Program
{
    static void Main()
    {


        var emp1 = new Employee("Robert", "Lorenc");
        emp1.AddGrade(4);
        emp1.AddGrade(3);
        emp1.AddGrade(5);

        var emp2 = new Employee("Sandra", "Lorenc");
        emp2.AddGrade(5);
        emp2.AddGrade(5);
        emp2.AddGrade(5);

        var emp3 = new Employee("Ameli", "Lorenc");
        emp3.AddGrade(2);
        emp3.AddGrade(2);
        emp3.AddGrade(5);

        var emp4 = new Employee("Julian", "Lorenc");
        emp4.AddGrade(6);
        emp4.AddGrade(5);
        emp4.AddGrade(0);

        var employees = new[] { emp1, emp2, emp3, emp4 };


        foreach (var emp in employees)
        {
            var stats = emp.GetStatistics();

            Console.WriteLine($"Pracownik: {emp.Name} {emp.Surname}");
            Console.WriteLine($"Średnia ocen: {stats.Average:N2}");
            Console.WriteLine($"Ocena minimalna: {stats.Min}");
            Console.WriteLine($"Ocena maksymalna: {stats.Max}");
            Console.WriteLine(new string('-', 30));
        }


    }
}