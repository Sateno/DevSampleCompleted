using System;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            // Instructed to not change the public interface. It happens that in this case it will quickly 
            // overcome the int, I would have returned a long, or even better a BigInteger, in any case here it goes
            // 13! will exceed the value of an integer, will create a unit test for that but we must "check" it
            // Pitty, simply returning a BigInteger would help us not to throw any exceptions. 

            if (n < 0)
                throw new ArgumentOutOfRangeException(nameof(n), "n must be >= 0");

            checked
            {
                int factorial = 1;
                for (int i = 1; i <= n; i++)
                {
                    factorial *= i;
                }

                return factorial;
            }
 
        }

        public static string FormatSeparators(params string[] items)
        {
            // The unit test seems to indicate that the separators are ',' and 'and'
            // based on that, we have the following:

            if (items == null)
            {
                return string.Empty;
            }

            switch (items.Length)
            {
                case 0:
                    return string.Empty;
                case 1:
                    return items[0];
                case 2:
                    return $"{items[0]} and {items[1]}";
                default:
                    return string.Join(", ", items, 0, items.Length - 1) + " and " + items[items.Length-1];
            }
        }
    }
}