namespace W21
{
    public class Employee(string firstName, string lastName, int age)
    {
        public string FirstName { get; } = firstName;
        public string LastName { get; } = lastName;
        public int Age { get; } = age;

        private List<int> scores = [];
        public IReadOnlyList<int> Scores => scores.AsReadOnly();

        public int TotalScore => scores.Sum();

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
