using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fizzobuzzci;

namespace FizzobuzzciTest
{
    [TestClass]
    public class FizzobuzzciTest
    {
        private FizzobuzzciGenerator testClass = new();

        [TestMethod]
        [DataRow(0u)]
        [DataRow(10u)]
        [DataRow(1u)]
        [DataRow(100u)]
        [DataRow(100000u)]
        [DataRow(uint.MaxValue)]
        public void TestUintInputs(uint value)
        {
            testClass.NumTerms = value;
            Assert.AreEqual(value, testClass.NumTerms);

            testClass.Reset();
            testClass.Y = value;
            Assert.AreEqual(value, testClass.Y);

            testClass.Reset();
            testClass.Z = value;
            Assert.AreEqual(value, testClass.Z);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(10)]
        [DataRow(1)]
        [DataRow(100)]
        [DataRow(100000)]
        [DataRow(-10)]
        [DataRow(-1)]
        [DataRow(-100)]
        [DataRow(-100000)]
        [DataRow(int.MaxValue)]
        [DataRow(int.MinValue)]
        public void TestIntInputs(int value)
        {
            testClass.FizzDivisor = value;
            Assert.AreEqual(value, testClass.FizzDivisor);

            testClass.Reset();
            testClass.BuzzDivisor = value;
            Assert.AreEqual(value, testClass.BuzzDivisor);
        }

        [TestMethod]
        [DataRow("blah")]
        [DataRow("")]
        [DataRow("testing")]
        public void TestStringInputs(string value)
        {
            testClass.FizzString = value;
            Assert.AreEqual(value, testClass.FizzString);

            testClass.Reset();
            testClass.BuzzString = value;
            Assert.AreEqual(value, testClass.BuzzString);
        }

        [TestMethod]
        public void TestReset()
        {
            testClass.NumTerms = 12;
            testClass.Y = 3;
            testClass.Z = 3;
            testClass.FizzDivisor = 4;
            testClass.BuzzDivisor = 4;
            testClass.FizzString = "Four";
            testClass.BuzzString = "For";
            testClass.Reset();
            Assert.AreEqual(10u, testClass.NumTerms);
            Assert.AreEqual(1u, testClass.Y);
            Assert.AreEqual(2u, testClass.Z);
            Assert.AreEqual(3, testClass.FizzDivisor);
            Assert.AreEqual(5, testClass.BuzzDivisor);
            Assert.AreEqual("fizz", testClass.FizzString);
            Assert.AreEqual("buzz", testClass.BuzzString);
        }

        [TestMethod]
        public void TestOutputString()
        {
            testClass.Reset();
            string output = testClass.GenerateOutputString();
            Assert.AreEqual("1, 1, 2, fizz, buzz, 8, 13, fizz, 34, buzz", output);

            testClass.NumTerms = 12;
            testClass.Y = 3;
            testClass.Z = 3;
            testClass.FizzDivisor = 4;
            testClass.BuzzDivisor = 4;
            testClass.FizzString = "Four";
            testClass.BuzzString = "For";
            output = testClass.GenerateOutputString();
            Assert.AreEqual("1, 1, 1, 2, 2, 2, FourFor, FourFor, FourFor, FourFor, FourFor, FourFor", output);
        }
    }
}