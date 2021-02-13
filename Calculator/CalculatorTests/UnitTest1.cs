using NUnit.Framework;
using Calculator;
using FluentAssertions;
using System;

namespace CalculatorTests
{
    public class Tests
    {
        public SimpleCalculator calculator = new SimpleCalculator(); 
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculatorNullTest()
        { 
            Action act = () => calculator.Calculate("2 / 0");
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Не делай так");
        }
        [Test]
        public void InvalidInputTest()
        { 
            Action act = () => calculator.Calculate("A + B");
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Не стоит пихать что попало в калькулятор ! Будь разумным.");
        }

        [Test]
        public void CalculatorTest1()
        { 
            calculator.Calculate("2 * ( 2 + 2 )").Should().Be(8);
        }
        [Test]
        public void CalculatorTest2()
        {
            calculator.Calculate("418560 / ( 34 * 25 - 196 ) * 708 - 500347 / 983 + 8989898").Should().Be(9442509);
        }
        [Test]
        public void CalculatorTest3()
        { 
            calculator.Calculate("20 * 20 / ( 10 - ( 4.777 * 7.666 + 6 ) + 5 * ( 43.32 * 8.5 ) )").Should().Be(0.2211802765907797);
        }
        [Test]
        public void CalculatorTest4()
        { 
            calculator.Calculate("( 1338 + 58487 ) + 123 / 244 * 38 + ( 1028 - 609 )").Should().Be(60263.1557377049180328);
        }
        [Test]
        public void CalculatorTest5()
        { 
            calculator.Calculate("2 * 7 ^ 2").Should().Be(98);
        }
        [Test]
        public void CalculatorTest6()
        { 
            calculator.Calculate("2.5 * ( 1 + ( 2 ^ 0 ) )").Should().Be(5);
        }
        [Test]
        public void CalculatorTest7()
        { 
            calculator.Calculate("2 / 2 * ( 100 + 40 ) / ( 2 ^ 2 + 4 )").Should().Be(17.5);
        }
        [Test]
        public void CalculatorTest8()
        {
            calculator.Calculate("1 + cos ( 1 / 2 ) + sin ( 1 / 2 )").Should().Be(2.3570081004945758);
        }
        [Test]
        public void CalculatorTest9()
        {
            calculator.Calculate("sin ( 5 ) * PI").Should().Be(-3.011022222442255);
        }
        [Test]
        public void CalculatorTest10()
        {
            calculator.Calculate("ctn ( 5 ) + 5").Should().Be(4.704187084467255); 
        }
        [Test]
        public void CalculatorTest11()
        {
            calculator.Calculate("tan ( 5 ) + 5").Should().Be(1.6194849937534141); 
        }
        public void CalculatorTest12()
        {
            calculator.Calculate("ex ( 6 ) * 6").Should().Be(2420.57276096);
        }
        [Test]
        public void CalculatorTest13()
        {
            calculator.Calculate("log ( 5 ) + 10").Should().Be(11.6094379124341);
        }



    }
}