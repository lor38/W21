using System;
using System.Globalization;

namespace W21
{
    public class Employee
    {
        private List<float> grades = new List<float>();

        public string Name { get; private set; }
        public string Surname { get; private set; }

        public Employee(string name, string surname)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name), "Imię nie może być puste.");
            this.Surname = surname ?? throw new ArgumentNullException(nameof(surname), "Nazwisko nie może być puste.");
        }

        public void AddGrade(float grade)
        {
            if (grade < 0 || grade > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(grade), "Ocena musi być w zakresie od 0 do 100.");
            }

            grades.Add(grade);
        }

        public void AddGrade(long grade)
        {
            if (grade < 0 || grade > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(grade), "Ocena musi być w zakresie od 0 do 100.");
            }

            grades.Add((float)grade);
        }

        public void AddGrade(string grade)
        {
            if (string.IsNullOrWhiteSpace(grade))
            {
                throw new ArgumentException("Ocena nie może być pusta.", nameof(grade));
            }

            if (!float.TryParse(grade, NumberStyles.Float, new CultureInfo("pl-PL"), out float numericGrade))
            {
                throw new FormatException("Podana wartość nie jest prawidłową liczbą. Wpisz liczbę w formacie np. '9,3'.");
            }

            if (numericGrade < 0 || numericGrade > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(grade), "Ocena musi być w zakresie od 0 do 100.");
            }

            AddGrade(numericGrade);
        }




        public Statistics GetStatistics()
        {
            var statistics = new Statistics
            {
                Average = 0,
                Max = float.MinValue,
                Min = float.MaxValue
            };

            if (grades.Any())
            {
                statistics.Average = grades.Average();
                statistics.Max = grades.Max();
                statistics.Min = grades.Min();
            }

            statistics.AverageLetter = GetLetterGrade(statistics.Average);
            return statistics;
        }

        public Statistics GetStatisticsWithForEach()
        {
            var statistics = new Statistics();

            if (grades.Count == 0)
            {
                statistics.Average = 0;
                statistics.Min = 0;
                statistics.Max = 0;
                statistics.AverageLetter = 'E';
                return statistics;
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

            statistics.Average = sum / grades.Count;
            statistics.Min = min;
            statistics.Max = max;
            statistics.AverageLetter = GetLetterGrade(statistics.Average);

            return statistics;
        }

        private char GetLetterGrade(float average)
        {
            return average switch
            {
                >= 80 => 'A',
                >= 60 => 'B',
                >= 40 => 'C',
                >= 20 => 'D',
                _ => 'E'
            };
        }
    }
}
