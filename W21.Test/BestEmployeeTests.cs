using NUnit.Framework;
using W21;

namespace W21.Test
{
    public class BestEmployeeTests
    {
        [Test]
        public void ShouldSelectEmployeeWithHighestTotalScore()
        {
            // arrange
            var emp1 = new Employee("Anna", "Kowalska", 30);
            foreach (var score in new[] { 8, 9, 7, 10, 6 })
            {
                emp1.AddScore(score);
            }

            var emp2 = new Employee("Piotr", "Nowak", 42);
            foreach (var score in new[] { 10, 7, 10, 9, 10 })
            {
                emp2.AddScore(score);
            }

            var emp3 = new Employee("Ewa", "Wiśniewska", 35);
            foreach (var score in new[] { 10, 10, 9, 8, 9 })
            {
                emp3.AddScore(score);
            }

            var employees = new List<Employee> { emp1, emp2, emp3 };

            // act
            var bestEmployee = employees.OrderByDescending(e => e.TotalScore).First();

            // assert
            Assert.That(bestEmployee.TotalScore, Is.EqualTo(46));
            Assert.That(bestEmployee.FirstName, Is.EqualTo("Piotr"));
        }

        [Test]
        public void ShouldSelectEmployeeWithLowestTotalScore()
        {
            // arrange
            var emp1 = new Employee("Anna", "Kowalska", 30);
            foreach (var score in new[] { 8, 9, 7, 10, 6 })
            {
                emp1.AddScore(score);
            }

            var emp2 = new Employee("Piotr", "Nowak", 42);
            foreach (var score in new[] { 10, 7, 10, 9, 10 }) 
            {
                emp2.AddScore(score);
            }

            var emp3 = new Employee("Ewa", "Wiśniewska", 35);
            foreach (var score in new[] { 10, -50, 9, 8, 9 })
            {
                emp3.AddScore(score);
            }

            var employees = new List<Employee> { emp1, emp2, emp3 };

            // act
            var worstEmployee = employees.OrderBy(e => e.TotalScore).First();

            // assert
            Assert.That(worstEmployee.TotalScore, Is.EqualTo(-14));
            Assert.That(worstEmployee.FirstName, Is.EqualTo("Ewa"));
        }
    }
}
