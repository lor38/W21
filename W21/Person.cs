namespace W21
{
    public abstract class Person
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }

        protected Person(string name, string surname)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "Imię nie może być puste.");
            Surname = surname ?? throw new ArgumentNullException(nameof(surname), "Nazwisko nie może być puste.");
        }

    }
}
