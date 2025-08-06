using W21;

class Program
{
    static void Main()
    {
        var emp1 = new Employee("Anna", "Kowalska", 30);
        emp1.Scores.AddRange(new[] { 8, 9, 7, 10, 6 });

        var emp2 = new Employee("Piotr", "Nowak", 42);
        emp2.Scores.AddRange(new[] { 10, 7, 10, 9, 10 });

        var emp3 = new Employee("Ewa", "Wiśniewska", 35);
        emp3.Scores.AddRange(new[] { 10, 10, 9, 8, 9 });

        var employees = new List<Employee> { emp1, emp2, emp3 };
        var bestEmployee = employees.OrderByDescending(e => e.TotalScore).First();

        Console.WriteLine(" Najlepszy pracownik:");
        bestEmployee.Display();
    }
}
