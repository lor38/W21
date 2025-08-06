

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
            this.grades.Add(grade);
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
    }
}
