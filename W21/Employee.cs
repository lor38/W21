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
                throw new ArgumentOutOfRangeException(nameof(grade), "Grade cannot be less than 0.");
            }
            else if (grade > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(grade), "Grade cannot be greater than 100.");
            }

            grades.Add(grade);
        }

        public void AddGrade(string grade)
        {
            if (string.IsNullOrWhiteSpace(grade))
            {
                throw new ArgumentException("Grade cannot be empty.", nameof(grade));
            }

            if (!float.TryParse(grade, NumberStyles.Float, CultureInfo.InvariantCulture, out float numericGrade))
            {
                throw new ArgumentException("The provided value is not a valid number.", nameof(grade));
            }

            AddGrade(numericGrade);
        }

        public void AddGrade(double grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentOutOfRangeException(nameof(grade), "Grade must be between 0 and 100.");

            grades.Add((float)grade);
        }

        public void AddGrade(long grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentOutOfRangeException(nameof(grade), "Grade must be between 0 and 100.");

            grades.Add((float)grade);
        }

        public bool TryAddGrade(string grade, out string? error)
        {
            error = null;

            if (string.IsNullOrWhiteSpace(grade))
            {
                error = "Grade cannot be empty.";
                return false;
            }

            if (!float.TryParse(grade, NumberStyles.Float, CultureInfo.InvariantCulture, out float numericGrade))
            {
                error = "The provided value is not a valid number.";
                return false;
            }

            if (numericGrade < 0 || numericGrade > 100)
            {
                error = "Grade must be between 0 and 100.";
                return false;
            }

            grades.Add(numericGrade);
            return true;
        }

        public Statistics GetStatistics()
        {
            var statistics = new Statistics();

            if (grades.Count > 0)
            {
                statistics.Average = grades.Average();
                statistics.Max = grades.Max();
                statistics.Min = grades.Min();
            }
            else
            {
                statistics.Average = 0;
                statistics.Max = 0;
                statistics.Min = 0;
            }

            return statistics;
        }

        public Statistics GetStatisticsWithForEach()
        {
            var statistics = new Statistics();

            if (grades.Count == 0)
                return statistics;

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
