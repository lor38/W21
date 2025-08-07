using System;
using W21;

class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('═', 60));
        Console.WriteLine("  WITAMY W APLIKACJI OCEN PRACOWNIKA");
        Console.WriteLine("  Autor: Robert Lorenc");
        Console.WriteLine("  Projekt: Wyzwanie w 21 Dni — edu.gotoit.pl");
        Console.WriteLine(new string('═', 60));
        Console.ResetColor();

        Console.WriteLine(new string('═', 60));
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("\n Podaj imię pracownika: ");
        Console.ResetColor();
        string? nameInput = Console.ReadLine();
        string name = string.IsNullOrWhiteSpace(nameInput) ? "Nieznane" : nameInput.Trim();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(" Podaj nazwisko pracownika: ");
        Console.ResetColor();
        string? surnameInput = Console.ReadLine();
        string surname = string.IsNullOrWhiteSpace(surnameInput) ? "Nieznane" : surnameInput.Trim();

        var employee = new Employee(name, surname);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n Wpisz oceny pracownika (wpisz 'q' aby zakończyć i podliczyć):\n");
        Console.ResetColor();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" Ocena: ");
            Console.ResetColor();
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Uwaga: Nie wpisano żadnej wartości. Spróbuj ponownie.");
                Console.ResetColor();
                continue;
            }

            input = input.Trim();

            if (input.ToLower() == "q")
                break;

            if (!employee.TryAddGrade(input, out string? error))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Błąd: Nie udało się dodać oceny '{input}'. Powód: {error}");
                Console.ResetColor();
            }
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('═', 60));
        Console.WriteLine("\n STATYSTYKI PRACOWNIKA\n");
        Console.ResetColor();

        var stats = employee.GetStatisticsWithForEach();
        WypiszStatystyki(employee, stats, ConsoleColor.Green);

        Console.ResetColor();
    }

    static void WypiszStatystyki(Employee emp, Statistics stats, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($" Pracownik:         {emp.Name} {emp.Surname}");
        Console.WriteLine($" Średnia ocen:      {stats.Average:N2}");
        Console.WriteLine($" Najniższa ocena:   {stats.Min}");
        Console.WriteLine($" Najwyższa ocena:   {stats.Max}");
        Console.WriteLine($" Ocena literowa:    {stats.AverageLetter}");
        Console.ResetColor();

        string description;
        ConsoleColor descColor;

        switch (stats.AverageLetter)
        {
            case 'A':
                description = "Wybitny";
                descColor = ConsoleColor.DarkGreen;
                break;
            case 'B':
                description = "Bardzo dobry";
                descColor = ConsoleColor.Green;
                break;
            case 'C':
                description = "Dobry";
                descColor = ConsoleColor.Yellow;
                break;
            case 'D':
                description = "Dostateczny";
                descColor = ConsoleColor.DarkYellow;
                break;
            default:
                description = "Niedostateczny";
                descColor = ConsoleColor.Red;
                break;
        }

        Console.ForegroundColor = descColor;
        Console.WriteLine($" Ocena opisowa:     {description}");
        Console.ResetColor();
        Console.WriteLine(new string('═', 60));
    }
}
