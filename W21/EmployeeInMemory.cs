using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace W21
{
    public class EmployeeInMemory : EmployeeBase
    {
        private readonly List<float> grades = new();

        public EmployeeInMemory(string name, string surname)
            : base(name, surname)
        {
        }

        public override void AddGrade(float grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentOutOfRangeException(nameof(grade), "Ocena musi być w zakresie od 0 do 100.");

            grades.Add(grade);

            // Wywołanie zdarzenia z klasy bazowej
            OnGradeAdded();
        }

        public override void AddGrade(long grade) => AddGrade((float)grade);

        public override void AddGrade(string grade)
        {
            if (string.IsNullOrWhiteSpace(grade))
                throw new ArgumentException("Ocena nie może być pusta.", nameof(grade));

            grade = grade.Trim().ToUpper();

            switch (grade)
            {
                case "A": AddGrade(100); return;
                case "B": AddGrade(80); return;
                case "C": AddGrade(60); return;
                case "D": AddGrade(40); return;
                case "E": AddGrade(20); return;
            }

            if (!float.TryParse(grade, NumberStyles.Float, new CultureInfo("pl-PL"), out float numericGrade))
                throw new FormatException("Nieprawidłowy format liczby. Wpisz np. '9,3' lub literę od A do E.");

            AddGrade(numericGrade);
        }

        public override Statistics GetStatistics()
        {
            var stats = new Statistics();

            if (grades.Count == 0)
            {
                stats.Average = 0;
                stats.Min = 0;
                stats.Max = 0;
                stats.AverageLetter = 'E';
                return stats;
            }

            stats.Average = grades.Average();
            stats.Min = grades.Min();
            stats.Max = grades.Max();
            stats.AverageLetter = GetLetterGrade(stats.Average);

            return stats;
        }

        public override Statistics GetStatisticsWithForEach()
        {
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
                sum += grade;
                min = Math.Min(min, grade);
                max = Math.Max(max, grade);
            }

            stats.Average = sum / grades.Count;
            stats.Min = min;
            stats.Max = max;
            stats.AverageLetter = GetLetterGrade(stats.Average);

            return stats;
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
}
