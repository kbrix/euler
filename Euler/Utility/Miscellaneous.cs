using System;

namespace euler.Utility
{
    public static class Miscellaneous
    {
        /// <summary>
        /// Converts a latin character to the corresponding letter's index in the standard Latin alphabet.
        /// </summary>
        /// <param name="letter">An upper- or lower-case Latin character.</param>
        /// <returns>Returns alphabetical position, starting at one, of the letter in the Latin alphabet.</returns>
        public static int ConvertLetterToNumber(char letter)
        {
            // Uses the uppercase character unicode code point. 'A' = U+0042 = 65, 'Z' = U+005A = 90
            var x = char.ToUpper(letter);
            if (x < 'A' || x > 'Z')
            {
                throw new ArgumentOutOfRangeException(nameof(letter), "This method only accepts standard Latin characters.");
            }

            return x - 'A' + 1;
        }

        /// <summary>
        /// Computes the digit sum in base 10.
        /// </summary>
        /// <param name="x">A natural number.</param>
        /// <returns>The digit sum.</returns>
        public static int DigitSum(this int x)
        {
            var sum = 0d;

            var max = (int)Math.Floor(Math.Log10(x));

            for (int n = 0; n <= max; n++)
            {
                sum += 1 / Math.Pow(10, n) * ( x % Math.Pow(10, n + 1) - x % Math.Pow(10, n) );
            }

            return (int)sum;
        }
    }
}