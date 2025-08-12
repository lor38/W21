using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using W21;

public class EmployeeInFile : EmployeeBase
{
    private readonly string fileName;
    public List<GradeEntry> GetAllGrades() => LoadGrades();

    public EmployeeInFile(string name, string surname)
        : base(name, surname)
    {
        fileName = $"{name}_{surname}.txt";
    }

    public override void AddGrade(float grade)
    {
        AddGrade(grade, null);
    }

    public void AddGrade(float grade, string? comment)
    {
        if (grade < 0 || grade > 100)
            throw new ArgumentOutOfRangeException(nameof(grade), "Ocena musi być w zakresie od 0 do 100.");

        var entry = new GradeEntry
        {
            value = grade,
            dateAdded = DateTime.Now,
            comment = comment
        };

        using var writer = File.AppendText(fileName);
        writer.WriteLine(entry.ToString());
    }

    public override void AddGrade(long grade) => AddGrade((float)grade);

    public override void AddGrade(string grade)
    {
        Console.Write("Dodaj komentarz do oceny (opcjonalnie): ");
        string? commentInput = Console.ReadLine();

        AddGradeWithComment(grade, commentInput);
    }

    public void AddGradeWithComment(string grade, string? comment)
    {
        grade = grade.Trim().ToUpper();

        switch (grade)
        {
            case "A": AddGrade(100, comment); return;
            case "B": AddGrade(80, comment); return;
            case "C": AddGrade(60, comment); return;
            case "D": AddGrade(40, comment); return;
            case "E": AddGrade(20, comment); return;
        }

        if (!float.TryParse(grade, NumberStyles.Float, new CultureInfo("pl-PL"), out float numericGrade))
            throw new FormatException("Nieprawidłowy format liczby.");

        AddGrade(numericGrade, comment);
    }

    public override Statistics GetStatistics()
    {
        var grades = LoadGrades();
        var stats = new Statistics();

        if (grades.Count == 0)
        {
            stats.Average = 0;
            stats.Min = 0;
            stats.Max = 0;
            stats.AverageLetter = 'E';
            return stats;
        }

        stats.Average = grades.Average(g => g.value);
        stats.Min = grades.Min(g => g.value);
        stats.Max = grades.Max(g => g.value);
        stats.AverageLetter = GetLetterGrade(stats.Average);

        return stats;
    }

    public override Statistics GetStatisticsWithForEach()
    {
        var grades = LoadGrades();
        var stats = new Statistics();

        if (grades.Count == 0)
        {
            stats.Average = 0;
            stats.Min = 0;
            stats.Max = 0;
            stats.AverageLetter = 'E';
            return stats;
        }

        float sum = 0;
        float min = float.MaxValue;
        float max = float.MinValue;

        foreach (var grade in grades)
        {
            sum += grade.value;
            min = Math.Min(min, grade.value);
            max = Math.Max(max, grade.value);
        }

        stats.Average = sum / grades.Count;
        stats.Min = min;
        stats.Max = max;
        stats.AverageLetter = GetLetterGrade(stats.Average);

        return stats;
    }

    private List<GradeEntry> LoadGrades()
    {
        var grades = new List<GradeEntry>();

        if (File.Exists(fileName))
        {
            var lines = File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                grades.Add(GradeEntry.Parse(line));
            }
        }

        return grades;
    }

    public void DeleteGrade(int index)
    {
        var grades = LoadGrades();
        if (index < 0 || index >= grades.Count)
            throw new ArgumentOutOfRangeException(nameof(index), "Nieprawidłowy indeks.");

        grades.RemoveAt(index);
        OverwriteFile(grades);
    }

    public void EditGrade(int index, float newValue, string? newComment)
    {
        var grades = LoadGrades();
        if (index < 0 || index >= grades.Count)
            throw new ArgumentOutOfRangeException(nameof(index), "Nieprawidłowy indeks.");

        grades[index].value = newValue;
        grades[index].comment = newComment;
        grades[index].dateAdded = DateTime.Now;

        OverwriteFile(grades);
    }

    private void OverwriteFile(List<GradeEntry> grades)
    {
        using var writer = new StreamWriter(fileName, false);
        foreach (var grade in grades)
        {
            writer.WriteLine(grade.ToString());
        }
    }

    private char GetLetterGrade(float average) => average switch
    {
        >= 80 => 'A',
        >= 60 => 'B',
        >= 40 => 'C',
        >= 20 => 'D',
        _ => 'E'
    };
}
