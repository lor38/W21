using System;
using System.Collections.Generic;
using System.Linq;

namespace W21
{
    public class Supervisor : Person, IEmployee
    {
        private readonly List<float> grades = new();

        public Supervisor(string name, string surname)
            : base(name, surname)
        {
        }

        public void AddGrade(float grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentOutOfRangeException(nameof(grade), "Ocena musi być w zakresie od 0 do 100.");

            grades.Add(grade);
        }

        public void AddGrade(long grade) => AddGrade((float)grade);

        public void AddGrade(string grade)
        {
            if (string.IsNullOrWhiteSpace(grade))
                throw new ArgumentException("Ocena nie może być pusta.", nameof(grade));

            grade = grade.Trim();

            float value = grade switch
            {
                "6" => 100,
                "5" => 80,
                "4" => 60,
                "3" => 40,
                "-3" or "3-" => 35,
                "2+" or "+2" => 25,
                "2" => 20,
                "1" => 0,
                _ => throw new ArgumentException($"Nieznana ocena: '{grade}'")
            };

            AddGrade(value);
        }

        public Statistics GetStatistics()
        {
            var stats = new Statistics();

            if (grades.Count == 0)
            {
                stats.Average = 0;
                stats.Min = 0;
                stats.Max = 0;
                return stats;
            }

            stats.Average = grades.Average();
            stats.Min = grades.Min();
            stats.Max = grades.Max();

            return stats;
        }

        public Statistics GetStatisticsWithForEach()
        {
            var stats = new Statistics();

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

            foreach (var grade in grades)
            {
                sum += grade;
                min = Math.Min(min, grade);
                max = Math.Max(max, grade);
            }

            stats.Average = sum / grades.Count;
            stats.Min = min;
            stats.Max = max;

            return stats;
        }
    }
}
