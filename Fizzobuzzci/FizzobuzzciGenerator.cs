using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Fizzobuzzci
{
    public class FizzobuzzciGenerator
    {
        // Could either use Double or multiple Int64s per term to account for overflow, but that will just be a known deficiency for now.
        private List<Int64> _terms = new();

        public uint CurrentIndex { get; private set; }

        public uint NumTerms { get; set; }

        // Note uints for Y and Z to preserve recursive nature of series.
        public uint Y { get; set; }
        public uint Z { get; set; }

        public int FizzDivisor { get; set; }
        public int BuzzDivisor { get; set; }

        public string FizzString { get; set; }
        public string BuzzString { get; set; }

        public FizzobuzzciGenerator()
        {
            Reset();
        }

        // Include compiler flag
        [MemberNotNull(nameof(FizzString), nameof(BuzzString))]
        public void Reset()
        {
            NumTerms = 10;
            Y = 1;
            Z = 2;
            FizzDivisor = 3;
            BuzzDivisor = 5;
            FizzString = "fizz";
            BuzzString = "buzz";
            CurrentIndex = 1;
        }

        public void CalculateSequence()
        {
            CurrentIndex = 1;
            // Empty list handles case with 0 terms.
            _terms = new();
            if (NumTerms > 0)
            {
                _terms.Add(1);
                CurrentIndex += 1;
            }

            if (NumTerms >= 1)
            {
                _terms.Add(1);
                CurrentIndex += 1;
                while (CurrentIndex <= NumTerms)
                {
                    if (CurrentIndex <= Y || CurrentIndex <= Z)
                    {
                        // One of the required terms doesn't exist yet, so output 1.
                        // Instructions could be interpreted slightly differently, but this interpretation ensures
                        // the original Fibonacci sequence is outputted correctly.
                        _terms.Add(1);
                    }
                    else
                    {
                        // _terms is 0-based, but CurrentIndex/NumTerms are 1-based, so subtract one when indexing
                        // into _terms.
                        _terms.Add(_terms[(int)(CurrentIndex - Y - 1)] + _terms[(int)(CurrentIndex - Z - 1)]);
                    }
                    CurrentIndex += 1;
                }
            }
            else
            {
                // Handle negative entries later.
            }
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

        public string GenerateOutputString()
        {
            CalculateSequence();
            List<string> terms = _terms.Select(x => GetFizzBuzzNumber(x)).ToList();
            return string.Join(", ", terms);
        }
    }
}
