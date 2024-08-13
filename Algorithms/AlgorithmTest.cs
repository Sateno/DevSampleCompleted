using System;
using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        [Fact]
        public void CanGetFactorial()
        {
            Assert.Equal(24, Algorithms.GetFactorial(4));
        }

        [Fact]
        public void GetFactorial_Negative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Algorithms.GetFactorial(-1));
        }

        [Fact]
        public void GetFactorial_Zero()
        {
            Assert.Equal(1, Algorithms.GetFactorial(0));
        }

        [Fact]
        public void GetFactorial_ThrowsOverflowException()
        {
            Assert.Throws<OverflowException>(() => Algorithms.GetFactorial(30));
        }

        [Fact]
        public void FormatSeparators_Null()
        {
            Assert.Equal(string.Empty, Algorithms.FormatSeparators(null));
        }

        [Fact]
        public void FormatSeparators_Empty()
        {
            Assert.Equal(string.Empty, Algorithms.FormatSeparators());
        }

        [Fact]
        public void FormatSeparators_OneItem()
        {
            Assert.Equal("a", Algorithms.FormatSeparators("a"));
        }

        [Fact]
        public void FormatSeparators_TwoItems()
        {
            Assert.Equal("a and b", Algorithms.FormatSeparators("a", "b"));
        }


        [Fact]
        public void CanFormatSeparators()
        {
            Assert.Equal("a, b and c", Algorithms.FormatSeparators("a", "b", "c"));
        }

    }
}