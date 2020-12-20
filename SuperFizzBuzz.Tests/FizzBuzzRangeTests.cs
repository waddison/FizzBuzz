using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace SuperFizzBuzz.Tests
{
    public class FizzBuzzRangeTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly FizzBuzz _superFizzBuzz;

        public FizzBuzzRangeTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _superFizzBuzz = new FizzBuzz();
        }

        [Fact]
        public void ShouldPrintDefaultFizzBuzz()
        {
            var fizzBuzzResults = _superFizzBuzz.CalculateRange();

            Assert.Equal(100, fizzBuzzResults.Count);
            Assert.Equal("Fizz", fizzBuzzResults[2]);
            Assert.Equal("Buzz", fizzBuzzResults[4]);
            Assert.Equal("FizzBuzz", fizzBuzzResults[14]);
        }

        [Fact]
        public void ShouldPrintFizzBuzz_PositiveRange()
        {
            var from = 1;
            var to = 15;

            var fizzBuzzResults = _superFizzBuzz.CalculateRange(from, to);

            Assert.Equal(15, fizzBuzzResults.Count);
            Assert.Equal("Fizz", fizzBuzzResults[2]);
            Assert.Equal("Buzz", fizzBuzzResults[4]);
            Assert.Equal("FizzBuzz", fizzBuzzResults[14]);
        }

        [Fact]
        public void ShouldPrintFizzBuzz_PositiveRange_DescendingOrder()
        {
            var from = 15;
            var to = 1;

            var fizzBuzzResults = _superFizzBuzz.CalculateRange(from, to);

            Assert.Equal(15, fizzBuzzResults.Count);
            Assert.Equal("Fizz", fizzBuzzResults[3]);
            Assert.Equal("Buzz", fizzBuzzResults[5]);
            Assert.Equal("FizzBuzz", fizzBuzzResults[0]);
        }

        [Fact]
        public void ShouldPrintFizzBuzz_NegativeRange()
        {
            var from = -15;
            var to = -1;

            var fizzBuzzResults = _superFizzBuzz.CalculateRange(from, to);

            Assert.Equal(15, fizzBuzzResults.Count);
            Assert.Equal("Fizz", fizzBuzzResults[3]);
            Assert.Equal("Buzz", fizzBuzzResults[5]);
            Assert.Equal("FizzBuzz", fizzBuzzResults[0]);
        }

        [Fact]
        public void ShouldPrintFizzBuzz_NegativeRange_DescendingOrder()
        {
            var from = -1;
            var to = -15;

            var fizzBuzzResults = _superFizzBuzz.CalculateRange(from, to);

            Assert.Equal(15, fizzBuzzResults.Count);
            Assert.Equal("Fizz", fizzBuzzResults[2]);
            Assert.Equal("Buzz", fizzBuzzResults[4]);
            Assert.Equal("FizzBuzz", fizzBuzzResults[14]);
        }

        [Fact]
        public void ShouldPrintFizzBuzz_EmptyRange()
        {
            var from = 0;
            var to = 0;

            var fizzBuzzResults = _superFizzBuzz.CalculateRange(from, to);

            Assert.Single(fizzBuzzResults);
            Assert.Equal("0", fizzBuzzResults[0]);
        }

        private void PrintResults(List<string> fizzBuzzResults)
        {
            foreach (var resultRow in fizzBuzzResults)
            {
                _testOutputHelper.WriteLine(resultRow);
            }
        }
    }
}
