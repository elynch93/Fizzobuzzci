using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fibonacci
{
    class FibonacciGenerator
    {
        // Could either use Double or multiple Int64s per term to account for overflow, but that will just be a known deficiency for now.
        private List<Int64> _terms = new();

        public uint CurrentIndex {get; private set; }

        public uint NumTerms { get; set; }

        // Note uints for Y and Z to preserve recursive nature of series.
        public uint Y { get; set; }

        public uint Z { get; set; }

        public FibonacciGenerator()
        {
            Reset();
        }

        public void Reset()
        {
            CurrentIndex = 1;
            NumTerms = 10;
            Y = 1;
            Z = 2;
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

        public string GenerateOutputString()
        {
            CalculateSequence();
            return string.Join(", ", _terms);
        }
    }
}
