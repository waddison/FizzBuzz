using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace SuperFizzBuzz.Tests
{
    public class FizzBuzzCustomReplacementTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly FizzBuzz _superFizzBuzz;

        public FizzBuzzCustomReplacementTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _superFizzBuzz = new FizzBuzz();
        }

        [Fact]
        public void ShouldPrintBeepBoop_WhenValueIsFiveOrSeven()
        {
            var customReplacements = new Dictionary<int, string>
            {
                { 5, "Beep" },
                { 7, "Boop" }
            };

            var fizzBuzzResults = _superFizzBuzz.CalculateRange(1, 100, customReplacements);

            Assert.Equal(100, fizzBuzzResults.Count);
            Assert.NotEqual("Fizz", fizzBuzzResults[2]);
            Assert.NotEqual("Buzz", fizzBuzzResults[4]);
            Assert.NotEqual("FizzBuzz", fizzBuzzResults[14]);
            Assert.Equal("Beep", fizzBuzzResults[4]);
            Assert.Equal("Boop", fizzBuzzResults[6]);
            Assert.Equal("BeepBoop", fizzBuzzResults[34]);
        }

        [Fact]
        public void ShouldDefaultToFizzBuzz_WhenNoReplacementProvided()
        {
            var fizzBuzzResults = _superFizzBuzz.CalculateRange(1, 100, null);

            Assert.Equal(100, fizzBuzzResults.Count);
            Assert.Equal("Fizz", fizzBuzzResults[2]);
            Assert.Equal("Buzz", fizzBuzzResults[4]);
            Assert.Equal("FizzBuzz", fizzBuzzResults[14]);
        }

        [Fact]
        public void ShouldNotAlterAnyNumbers_WhenEmptyReplacementProvided()
        {
            var customReplacements = new Dictionary<int, string>{};

            var fizzBuzzResults = _superFizzBuzz.CalculateRange(1, 100, customReplacements);

            Assert.Equal(100, fizzBuzzResults.Count);
            Assert.NotEqual("Fizz", fizzBuzzResults[2]);
            Assert.NotEqual("Buzz", fizzBuzzResults[4]);
            Assert.NotEqual("FizzBuzz", fizzBuzzResults[14]);
            Assert.NotEqual("Beep", fizzBuzzResults[4]);
            Assert.NotEqual("Boop", fizzBuzzResults[6]);
            Assert.NotEqual("BeepBoop", fizzBuzzResults[34]);

            Assert.All(fizzBuzzResults, result => Assert.True(int.TryParse(result, out var parsedNumber)));
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
