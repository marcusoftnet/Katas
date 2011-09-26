using System;
using System.Linq;
using NUnit.Framework;
using Should.Fluent;

namespace FizzBuzz
{
    [TestFixture]
    public class FizzBuzzTests
    {
        private  FizzBuzzer fizzBuzzer;

        [SetUp]
        public void SetUp()
        {
            fizzBuzzer = new FizzBuzzer();
        }

        [Test]
        public void Sending_1_to_FizzBuzzer_return_1()
        {
            GetFizzBuzzResult(1).Should().Equal("1");
        }

        [Test]
        public void sending_2_to_fizzbuzzer_returns_2()
        {
            GetFizzBuzzResult(2).Should().Equal("2");
        }

        [Test]
        public void sending_3_to_fizzbuzzer_returns_fizz()
        {
            GetFizzBuzzResult(3).Should().Equal("Fizz");
        }

        [Test]
        public void sending_5_to_fizzbuzzer_returns_buzz()
        {
            GetFizzBuzzResult(5).Should().Equal("Buzz");
        }

        [Test]
        public void sending_15_to_fizzbuzzer_returns_buzz()
        {
            GetFizzBuzzResult(15).Should().Equal("FizzBuzz");
        }

        [Test]
        public void testing_a_long_series()
        {
            // Arrange
            int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}; 

            // Act
            var result = numbers
                .Aggregate(string.Empty, (current, number) => 
                    current + (GetFizzBuzzResult(number) + ", "));
            result = result.Substring(0, result.Length - 2);

            // Assert
            result.Should().Equal("1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, 13, 14, FizzBuzz");
        }

        private string GetFizzBuzzResult(int number)
        {
            return fizzBuzzer.GetResult(number);
        }
    }
}