using W21;


class Program
{
    static void Main()
    {
        var emp1 = new Employee("Anna", "Kowalska", 30);
        foreach (var score in new[] { 8, 9, 7, 10, 6 })
        {
            emp1.AddScore(score);
        }

        var emp2 = new Employee("Piotr", "Nowak", 42);
        foreach (var score in new[] { 10, 7, 10, 9, -10 })
        {
            emp2.AddScore(score);
        }

        var emp3 = new Employee("Ewa", "Wiśniewska", 35);
        foreach (var score in new[] { 10, -50, 9, 8, 9 })
        {
            emp3.AddScore(score);
        }

        var employees = new List<Employee> { emp1, emp2, emp3 };
        var bestEmployee = employees.OrderByDescending(e => e.TotalScore).First();
        var worstEmployee = employees.OrderBy(e => e.TotalScore).First();

        Console.WriteLine("Najlepszy pracownik:");
        bestEmployee.Display();

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine(" Najgorszy pracownik:");
        worstEmployee.Display();
    }
}
