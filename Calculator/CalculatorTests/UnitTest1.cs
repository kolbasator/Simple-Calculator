using NUnit.Framework;
using Calculator;
using FluentAssertions;
using System;

namespace CalculatorTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculatorNullTest()
        {
            SimpleCalculator calculator = new SimpleCalculator();
            Action act = () => calculator.Calculate("2 / 0");
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Не делай так");
            Action act2 = () => calculator.Calculate("0 / 2");
            act2.Should().Throw<InvalidOperationException>()
                .WithMessage("Не делай так");
        }
        [Test]
        public void InvalidInputTest()
        {
            SimpleCalculator calculator = new SimpleCalculator();
            Action act = () => calculator.Calculate("A + B");
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Не стоит пихать что попало в калькулятор ! Будь разумным.");
        }

        [Test]
        public void CalculatorTest1()
        {
            SimpleCalculator calculator = new SimpleCalculator();
            Assert.AreEqual(8, calculator.Calculate("2 * ( 2 + 2 )"));
        }
        [Test]
        public void CalculatorTest2()
        {
            SimpleCalculator calculator = new SimpleCalculator();
            Assert.AreEqual(9442509, calculator.Calculate("418560 / ( 34 * 25 - 196 ) * 708 - 500347 / 983 + 8989898"));
        }
        [Test]
        public void CalculatorTest3()
        {
            SimpleCalculator calculator = new SimpleCalculator();
            Assert.AreEqual(0.2211802765907797, calculator.Calculate("20 * 20 / ( 10 - ( 4.777 * 7.666 + 6 ) + 5 * ( 43.32 * 8.5 ) )"));
        }
        [Test]
        public void CalculatorTest4()
        {
            SimpleCalculator calculator = new SimpleCalculator();
            Assert.AreEqual(60263.1557377049180328, calculator.Calculate("( 1338 + 58487 ) + 123 / 244 * 38 + ( 1028 - 609 )"));
        }
        
    }
}