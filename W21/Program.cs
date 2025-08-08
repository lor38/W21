using System.Threading;

using W21;

class Program
{
    static List<Employee> employees = new();
    static bool hasShownGradeInstructions = false;

    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('═', 60));
        TypeEffect("  WITAMY W APLIKACJI OCEN PRACOWNIKA", 20);
        Console.WriteLine("  Autor: Robert Lorenc", 20);
        Console.WriteLine("  Projekt: Wyzwanie w 21 Dni — edu.gotoit.pl", 20);
        Console.WriteLine(new string('═', 60));
        Console.ResetColor();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n MENU:");
            Console.WriteLine(" 1. Dodaj pracownika");
            Console.WriteLine(" 2. Pokaż statystyki pracownikow");
            Console.WriteLine(" 3. Wyjdź");
            Console.ResetColor();

            Console.Write(" Wybierz opcję: ");
            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddEmployee();
                    break;
                case "2":
                    ShowAllStatistics();
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine();
                    TypeEffect(" Dziękujemy za skorzystanie z aplikacji! Miłego dnia :-) ", 20);
                    Console.ResetColor();
                    Console.WriteLine("\n Naciśnij dowolny klawisz, aby zamknąć...");
                    Console.ReadKey();
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Nieprawidłowy wybór. Spróbuj ponownie.");
                    Console.ResetColor();
                    break;
            }

        }
    }

    static void TypeEffect(string message, int delay = 40)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }
        Console.WriteLine();
    }

    static void AddEmployee()
    {
        Console.WriteLine(new string('═', 60));

        string? firstNameInput;
        string? lastNameInput;

        do
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\n Podaj imię pracownika: ");
            Console.ResetColor();
            firstNameInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(firstNameInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Imię nie może być puste. Spróbuj ponownie.");
                Console.ResetColor();
            }

        } while (string.IsNullOrWhiteSpace(firstNameInput));

        do
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" Podaj nazwisko pracownika: ");
            Console.ResetColor();
            lastNameInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(lastNameInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Nazwisko nie może być puste. Spróbuj ponownie.");
                Console.ResetColor();
            }

        } while (string.IsNullOrWhiteSpace(lastNameInput));

        var employee = new Employee(firstNameInput, lastNameInput);

        if (!hasShownGradeInstructions)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n ════════════════════════════════════════════════════════════");
            Console.WriteLine(" Wpisz oceny pracownika wpisz 'q' aby zakończyć:");
            Console.WriteLine(" Możesz podać ocenę jako:");
            Console.WriteLine("    Liczbę od  0 do 100 ");
            Console.WriteLine("    Literę od A do E:");
            Console.WriteLine("     A = 100   B = 80   C = 60   D = 40   E = 20");
            Console.WriteLine("════════════════════════════════════════════════════════════\n");
            Console.ResetColor();

            hasShownGradeInstructions = true; 
        }

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" Ocena: ");
            Console.ResetColor();
            string? gradeInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(gradeInput))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" Uwaga: Nie wpisano żadnej wartości. Spróbuj ponownie.");
                Console.ResetColor();
                continue;
            }

            gradeInput = gradeInput.Trim();

            if (gradeInput.ToLower() == "q")
                break;

            try
            {
                employee.AddGrade(gradeInput);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" Błąd: Nie udało się dodać oceny '{gradeInput}'. Powód: {ex.Message}");
                Console.ResetColor();
            }
        }

        employees.Add(employee);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n Dodano pracownika: {employee.Name} {employee.Surname}");
        Console.ResetColor();
    }


    static void ShowAllStatistics()
    {
        if (employees.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Brak pracowników do wyświetlenia.");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n STATYSTYKI WSZYSTKICH PRACOWNIKÓW\n");
        Console.ResetColor();

        foreach (var employee in employees)
        {
            var statistics = employee.GetStatisticsWithForEach();
            DisplayStatistics(employee, statistics, ConsoleColor.Green);
        }
    }

    static void DisplayStatistics(Employee employee, Statistics statistics, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($" Pracownik:         {employee.Name} {employee.Surname}");
        Console.WriteLine($" Średnia ocen:      {statistics.Average:N2}");
        Console.WriteLine($" Najniższa ocena:   {statistics.Min}");
        Console.WriteLine($" Najwyższa ocena:   {statistics.Max}");
        Console.WriteLine($" Ocena literowa:    {statistics.AverageLetter}");
        Console.ResetColor();

        string description;
        ConsoleColor descriptionColor;

        switch (statistics.AverageLetter)
        {
            case 'A':
                description = "Wybitny";
                descriptionColor = ConsoleColor.DarkGreen;
                break;
            case 'B':
                description = "Bardzo dobry";
                descriptionColor = ConsoleColor.Green;
                break;
            case 'C':
                description = "Dobry";
                descriptionColor = ConsoleColor.Yellow;
                break;
            case 'D':
                description = "Dostateczny";
                descriptionColor = ConsoleColor.DarkYellow;
                break;
            default:
                description = "Niedostateczny DO ZWOLNIENIA  :-(";
                descriptionColor = ConsoleColor.Red;
                break;
        }

        Console.ForegroundColor = descriptionColor;
        Console.WriteLine($" Ocena opisowa:     {description}");
        Console.ResetColor();
        Console.WriteLine(new string('═', 60));
    }
}
