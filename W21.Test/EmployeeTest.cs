using NUnit.Framework;
using W21;

namespace W21Tests
{
    public class EmployeeTests
    {
        [Test]
        public void GetStatisticsWithForEach_ShouldReturnCorrectValues()
        {
            var emp = new Employee("Test", "Person");
            emp.AddGrade(80);
            emp.AddGrade(60);
            emp.AddGrade(40);

            var stats = emp.GetStatisticsWithForEach();

            Assert.That(stats.Average, Is.EqualTo(60));
            Assert.That(stats.Min, Is.EqualTo(40));
            Assert.That(stats.Max, Is.EqualTo(80));
            Assert.That(stats.AverageLetter, Is.EqualTo('B'));
        }

        [Test]
        public void GetStatisticsWithForEach_EmptyGrades_ShouldReturnZeroesAndE()
        {
            var emp = new Employee("Empty", "Person");

            var stats = emp.GetStatisticsWithForEach();

            Assert.That(stats.Average, Is.EqualTo(0));
            Assert.That(stats.Min, Is.EqualTo(0));
            Assert.That(stats.Max, Is.EqualTo(0));
            Assert.That(stats.AverageLetter, Is.EqualTo('E'));
        }

        [Test]
        public void GetStatisticsWithForEach_ShouldAssignCorrectLetter_A()
        {
            var emp = new Employee("Top", "Performer");
            emp.AddGrade(100);
            emp.AddGrade(90);
            emp.AddGrade(85);

            var stats = emp.GetStatisticsWithForEach();

            Assert.That(stats.AverageLetter, Is.EqualTo('A'));
        }

        [Test]
        public void GetStatisticsWithForEach_ShouldAssignCorrectLetter_D()
        {
            var emp = new Employee("Low", "Performer");
            emp.AddGrade(25);
            emp.AddGrade(20);
            emp.AddGrade(15);

            var stats = emp.GetStatisticsWithForEach();

            Assert.That(stats.AverageLetter, Is.EqualTo('D'));
        }

       
    }
}
