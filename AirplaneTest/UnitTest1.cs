namespace AirplaneTest
{
    public class UnitTest1
    {
        int direction = 4;
        int horizontal = 42;
        int vertical = 5;

        [Fact]
        public void CalculateHorizontalTest()
        {
            Assert.Equal(52, CalculateHorizontal());
        }
        [Fact]
        public void CalculateVerticalTest()
        {
            Assert.Equal(21, CalculateVertical());
        }
        [Fact]
        public void CalculateUpTest()
        {
            Assert.Equal(9, CalculateUp());
        }
        [Fact]
        public void CalculateDownTest()
        {
            Assert.Equal(3, CalculateDown());
        }
        [Fact]
        public void CalculateSumTest()
        {
            Assert.Equal(210, CalculateTotal());
        }

        int CalculateHorizontal() => horizontal += 10;   
        int CalculateVertical() => vertical = (4 * direction) + vertical;
        int CalculateUp() => direction += 5;
        int CalculateDown() => direction -= 1;
        int CalculateTotal() => horizontal * vertical;
    }
}