using System;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void TestCalc()
        {
            //correct data
            string expression = "8+2";
            string expected = "10";
            MyCalc calc = new MyCalc();
            string actual = calc.Calc(expression);
            Assert.Equal(expected, actual);

            //not correct data
            expression = "8/0";
            expected = "NOT ÷ 0";
            actual = calc.Calc(expression);
            Assert.Equal(expected, actual);
            expression = "999999999+1";
            expected = "EXCEEDED";
            actual = calc.Calc(expression);
            Assert.Equal(expected, actual);
            expression = "8d9";
            expected = "error";
            actual = calc.Calc(expression);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestMultiply()
        {
            string x = "2";
            string y = "3";
            string expected = "6";
            MyCalc calc = new MyCalc();
            string actual = calc.Multiply(x, y).ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDivide()
        {
            string x = "9";
            string y = "3";
            string expected = "3";
            MyCalc calc = new MyCalc();
            string actual = calc.Divide(x, y).ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSum()
        {
            string x = "2";
            string y = "3";
            string expected = "5";
            MyCalc calc = new MyCalc();
            string actual = calc.Sum(x, y).ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestMinus()
        {
            string x = "8";
            string y = "3";
            string expected = "5";
            MyCalc calc = new MyCalc();
            string actual = calc.Minus(x, y).ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetValues()
        {
            string expression = "8+2";
            var expected = new { Item1 = "8", Item2 = "+", Item3 = "2" };
            MyCalc calc = new MyCalc();
            var actual = calc.GetValues(expression);
            Assert.Equal(expected.Item1, actual.Item1);
            Assert.Equal(expected.Item2, actual.Item2);
            Assert.Equal(expected.Item3, actual.Item3);
        }
    }
}
