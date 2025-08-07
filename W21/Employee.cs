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
            this.Name = name;
            this.Surname = surname;
        }

        public void AddGrade(float grade)
        {
            if (grade < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(grade), "Ocena nie może być mniejsza niż 0.");
            }
            else if (grade > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(grade), "Ocena nie może być większa niż 100.");
            }

            grades.Add(grade);
        }

        public void AddGrade(string grade)
        {
            if (string.IsNullOrWhiteSpace(grade))
            {
                throw new ArgumentException("Ocena nie może być pusta.", nameof(grade));
            }

            if (!float.TryParse(grade, NumberStyles.Float, CultureInfo.InvariantCulture, out float numericGrade))
            {
                throw new ArgumentException("Podana wartość nie jest prawidłową liczbą.", nameof(grade));
            }

            AddGrade(numericGrade);
        }

        public void AddGrade(double grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentOutOfRangeException(nameof(grade), "Ocena musi być w zakresie od 0 do 100.");

            grades.Add((float)grade);
        }

        public void AddGrade(long grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentOutOfRangeException(nameof(grade), "Ocena musi być w zakresie od 0 do 100.");

            grades.Add((float)grade);
        }

        public bool TryAddGrade(string grade, out string? error)
        {
            error = null;

            if (string.IsNullOrWhiteSpace(grade))
            {
                error = "Ocena nie może być pusta.";
                return false;
            }

            if (!float.TryParse(grade, NumberStyles.Float, CultureInfo.InvariantCulture, out float numericGrade))
            {
                error = "Podana wartość nie jest prawidłową liczbą.";
                return false;
            }

            if (numericGrade < 0 || numericGrade > 100)
            {
                error = "Ocena musi być w zakresie od 0 do 100.";
                return false;
            }

            grades.Add(numericGrade);
            return true;
        }

        public Statistics GetStatistics()
        {
            var statistics = new Statistics();
            statistics.Average = 0;
            statistics.Max = float.MinValue;
            statistics.Min = float.MaxValue;

            if (this.grades.Any())
            {
                statistics.Average = this.grades.Average();
                statistics.Max = this.grades.Max();
                statistics.Min = this.grades.Min();
            }

            switch (statistics.Average)
            {
                case var a when a >= 80:
                    statistics.AverageLetter = 'A';
                    break;
                case var a when a >= 60:
                    statistics.AverageLetter = 'B';
                    break;
                case var a when a >= 40:
                    statistics.AverageLetter = 'C';
                    break;
                case var a when a >= 20:
                    statistics.AverageLetter = 'D';
                    break;
                default:
                    statistics.AverageLetter = 'E';
                    break;
            }

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

            switch (statistics.Average)
            {
                case var a when a >= 80:
                    statistics.AverageLetter = 'A';
                    break;
                case var a when a >= 60:
                    statistics.AverageLetter = 'B';
                    break;
                case var a when a >= 40:
                    statistics.AverageLetter = 'C';
                    break;
                case var a when a >= 20:
                    statistics.AverageLetter = 'D';
                    break;
                default:
                    statistics.AverageLetter = 'E';
                    break;
            }

            return statistics;
        }


        public Statistics GetStatisticsWithFor()
        {
            var statistics = new Statistics();

            if (grades.Count == 0)
                return statistics;

            float sum = 0;
            float min = float.MaxValue;
            float max = float.MinValue;

            for (int i = 0; i < grades.Count; i++)
            {
                float grade = grades[i];
                sum += grade;
                min = Math.Min(min, grade);
                max = Math.Max(max, grade);
            }

            statistics.Average = sum / grades.Count;
            statistics.Min = min;
            statistics.Max = max;

            return statistics;
        }

        public Statistics GetStatisticsWithWhile()
        {
            var statistics = new Statistics();

            if (grades.Count == 0)
                return statistics;

            float sum = 0;
            float min = float.MaxValue;
            float max = float.MinValue;
            int i = 0;

            while (i < grades.Count)
            {
                float grade = grades[i];
                sum += grade;
                min = Math.Min(min, grade);
                max = Math.Max(max, grade);
                i++;
            }

            statistics.Average = sum / grades.Count;
            statistics.Min = min;
            statistics.Max = max;

            return statistics;
        }

        public Statistics GetStatisticsWithDoWhile()
        {
            var statistics = new Statistics();

            if (grades.Count == 0)
                return statistics;

            float sum = 0;
            float min = float.MaxValue;
            float max = float.MinValue;
            int i = 0;

            do
            {
                float grade = grades[i];
                sum += grade;
                min = Math.Min(min, grade);
                max = Math.Max(max, grade);
                i++;
            } while (i < grades.Count);

            statistics.Average = sum / grades.Count;
            statistics.Min = min;
            statistics.Max = max;

            return statistics;
        }
    }
}
