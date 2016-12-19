namespace HypoDates.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class DateHelperTests
    {
        [Test]
        public void ShouldCalculateElapsedDatys_WithinTheSameMonthAndYear()
        {
            // Arrange
            var from = new HypoDate { Day = 2, Month = 6, Year = 1983 };
            var to = new HypoDate { Day = 22, Month = 6, Year = 1983 };

            // Act
            var result = DateHelper.GetElapsedDays(from, to);

            // Assert
            Assert.AreEqual(19, result);
        }

        [Test]
        public void ShouldCalculateElapsedDatys_WithinTheSameYear()
        {
            // Arrange
            var from = new HypoDate { Day = 4, Month = 7, Year = 1984 };
            var to = new HypoDate { Day = 25, Month = 12, Year = 1984 };

            // Act
            var result = DateHelper.GetElapsedDays(from, to);

            // Assert
            Assert.AreEqual(173, result);
        }

        [Test]
        public void ShouldCalculateElapsedDatys_ForDifferentYears()
        {
            // Arrange
            var from = new HypoDate { Day = 3, Month = 8, Year = 1983 };
            var to = new HypoDate { Day = 3, Month = 1, Year = 1989 };

            // Act
            var result = DateHelper.GetElapsedDays(from, to);

            // Assert
            Assert.AreEqual(1979, result);
        }

        [Test]
        public void ShouldCalculateElapsedDatys_ForLifeTime()
        {
            // Arrange
            var from = new HypoDate { Day = 13, Month = 3, Year = 1983 };
            var to = new HypoDate { Day = 19, Month = 12, Year = 2016 };

            // Act
            var result = DateHelper.GetElapsedDays(from, to);

            // Assert
            Assert.AreEqual(12334, result);
        }
    }
}
