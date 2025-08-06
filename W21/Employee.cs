namespace W21
{
    public class Employee
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }

        private List<int> scores = new List<int>();
        public IReadOnlyList<int> Scores => scores.AsReadOnly();

        public int TotalScore => scores.Sum();

        public Employee(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public void AddScore(int score)
        {
            scores.Add(score);
        }

        public void Display()
        {
            Console.WriteLine($"Imię: {FirstName}");
            Console.WriteLine($"Nazwisko: {LastName}");
            Console.WriteLine($"Wiek: {Age}");
            Console.WriteLine($"Oceny: {string.Join(", ", scores)}");
            Console.WriteLine($"Łączna liczba punktów: {TotalScore}");
        }
    }
}
