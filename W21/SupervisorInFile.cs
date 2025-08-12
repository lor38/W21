using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace W21
{
    public class SupervisorInFile : Person, IEmployee
    {
        private readonly string filePath;
        private readonly List<GradeEntry> grades = new();
        public List<GradeEntry> GetAllGrades() => new(grades);

        public SupervisorInFile(string name, string surname)
            : base(name, surname)
        {
            var dir = Path.Combine(AppContext.BaseDirectory, "Data", "Supervisors");
            Directory.CreateDirectory(dir);
            filePath = Path.Combine(dir, $"Supervisor_{Name}_{Surname}.txt");

            LoadGradesFromFile();
        }

        public void AddGrade(float grade)
        {
            AddGrade(grade, null);
        }

        public void AddGrade(long grade) => AddGrade((float)grade);

        public void AddGrade(string grade)
        {
            Console.Write("Dodaj komentarz do oceny (opcjonalnie): ");
            string? commentInput = Console.ReadLine();
            AddGradeWithComment(grade, commentInput);
        }

        public void AddGradeWithComment(string grade, string? comment)
        {
            if (string.IsNullOrWhiteSpace(grade))
                throw new ArgumentException("Ocena nie może być pusta.");

            grade = grade.Trim();

            float value = grade switch
            {
                "6" => 100,
                "5" => 80,
                "4" => 60,
                "3" => 40,
                "3-" or "-3" => 35,
                "2+" or "+2" => 25,
                "2" => 20,
                "1" => 0,
                _ => throw new ArgumentException($"Nieznana ocena: '{grade}'")
            };

            AddGrade(value, comment);
        }

        private void AddGrade(float value, string? comment)
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value), "Ocena musi być w zakresie 0–100.");

            var entry = new GradeEntry
            {
                value = value,
                comment = comment,
                dateAdded = DateTime.Now
            };

            grades.Add(entry);
            File.AppendAllText(filePath, entry.ToString() + Environment.NewLine);
        }

        public Statistics GetStatistics()
        {
            var stats = new Statistics { IsSupervisor = true };

            if (grades.Count == 0)
            {
                stats.Average = 0;
                stats.Min = 0;
                stats.Max = 0;
                return stats;
            }

            stats.Average = grades.Average(g => g.value);
            stats.Min = grades.Min(g => g.value);
            stats.Max = grades.Max(g => g.value);

            return stats;
        }

        public Statistics GetStatisticsWithForEach()
        {
            var stats = new Statistics { IsSupervisor = true };

            if (grades.Count == 0)
            {
                stats.Average = 0;
                stats.Min = 0;
                stats.Max = 0;
                return stats;
            }

            float sum = 0;
            float min = float.MaxValue;
            float max = float.MinValue;

            foreach (var g in grades)
            {
                sum += g.value;
                min = Math.Min(min, g.value);
                max = Math.Max(max, g.value);
            }

            stats.Average = sum / grades.Count;
            stats.Min = min;
            stats.Max = max;

            return stats;
        }

        public void DeleteGrade(int index)
        {
            if (index < 0 || index >= grades.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Nieprawidłowy indeks.");

            grades.RemoveAt(index);
            OverwriteFile();
        }

        public void EditGrade(int index, float newValue, string? newComment)
        {
            if (index < 0 || index >= grades.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Nieprawidłowy indeks.");

            grades[index].value = newValue;
            grades[index].comment = newComment;
            grades[index].dateAdded = DateTime.Now;

            OverwriteFile();
        }

        private void OverwriteFile()
        {
            using var writer = new StreamWriter(filePath, false);
            foreach (var grade in grades)
            {
                writer.WriteLine(grade.ToString());
            }
        }

        private void LoadGradesFromFile()
        {
            if (!File.Exists(filePath)) return;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                try
                {
                    grades.Add(GradeEntry.Parse(line));
                }
                catch
                {
                    
                }
            }
        }
    }
}