namespace W21
{
    class Employee
    {
       
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }

      
        public List<int> Scores { get; } = new List<int>();

        
        public int TotalScore => Scores.Sum();

        
        public Employee(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

       
        public void Display()
        {
            Console.WriteLine($"Imię: {FirstName}");
            Console.WriteLine($"Nazwisko: {LastName}");
            Console.WriteLine($"Wiek: {Age}");
            Console.WriteLine($"Oceny: {string.Join(", ", Scores)}");
            Console.WriteLine($"Łączna liczba punktów: {TotalScore}");
        }
    }
}
