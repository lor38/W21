using NUnit.Framework;
using W21;

namespace W21Tests
{
    public class EmployeeTests
    {
        [Test]
        public void GetStatistics_ShouldReturnCorrectValues()
        {
            var emp = new Employee("Test", "Person");
            emp.AddGrade(4);
            emp.AddGrade(2);
            emp.AddGrade(6);

            var stats = emp.GetStatistics();

            Assert.That(stats.Average, Is.EqualTo(4));
            Assert.That(stats.Min, Is.EqualTo(2));
            Assert.That(stats.Max, Is.EqualTo(6));
        }

        [Test]
        public void GetStatistics_EmptyGrades_ShouldReturnZeroes()
        {
            var emp = new Employee("Empty", "Person");

            var stats = emp.GetStatistics();

            Assert.That(stats.Average, Is.EqualTo(0));
            Assert.That(stats.Min, Is.EqualTo(0));
            Assert.That(stats.Max, Is.EqualTo(0));
        }

        [Test]
        public void Grades_WithNegativeValue_ShouldBeIncluded()
        {
            var emp = new Employee("Neg", "Test");
            emp.AddGrade(3);
            emp.AddGrade(-2);
            emp.AddGrade(1);

            var stats = emp.GetStatistics();

            Assert.That(stats.Min, Is.EqualTo(-2));
            Assert.That(stats.Max, Is.EqualTo(3));
            Assert.That(stats.Average, Is.EqualTo(0.6666667f).Within(0.0001));
        }
    }
}
