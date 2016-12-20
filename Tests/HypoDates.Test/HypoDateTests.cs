namespace HypoDates.Test
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class HypoDateTests
    {
        [Test]
        public void ShouldCalculateElapsedDatys_WithinTheSameMonthAndYear()
        {
            // Arrange
            var from = new HypoDate(1983, 6, 2);
            var to = new HypoDate(1983, 6, 22);

            // Act
            var result = HypoDate.GetElapsedDays(from, to);

            // Assert
            Assert.AreEqual(19, result);
        }

        [Test]
        public void ShouldCalculateElapsedDatys_WithinTheSameYear()
        {
            // Arrange
            var from = new HypoDate(1984, 7, 4);
            var to = new HypoDate(1984, 12, 25);

            // Act
            var result = HypoDate.GetElapsedDays(from, to);

            // Assert
            Assert.AreEqual(173, result);
        }

        [Test]
        public void ShouldCalculateElapsedDatys_ForDifferentYears()
        {
            // Arrange
            var from = new HypoDate(1983, 8, 3);
            var to = new HypoDate(1989, 1, 3);

            // Act
            var result = HypoDate.GetElapsedDays(from, to);

            // Assert
            Assert.AreEqual(1979, result);
        }

        [Test]
        public void ShouldCalculateElapsedDatys_ForContinuousDays()
        {
            // Arrange
            var from = new HypoDate(1972, 11, 7);
            var to = new HypoDate(1972, 11, 8);

            // Act
            var result = HypoDate.GetElapsedDays(from, to);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ShouldCalculateElapsedDatys_ForOneDayOfSeparation()
        {
            // Arrange
            var from = new HypoDate(2016, 2, 28);
            var to = new HypoDate(2016, 3, 1);

            // Act
            var result = HypoDate.GetElapsedDays(from, to);

            // Assert
            Assert.AreEqual(1, result);
        }


        [Test]
        public void ShouldCalculateElapsedDatys_ForLifeTime()
        {
            // Arrange
            var from = new HypoDate(1983, 3, 13);
            var to = new HypoDate(2016, 12, 19);

            // Act
            var result = HypoDate.GetElapsedDays(from, to);

            // Assert
            Assert.AreEqual(12334, result);
        }

        [Test]
        public void ShouldCalculateAbosluteDays()
        {
            // Arrange
            var date = new HypoDate(1983, 3, 13);

            var expectedDays = (new DateTime(1983, 3, 13) - new DateTime(1901, 1, 1)).TotalDays;

            // Act
            var result = date.AbsoluteDays;

            // Assert
            Assert.AreEqual(expectedDays, result);
        }
    }
}
