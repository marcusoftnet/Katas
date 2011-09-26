namespace FizzBuzz
{
    public class FizzBuzzer
    {
        private const string FIZZ = "Fizz";
        private const string BUZZ = "Buzz";

        public string GetResult(int number)
        {
            if (number.IsDivisableWith3() && number.IsDivisableWith5())
                return FIZZ + BUZZ;
            if (number.IsDivisableWith3())
                return FIZZ;
            if (number.IsDivisableWith5())
                return BUZZ;
            return number.ToString();
        }
    }

    internal static class IntegerExtensions
    {
        internal static bool IsDivisableWith3(this int number)
        {
            return IsDivisableWith(number, 3);
        }

        internal static bool IsDivisableWith5(this int number)
        {
            return IsDivisableWith(number, 5);
        }

        private static bool IsDivisableWith(int number, int divisor)
        {
            return number % divisor == 0;
        }
    }
}
