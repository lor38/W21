using NUnit.Framework;
using W21;

namespace W21.Test
{
    public class TypeTest
    {
        [Test]
        public void IntValues_ShouldBeEqual()
        {
            // Arrange
            int score1 = 25;
            int score2 = 25;

            // Act & Assert
            Assert.That(score1, Is.EqualTo(score2));
        }

        [Test]
        public void FloatValues_ShouldConvertAndCompare()
        {
            // Arrange
            float original = 15.7f;
            int converted = (int)original;

            // Act & Assert
            Assert.That(converted, Is.EqualTo(15));
        }

        [Test]
        public void StringValues_ShouldBeEqualByValue()
        {
            // Arrange
            string name1 = "Robert";
            string name2 = "Robert";

            // Act & Assert
            Assert.That(name1, Is.EqualTo(name2)); 
        }

        [Test]
        public void UserLoginValues_ShouldMatch()
        {
            // Arrange
            var user1 = new User("Robert", "pass123");
            var user2 = new User("Robert", "pass123");

            // Act & Assert
            Assert.That(user1.Login, Is.EqualTo(user2.Login)); 
        }

        [Test]
        public void EmployeeScoreSum_ShouldBeCorrect()
        {
            // Arrange
            var emp = new Employee("Anna", "Kowalska", 30);
            emp.AddScore(10);
            emp.AddScore(15);

            // Act
            int total = emp.TotalScore;

            // Assert
            Assert.That(total, Is.EqualTo(25));
        }

        [Test]
        public void NegativeScore_ShouldAffectTotalCorrectly()
        {
            // Arrange
            var emp = new Employee("Ewa", "Wiśniewska", 35);
            emp.AddScore(10);
            emp.AddScore(-5);

            // Act
            int total = emp.TotalScore;

            // Assert
            Assert.That(total, Is.EqualTo(5));
        }

        [Test]
        public void UserFloatScores_ShouldBeHandledViaConversion()
        {
            // Arrange
            var user = new User("FloatUser", "floatpass");
            float val1 = 3.9f;
            float val2 = 6.2f;

            // Act
            user.AddScore((int)val1); 
            user.AddScore((int)val2); 

            // Assert
            Assert.That(user.Result, Is.EqualTo(9));
        }
    }
}
