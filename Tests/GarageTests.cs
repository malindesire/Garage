using ConsoleApp;

namespace Tests
{
    public class GarageTests
    {
        private class TestSpot : Spot
        {
            public TestSpot(int number) : base(number) { }
        }

        [Fact]
        public void Garage_Should_Initialize_With_Correct_Capacity()
        {
            // Arrange
            int capacity = 5;
            var garage = new Garage<TestSpot>(capacity, i => new TestSpot(i));

            // Act
            var spots = garage.Spots;

            // Assert
            Assert.Equal(capacity, garage.Capacity);
            Assert.Equal(capacity, spots.Length);
        }

        [Fact]
        public void Garage_Should_Initialize_Spots_Correctly()
        {
            // Arrange
            int capacity = 3;
            var garage = new Garage<TestSpot>(capacity, i => new TestSpot(i));

            // Act

            // Assert
            foreach (var spot in garage.Spots)
            {
                Assert.NotNull(spot);
                Assert.IsType<TestSpot>(spot);
            }
        }

        [Fact]
        public void Garage_Should_Assign_Correct_Spot_Numbers()
        {
            // Arrange
            int capacity = 3;
            var garage = new Garage<TestSpot>(capacity, i => new TestSpot(i));

            // Act
            var spotNumbers = garage.Spots.Select(s => s.Number).ToArray();

            // Assert
            Assert.Equal(new[] { 1, 2, 3 }, spotNumbers);
        }
    }
}
