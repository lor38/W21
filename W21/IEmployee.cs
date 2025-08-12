namespace W21
{
    public interface IEmployee
    {
        string Name { get; }
        string Surname { get; }

        void AddGrade(float grade);
        void AddGrade(long grade);
        void AddGrade(string grade);

        Statistics GetStatistics();
        Statistics GetStatisticsWithForEach();
    }
}
