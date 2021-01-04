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

            do
            {
                processedFizzBuzz.Add(BuildPrintItem(currentNumber, replacementValues));

                if (ascending)
                {
                    if (currentNumber++ == to)
                    {
                        break;
                    }
                }
                else
                {
                    if (currentNumber-- == to)
                    {
                        break;
                    }
                }
            } while (true);

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
            var isReplacingValue = false;
            var replacedPrintItem = string.Empty;

            foreach (var kvp in sortedReplacementValues.Where(kvp => currentNumber % kvp.Key == 0 && currentNumber != 0))
            {
                isReplacingValue = true;
                sortedReplacementValues.TryGetValue(kvp.Key, out var replacement);
                replacedPrintItem += replacement;
            }

            return isReplacingValue ? replacedPrintItem : currentNumber.ToString();
        }
    }
}
