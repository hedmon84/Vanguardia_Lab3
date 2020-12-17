using System;
using Xunit;

namespace Chess.UnitTests
{
    public class ChessTest
    {
        [Theory]
        [InlineData(6, 10)]
        [InlineData(3, 20)]
        [InlineData(4, 5)]
        public void Test1(int num1, int num2)
        {
            var calculator = new Calculator();
            var sum = calculator.Add(num1, num2);
            Assert.True(sum == num1+num2);
            Assert.Equal(num1+num2, sum);

        }

        [Theory]
        [InlineData(6)]
        [InlineData(3)]
        [InlineData(4)]
        public void Test2(double num1)
        {
            var calculator = new Calculator();
            Assert.ThrowsAny<ArgumentException>(() => calculator.Divide(num1, 0));
    

        }
    }
}
