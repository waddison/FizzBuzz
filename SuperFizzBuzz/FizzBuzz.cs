using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SuperFizzBuzz
{
    public class FizzBuzz
    {
        private readonly Dictionary<int, string> _defaultReplacementValues = new Dictionary<int, string>
        {
            {3, "Fizz"},
            {5, "Buzz"}
        };

        public List<string> CalculateRange()
        {
            return CalculateRange(1, 100);
        }

        public List<string> CalculateRange(int from, int to)
        {
            return CalculateRange(from, to, null);
        }

        public List<string> CalculateRange(int from, int to, Dictionary<int, string> replacementValues)
        {
            replacementValues ??= _defaultReplacementValues;
            var ascending = from < to;
            var currentNumber = from;

            var processedFizzBuzz = new List<string>();

            for (var i = currentNumber; ascending ? i <= to : i >= to; )
            {
                if (ascending)
                {
                    processedFizzBuzz.Add(BuildPrintItem(i++, replacementValues));
                }
                else
                {
                    processedFizzBuzz.Add(BuildPrintItem(i--, replacementValues));
                }

            }

            return processedFizzBuzz;
        }

        public List<string> CalculateSpecifiedNumbers(IEnumerable<int> suppliedValues)
        {
            return CalculateSpecifiedNumbers(suppliedValues, null);
        }

        public List<string> CalculateSpecifiedNumbers(IEnumerable<int> suppliedValues, Dictionary<int, string> replacementValues)
        {
            replacementValues ??= _defaultReplacementValues;

            return suppliedValues.Select(value => BuildPrintItem(value, replacementValues)).ToList();
        }

        private static string BuildPrintItem(int currentNumber, IDictionary<int, string> replacementValues)
        {
            var sortedReplacementValues = new SortedDictionary<int, string>(replacementValues);
            var replacedPrintItem = string.Empty;

            foreach (var kvp in sortedReplacementValues.Where(kvp => currentNumber % kvp.Key == 0 && currentNumber != 0))
            {
                sortedReplacementValues.TryGetValue(kvp.Key, out var replacement);
                replacedPrintItem += replacement;
            }

            return !string.IsNullOrEmpty(replacedPrintItem) ? replacedPrintItem : currentNumber.ToString();
        }
    }
}
