namespace W21
{
    public interface IEmployee
    {
        string Name { get; }
        string Surname { get; }

        event GradeAddedDelegate GradeAdded;

        void AddGrade(float grade);
        void AddGrade(long grade);
        void AddGrade(string grade);

        Statistics GetStatistics();
        Statistics GetStatisticsWithForEach();
    }
}
