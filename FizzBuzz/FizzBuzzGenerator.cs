using System;
using System.Diagnostics.CodeAnalysis;

namespace FizzBuzz
{
    class FizzBuzzGenerator
    {
        public uint NumTerms { get; set; }

        public int FizzDivisor { get; set; }
        public int BuzzDivisor { get; set; }

        public string FizzString { get; set; }
        public string BuzzString { get; set; }

        public FizzBuzzGenerator()
        {
            Reset();
        }

        private string GetFizzBuzzNumber(Int64 i)
        {
            string outputString = "";
            if (i % FizzDivisor == 0)
            {
                outputString += FizzString;
            }
            if (i % BuzzDivisor == 0)
            {
                outputString += BuzzString;
            }
            return outputString.Equals("") ? i.ToString() : outputString;
        }

        // Include compiler flag
        [MemberNotNull(nameof(FizzString), nameof(BuzzString))]
        public void Reset()
        {
            NumTerms = 10;
            FizzDivisor = 3;
            BuzzDivisor = 5;
            FizzString = "fizz";
            BuzzString = "buzz";
        }

        public string GenerateOutputString()
        {
            // Since output begins with 0, which is divisible by all numbers, default to starting with "fizzbuzz".
            string outputString = FizzString + BuzzString;

            for (Int64 i = 1; i <= NumTerms; i++)
            {
                outputString += ", " + GetFizzBuzzNumber(i);
            }

            return outputString;
        }
    }
}
