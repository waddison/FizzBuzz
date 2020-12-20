using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace SuperFizzBuzz.Tests
{
    public class FizzBuzzSuppliedNumbersTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly FizzBuzz _superFizzBuzz;

        public FizzBuzzSuppliedNumbersTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _superFizzBuzz = new FizzBuzz();
        }

        [Fact]
        public void ShouldPrintFizzBuzz_SuppliedNumbers()
        {
            var arbitraryList = new List<int>
            {
                1, 5, 3, -3, -5, 7, -7, 15, -30
            };

            var fizzBuzzResults = _superFizzBuzz.CalculateSpecifiedNumbers(arbitraryList);

            Assert.Equal(arbitraryList.Count, fizzBuzzResults.Count);
            Assert.Equal("1", fizzBuzzResults[0]);
            Assert.Equal("Buzz", fizzBuzzResults[1]);
            Assert.Equal("Fizz", fizzBuzzResults[2]);
            Assert.Equal("Fizz", fizzBuzzResults[3]);
            Assert.Equal("Buzz", fizzBuzzResults[4]);
            Assert.Equal("7", fizzBuzzResults[5]);
            Assert.Equal("-7", fizzBuzzResults[6]);
            Assert.Equal("FizzBuzz", fizzBuzzResults[7]);
            Assert.Equal("FizzBuzz", fizzBuzzResults[8]);
        }

        [Fact]
        public void ShouldPrintFizzBuzz_SuppliedNumbers_EmptyList()
        {
            var fizzBuzzResults = _superFizzBuzz.CalculateSpecifiedNumbers(new List<int>());

            Assert.Empty(fizzBuzzResults);
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
