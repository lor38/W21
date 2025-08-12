using System;

namespace W21
{
    public abstract class EmployeeBase : IEmployee
    {
        public string Name { get; }
        public string Surname { get; }

        public event GradeAddedDelegate? GradeAdded;

        protected EmployeeBase(string name, string surname)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "Imię nie może być puste.");
            Surname = surname ?? throw new ArgumentNullException(nameof(surname), "Nazwisko nie może być puste.");
        }

        protected void OnGradeAdded()
        {
            GradeAdded?.Invoke(this, EventArgs.Empty);
        }

        public abstract void AddGrade(float grade);
        public abstract void AddGrade(long grade);
        public abstract void AddGrade(string grade);
        public abstract Statistics GetStatistics();
        public abstract Statistics GetStatisticsWithForEach();
    }
}
