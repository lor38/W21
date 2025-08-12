using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using W21;

class Program
{
    static List<IEmployee> employees = new();
    static bool hasShownGradeInstructions = false;
    static void Main()
    {
        LoadEmployeesFromFiles();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('═', 60));
        TypeEffect("  WITAMY W APLIKACJI OCEN PRACOWNIKA", 20);
        Console.WriteLine("  Autor: Robert Lorenc");
        Console.WriteLine("  Projekt: Wyzwanie w 21 Dni — edu.gotoit.pl");
        Console.WriteLine(new string('═', 60));
        Console.ResetColor();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n MENU:");
            Console.WriteLine(" 1. Dodaj pracownika");
            Console.WriteLine(" 2. Pokaż statystyki pracowników");
            Console.WriteLine(" 3. Usuń pracownika");
            Console.WriteLine(" 4. Dodaj ocenę istniejącemu pracownikowi");
            Console.WriteLine(" 5. Edytuj ocenę pracownika");

            Console.WriteLine(" 6. Wyjdź");
            Console.ResetColor();

            Console.Write(" Wybierz opcję: ");
            string? option = Console.ReadLine();

            switch (option)
            {
                case "1": AddEmployee(); break;
                case "2": ShowAllStatistics(); break;
                case "3": RemoveEmployee(); break;
                case "4": AddGradeToExistingEmployee(); break;
                case "5":
                    EditGradeForEmployee();
                    break;

                case "6":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine();
                    TypeEffect(" Dziękujemy za skorzystanie z aplikacji! Miłego dnia :-)", 20);
                    Console.ResetColor();
                    Pause("\n Naciśnij Enter, aby zamknąć...");
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Nieprawidłowy wybór. Spróbuj ponownie.");
                    Console.ResetColor();
                    Pause();
                    break;
            }
        }
    }

    static void LoadEmployeesFromFiles()
    {
        var employeeFiles = Directory.GetFiles(".", "*.txt");
        var supervisorDir = Path.Combine(AppContext.BaseDirectory, "Data", "Supervisors");
        var supervisorFiles = Directory.Exists(supervisorDir)
            ? Directory.GetFiles(supervisorDir, "*.txt")
            : Array.Empty<string>();

        foreach (var file in employeeFiles)
        {
            var fileName = Path.GetFileNameWithoutExtension(file);
            var parts = fileName.Split('_');
            if (parts.Length == 2)
            {
                employees.Add(new EmployeeInFile(parts[0], parts[1]));
            }
        }

        foreach (var file in supervisorFiles)
        {
            var fileName = Path.GetFileNameWithoutExtension(file);
            var parts = fileName.Split('_');
            if (parts.Length == 3 && parts[0] == "Supervisor")
            {
                employees.Add(new SupervisorInFile(parts[1], parts[2]));
            }
        }
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
        } while (string.IsNullOrWhiteSpace(firstNameInput));

        do
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" Podaj nazwisko pracownika: ");
            Console.ResetColor();
            lastNameInput = Console.ReadLine()?.Trim();
        } while (string.IsNullOrWhiteSpace(lastNameInput));

        Console.WriteLine("\n Wybierz typ pracownika:");
        Console.WriteLine(" 1. Pracownik ");
        Console.WriteLine(" 2. Kierownik");
        string? typeOption = Console.ReadLine()?.Trim();

        IEmployee employee = typeOption switch
        {
            "1" => new EmployeeInFile(firstNameInput, lastNameInput),
            "2" => new SupervisorInFile(firstNameInput, lastNameInput),
            _ => null
        };

        if (employee == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Nieprawidłowy wybór typu pracownika.");
            Console.ResetColor();
            Pause();
            return;
        }

        if (!hasShownGradeInstructions)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n ════════════════════════════════════════════════════════════");
            if (employee is SupervisorInFile)
            {
                Console.WriteLine(" Wpisz oceny dla kierownika, wpisz 'q' aby zakończyć:");
                Console.WriteLine(" Możesz podać ocenę jako:");
                Console.WriteLine("     6 = 100   5 = 80   4 = 60   3 = 40");
                Console.WriteLine("     3- = 35   2+ = 25   2 = 20   1 = 0");
            }
            else
            {
                Console.WriteLine(" Wpisz oceny pracownika, wpisz 'q' aby zakończyć:");
                Console.WriteLine(" Możesz podać ocenę jako:");
                Console.WriteLine("    Liczbę od  0 do 100 ");
                Console.WriteLine("    Literę od A do E:");
                Console.WriteLine("     A = 100   B = 80   C = 60   D = 40   E = 20");
            }
            Console.WriteLine("════════════════════════════════════════════════════════════\n");
            Console.ResetColor();
            hasShownGradeInstructions = true;
        }

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" Ocena: ");
            Console.ResetColor();
            string? gradeInput = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(gradeInput)) continue;
            if (gradeInput.ToLower() == "q") break;

            try
            {
                employee.AddGrade(gradeInput);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" Błąd: {ex.Message}");
                Console.ResetColor();
            }
        }

        employees.Add(employee);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n Dodano pracownika: {employee.Name} {employee.Surname}");
        Console.ResetColor();
        Pause();
    }

    static void AddGradeToExistingEmployee()
    {
        if (employees.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Brak pracowników.");
            Console.ResetColor();
            Pause();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n  Wybierz pracownika:");
        for (int i = 0; i < employees.Count; i++)
        {
            Console.WriteLine($" {i}. {employees[i].Name} {employees[i].Surname}");
        }
        Console.ResetColor();

        Console.Write("\n Podaj indeks: ");
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 0 || index >= employees.Count)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  Nieprawidłowy indeks.");
            Console.ResetColor();
            Pause();
            return;
        }

        var employee = employees[index];

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n Wpisz oceny (q aby zakończyć):");
        Console.ResetColor();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" Ocena: ");
            Console.ResetColor();

            var gradeInput = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(gradeInput)) continue;
            if (gradeInput.Equals("q", StringComparison.OrdinalIgnoreCase)) break;

            try
            {
                employee.AddGrade(gradeInput);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Dodano.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" Błąd: {ex.Message}");
                Console.ResetColor();
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($" Zaktualizowano oceny: {employee.Name} {employee.Surname}");
        Console.ResetColor();
        Pause();
    }

    static void ShowAllStatistics()
    {
        if (employees.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Brak pracowników do wyświetlenia.");
            Console.ResetColor();
            Pause();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n STATYSTYKI WSZYSTKICH PRACOWNIKÓW\n");
        Console.ResetColor();

        foreach (var item in employees
                     .Select(e => (e, s: e.GetStatisticsWithForEach()))
                     .OrderByDescending(x => x.s.Average))
        {
            DisplayStatistics(item.e, item.s, ConsoleColor.Green);
        }

        Pause();
    }

    static void DisplayStatistics(IEmployee employee, Statistics statistics, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($" Pracownik:         {employee.Name} {employee.Surname}");
        Console.WriteLine($" Średnia ocen:      {statistics.Average:N2}");
        Console.WriteLine($" Najniższa ocena:   {statistics.Min}");
        Console.WriteLine($" Najwyższa ocena:   {statistics.Max}");

        if (!statistics.IsSupervisor)
        {
            Console.WriteLine($" Ocena literowa:    {statistics.AverageLetter}");
        }

        Console.ForegroundColor = statistics.GetDescriptionColor();
        Console.WriteLine($" Ocena opisowa:     {statistics.GetDescription()}");

        Console.ResetColor();
        Console.WriteLine(new string('═', 60));
    }

    static void RemoveEmployee()
    {
        if (employees.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Brak pracowników do usunięcia.");
            Console.ResetColor();
            Pause();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n  Lista pracowników:");
        for (int i = 0; i < employees.Count; i++)
        {
            Console.WriteLine($" {i}. {employees[i].Name} {employees[i].Surname}");
        }
        Console.ResetColor();

        Console.Write("\n Podaj indeks pracownika do usunięcia: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < employees.Count)
        {
            var employee = employees[index];
            string? fileToDelete = null;

            if (employee is EmployeeInFile)
            {
                fileToDelete = $"{employee.Name}_{employee.Surname}.txt";
            }
            else if (employee is SupervisorInFile)
            {
                fileToDelete = Path.Combine(AppContext.BaseDirectory, "Data", "Supervisors", $"Supervisor_{employee.Name}_{employee.Surname}.txt");
            }

            if (fileToDelete != null && File.Exists(fileToDelete))
            {
                File.Delete(fileToDelete);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"  Usunięto plik: {fileToDelete}");
            }

            employees.RemoveAt(index);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Usunięto pracownika: {employee.Name} {employee.Surname}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  Nieprawidłowy indeks.");
        }

        Console.ResetColor();
        Pause();
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
    static void EditGradeForEmployee()
    {
        if (employees.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Brak pracowników.");
            Console.ResetColor();
            Pause();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n Wybierz pracownika:");
        for (int i = 0; i < employees.Count; i++)
        {
            Console.WriteLine($" {i}. {employees[i].Name} {employees[i].Surname}");
        }
        Console.ResetColor();

        Console.Write("\n Podaj indeks: ");
        if (!int.TryParse(Console.ReadLine(), out int empIndex) || empIndex < 0 || empIndex >= employees.Count)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Nieprawidłowy indeks.");
            Console.ResetColor();
            Pause();
            return;
        }

        var employee = employees[empIndex];
        List<GradeEntry> grades;
        if (employee is EmployeeInFile empFile)
            grades = empFile.GetAllGrades();
        else if (employee is SupervisorInFile supFile)
            grades = supFile.GetAllGrades();
        else
        {
            Console.WriteLine(" Ten typ pracownika nie obsługuje edycji.");
            Pause();
            return;
        }

        if (grades.Count == 0)
        {
            Console.WriteLine(" Ten pracownik nie ma żadnych ocen.");
            Pause();
            return;
        }

        Console.WriteLine("\n Oceny:");
        for (int i = 0; i < grades.Count; i++)
        {
            Console.WriteLine($" {i}. {grades[i].value} ({grades[i].comment}) - {grades[i].dateAdded:g}");
        }

        Console.Write("\n Podaj indeks oceny do edycji: ");
        if (!int.TryParse(Console.ReadLine(), out int gradeIndex) || gradeIndex < 0 || gradeIndex >= grades.Count)
        {
            Console.WriteLine(" Nieprawidłowy indeks.");
            Pause();
            return;
        }

        Console.Write(" Nowa wartość oceny (0–100): ");
        if (!float.TryParse(Console.ReadLine(), out float newValue) || newValue < 0 || newValue > 100)
        {
            Console.WriteLine(" Nieprawidłowa wartość.");
            Pause();
            return;
        }

        Console.Write(" Nowy komentarz (opcjonalnie): ");
        string? newComment = Console.ReadLine();

        if (employee is EmployeeInFile)
            ((EmployeeInFile)employee).EditGrade(gradeIndex, newValue, newComment);
        else if (employee is SupervisorInFile)
            ((SupervisorInFile)employee).EditGrade(gradeIndex, newValue, newComment);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" Ocena została zaktualizowana.");
        Console.ResetColor();
        Pause();
    }

    static void Pause(string message = " Naciśnij Enter, aby kontynuować...")
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write(message);
        Console.ResetColor();
        Console.ReadLine();
    }
}
